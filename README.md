# Tesnem

## Team

- Front-End
	- Mateus Lopes
	- Iaggo Quezado
	- Divaldo
- Back-End
	- Mateus Palacio
	- Matheus Carvalho
- Tests
	- Divaldo

## Summary

This back-end aims to help with managing the aspects of a university, such as classes, courses, professors, students, etc. For that, we have decided to implement this back-end in .NET 6, which will help with the management, while storing data in a MySQL Database. Both the API and the DB are hosted on Amazon, so that way there's a smaller latency between them and thus improving the performance of the apps.

This API is structured using DDD (Domain Driven Development) and is part of a microservice architecture. Other services include the Flutter Mobile App, the Angular Web Front-End for Administrators and the Identity Server for authentication of users.

## Other projects

https://github.com/Tesnem/tesnem_web

https://github.com/Tesnem/tesnem_app

https://github.com/Tesnem/Tesnem-Auth

## Architecture

### Tesnem.Api

The main project, where all Controllers are located, and also the configuration for database connections within AppSettings.json. Here you may also find the ExceptionMiddleware, which is used for creating better error responses for our clients, which should help making the usage of the application easier. Also, 2 command handlers can be found, they're used to check the Scope of the Auth Token used on the requests, because some Controllers such as the AccountController, have Administrator-only scopes, and these handlers help with ensuring no regular user will access these special endpoints.

### Tesnem.Data

Here you may find the Database Contexts, with AppDbContext for the main DB and IdentityDbContext for the user login database. You may also find the Repositories, which are the classes used to make queries on the database and then return to the user. We make use of a Generic Repository which is implemented by all classes, this way the entities are more generic and save time when creating new repositories, and also make everything unified.

### Tesnem.Domain

This project is where all models and contracts may be found, and also DTOs. 

Models are used as the entities for the database, and define the scope of the database tables, as we use Code-First Style for DB, meaning we need to create the models and then use migrations to update DB tables. This way, SQL code isn't required for the DB.

DTOs are classes similar to the models, but that have less attributes, so that users may have more specific responses and also make requests giving less information. We use AutoMapper (mapping found on AutoMapperProfile class) to map these DTOs into classes before contacting the database.

As For the Repository and Service folders, these are for the interfaces of the project. These interfaces are implemented on the Data and Service layers.

In Exceptions you may find the exception messages created for this app, since we decided to use custom exceptions and messages for this application.

### Tesnem.Services

Here, all Services are implemented. These implementations will map DTOs to Classes and vice versa, allowing the communication to the repositories and also a user-friendly response for database data.

## Usage

You may use the application by first contacting the IdentityServer, and then using the Token as a header of the request you make to our API. Every request will check for an "Authorization" header which should have a `Bearer <responseToken>` value.