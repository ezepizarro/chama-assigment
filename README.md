# Course Sign-up API
An api to sign-up students to courses

## Stack
- .Net Core 2.2.
- EF Core. 
- DDD architecture.
- Clean architecture.
- Units testing.
- Moq.
- Automapper
- Nlog
- Custom exception handler
- Azure Web App 
- Azure Service Bus
- Azure Functions
- Swagger using NSwag.
- Async Generic Repository Pattern.
- MS SQL.
- Includes Seed and Migrations to set up dev environment

## Overview
|API|Description|
|--|--|--|
|GET /api/Sessions  | Get all sessions (Part 3 of assigment) |
|GET /api/Sessions/{id}  | Get one session (Part 3 of assigment) |
|POST /api/Courses/SignUp| Sign up a student (Part 1 of assigment) |
|POST /api/Courses/SignUp/MessageBus  | Sing up a student async (Part 2 of assigment)|
|POST /api/Students  | Add a new student |

## Usage


### Using Azure Sandbox 

This has the latest commit from master branch

[Using Swagger UI](https://chamaapi20190711053853.azurewebsites.net/swagger)

### Running locally

#### .Net CORE web API
You will need Visual Studio 2019 with .NET Core SDK 2.2
#### Azure Function
