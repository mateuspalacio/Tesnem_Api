FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /cert
RUN dotnet dev-certs https -ep tesnem.pfx -p c3rtp455w0rd

WORKDIR /app

# copy csproj and restore as distinct layers
# COPY Tesnem.Api/*.csproj /app/
# COPY Tesnem.Api.Data/*.csproj /Tesnem.Api.Data/
# COPY Tesnem.Api.Domain/*.csproj /Tesnem.Api.Domain/
# COPY Tesnem.Api.Services/*.csproj /Tesnem.Api.Services/
# COPY Tesnem.UnitTests/*.csproj /Tesnem.UnitTests/
# COPY Tesnem.sln .
COPY . .
#WORKDIR /app/Tesnem.Api
RUN dotnet restore

# copy and publish app and libraries
# WORKDIR /app
# COPY ./* .
RUN dotnet publish Tesnem.Api/*.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime
WORKDIR /certs/https
COPY --from=build /cert/tesnem.pfx ./

WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "Tesnem.Api.dll"]

