# IagoGibin-20210810 - Game Cup

## Getting Started
The way to get started is to install Docker in your computer and:

1. Navigate to root folder.
   - Run the command `docker-compose up` << this will setup the environment and run Back-end and Front-end Solutions   
2. Docker compose will download all necessary components.
3. Just access http://localhost:8080, there You can check this amazing application rs rs.
4. You can also access http://localhost:8080/swagger, there you can check all API endpoints. Thanks [Swagger](https://github.com/swagger-api)

## Testing
The easiest way to execute all Back-end tests in your computer:

1. Navigate to the root/API folder where GameCup.sln is located.
   - Run the command `dotnet test .\GameCup.sln` << this will execute all tests found in the solution

Or you can open the solution on Visual Studio and execute from there.

## Technologies
* Angular
* .NET Core 5.0
* Docker (Docker-compose)
* MediatR
* AutoMapper
* FluentValidation
* Swagger
* xUnit, Moq
