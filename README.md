# Vueling Last Exam

API Rest that provides some methods to manage some Transactions and Currency Rates.

- Everything works!

## Structure
This project follows the DDD structure that's why the code it's divided in 4 tiers.
In this project those tiers are:
- Distributed services: Where the API requests are catched.
- Application: Manages the calls made in the whole code to unify business and data access functionalities.
- Domain/business: This layer basically treats the functionality the facade got. It also implements de business logic and has the external services logic.
- Infrastructure: Performs all the functionalities related to data acces.
- Common: This layer is accessed by all the others since it has common classes to be used such as the config helpers and the Automapper.

In the image below there's the flow of the write operations performed in this architecture.
![DDD Architecture diagram](https://docs.microsoft.com/en-us/dotnet/standard/microservices-architecture/microservice-ddd-cqrs-patterns/media/image21.png)
- API would match my Facade, Command Handler my Business Layer and Infrastructure where all my Repositories are allocated.-

## DFS Algorythm
- DFS algorythm used to find the rates to convert the currency. 
- The implementation of this algorythim uses recursivity and recalculates the result in each recursive call.

## Testing
- The file *appsettings.json* is added to each of test projects to allow the test classes get the connection string.

The testing follows the TDD architecture:
- The implemented tests don't have any dependence among them since they are not executed in any specific order.
- That's also possible since the database is cleaned everytime after each execution.

### Unit tests
- Used mocking to emulate the behaviour of its dependences. It was specially useful for the Repository classes since they don't have to interact with the DataBase.
- I used the *Autofac.Extras.Moq* package.
- Automatic Mocking: The automoq factory creates the mock are called in runtime, to emulate the AutoFac behaviour as well.
    - First rule of my mocking is to make the "x" object implement the right repository of the right Model.
    - Then there's a normal mocking where you can see the expected behaviour of the functionality.
- The main difference with normal mocking is the "AutoMock.GetLoose()" function which gives you the mock instantiated.


### Integration tests
- The class tested is instantiated with the modules located in each of the test projects to allow the class be instantiated without relying in any other of the classes related with the one is being tested. To do so the test class extends *IoCSupportedTest*.
This is a class that emulates all the dependences AutoFac injects just after running the application, such as the Logger and the Module we are setting as a type for the generic constructor.

To dependence between the tests with the layer above, I copied the modules to not have to reference the modules of the other layers and then get independent components that can work without requiring that much from others.


## Database

Using *flyway* the Database can be easily set up. 
- It let us have a simple versioning of the database scripts, so we can control the versions.
- That means there is the possibility to easily rollback the database to another version in case this one gets to an unconsistent state or there is just something wrong with it.

In the /sql folder we can find the sql files with all the database versions and the config file for the flyway migrations.
```
# flyway migrate
```

We can check if our migration has been done succesfully with the next command:
```
# flyway info
```
And check if the status of each of the script versions is *success*.

## Logger

Used a SeriLog dll which allows to register it with autofact so it can be injected in the Facade Tier once we run the application. Then this Logger is just in the constructor of the other classes instantiated in run-time, and all of them can implement SeriLog withouh creating any instance to use it. Then those classes don't have the responsibility to control which kind of specific logger is being used.

## Exceptions & Filters
All the exceptions are being caught with personalized exceptions depending on the tier. There are the *RepositoryException*, *BusinessException* and *Aplication Exception*. 

Then those ones are also received in the Facade layer with a *CustomExceptionFilter* The one, checking the exception and the inner exceptions of that ones will classify them in HTTP Responses to be thrown to the client is sending the requests.


## Swagger
The project autogenerates de Swagger documentation to know how to deal with all the API methods.

This swagger documentation is the first page launched when running the application.


## Other Features
### Clean code
#### SOLID Principles
**S**ingle responsibility Principle: Each class and method just has one responsibility. If it was more than one task implicated in it then I moved it to another method or class, depending on what I considered it was apropriate.

**O**pen Closed Principle: I tried to let all the classes to be extended without having to modify them for this purpose.

**L**iskov Substitution Principle: To use the AutoFac injection is required to call each of the modules to register using it's interface. That means the class it's being called in its interface place can be substituted by this one.

**I**nterface Segregation Principle: The repository classes, for example, are implementing many interfaces the ones have exactly the functionalities are required.

**D**ependence Inversion Principle: This feature is being performed while injecting dependencies with AutoFac. Also injecting Dependences as parameters for the Mocking in the unit testing.


### Some nugget packages
There are some nugget packages I had to download specifically since the applicacion is coded in .NET Core
#### Configuration File (*appsettings.json*)
The **Microsoft.Extensions.Configuration.json** and **System.Configuration.ConfigurationManager** nugget packages are required to let the ConfigHelper class deal the appsetting.json file since .NET Core doesn't have to use the *app.config* file.

#### ADO.NET in ASP.NET CORE
We need to install the nugget packages **System.Data.Common** and **System.Data.SqlClient** to deal with the Sql methods to connect with the DataBase.

## Environment
Hardware: Intel Core i5-8250U CPU @ 1.60Ghz 1801Mhz 64Bit 4 cores, 8 logical processors, 8GB DDR3 RAM

OS: Windows 10 Pro 10.0.17134 (Build 17134)

Software:
.NET Core 2.2

## Author

* **Ferran Ramírez**