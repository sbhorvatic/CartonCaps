# CartonCaps
Livefront .NET coding challenge

This is split into two projects:
- CartonCapsRestApi
- CartonCapsMockApi

Each with sln, projects and testing.

# CartonCapsMockApi

# CartonCapsRestApi
This is a REST API project that is to power the new referral feature which will be leveraged by the frontend.

## Architecture Overview
This project will use or mock the following:
- In memory database store "Backend" as there was no call out in the coding challenge. If called out to leverage a database sqlite would have been used
- The following will be mocked out as per the coding challenge instructions
  - User authentication.
  - User profile details that include the current user's referral code.
  - New user registration.
  - Referral redemption as part of new user registration.  

## Dependencies
- Dotnet 9
 
 ## Running and Testing
 - `dotnet test` in directory with the sln for `CartonCapsRestApi`
 - `dotnet run --project CartonCapsRestApi.Web/CartonCapsRestApi.Web.csproj` in directory with the sln for `CartonCapsRestApi`

## OpenAPI
This project leverages the built in Microsoft Open API and Swagger UI for ease of use
- [Docs for Open API library](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/openapi/aspnetcore-openapi?view=aspnetcore-9.0&tabs=visual-studio%2Cvisual-studio-code)
- To use Swagger UI go to `http://localhost:PORT/swagger/`