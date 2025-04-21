# CartonCaps
Livefront .NET coding challenge

This is split into two projects:
- CartonCapsRestApi
- CartonCapsMockApi

Each with sln, projects and testing.

# RestSpec
This is the OpenAPI spec for the project. This was gen using Open API and can be seen when starting the app and going to `http://localhost:8080/openapi/v1.json`

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
 - App should be running at `http://localhost:8080/` and should be able to view the swagger page `http://localhost:8080/swagger/index.html`
   - NOTE IF AN APPLICATION IS RUNNING ON 8080 THE APPLICATION WILL NOT START! To fix this go to Program.cs and change `app.Run("http://0.0.0.0:8080");` to a port that will work

## OpenAPI / Rest API Spec
This project leverages the built in Microsoft Open API and Swagger UI for ease of use
- [Docs for Open API library](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/openapi/aspnetcore-openapi?view=aspnetcore-9.0&tabs=visual-studio%2Cvisual-studio-code)
- To use Swagger UI go to `http://localhost:PORT/swagger/`