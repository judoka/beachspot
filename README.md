# BeachSpot .NET 6 Web Api

BeachSpot is an application developed by Emir Prljaca in order to have a representive backend solution for potential new clients/employers. Due to the development process I was  following requirements defined below.

### Requirements

The soultion should be a RESTful API as a .NET web app implemented with the latest stable version. Communication is JSON over HTTP, the database is PostgreSQL and the use of Docker is a plus.

The app should support the following user stories:

1. User model
Expose an endpoint that enables user registration. We want to persist the following data points about users: username, password, email. Implement request validation that makes the most sense to you.

2. Beaches
Expose endpoints to get and create beaches (name, image ref, description).

3. Authentication
Each request except for user registration and retrieval of beaches should only be allowed to registered i.e. authenticated users. To achieve this it is sufficient to implement Basic Authentication (Wiki on Basic Access Authentication), but any other form of security for the exposed endpoints will also be acceptable. There is no need to implement authorization but a basic authorization configuration will count as a bonus point.

4. Sightings
Expose sighting endpoint (longitude, latitude, user ref, beache ref, image ref). Operations on this endpoint include getting, creating and deleting a sighting. Only users who created a sighting can also delete it.

5. Likes
Expose endpoints for likes. A user can like a sighting and unlike (delete) it. Along with likes implementation also extend sighting endpoint with the counter of the number of likes of a sighting. Users can only delete their own likes, not from others.

6. Quote of the day
When a user creates a sighting, we want to add a random motivational quote to the entity and return it as part of a response. To get a quote you have to call quotes.rest and get the free quote-of-the-day.


### Prerequisites

In order to build and run the application, it is recommended that you have the following installed.

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download). You can test that you have it installed by entering the command `dotnet --list-sdks`
- [Entity Framework Command Line Tools](https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet). You can install these as a global tool with the command `dotnet tool install --global dotnet-ef`
- [PostgreSQL](https://www.postgresql.org/download/).
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) (Community Edition or Greater) or [Visual Studio Code](https://code.visualstudio.com/)

### Building the Code

You can either load `BeachSpot.sln` in Visual Studio 2022 and build from within Visual Studio, or from the command line, in the same folder as `BeachSpot.sln`, enter the `dotnet build` command.

### EF Migration
Before you run BeachSpot for the first time, you need to create an empty database and set connection string BeachSpotDBConnectionString inside file `BeachSpot.Api\appsettings.json`. The application will execute automated migration, create database structure and fill out some initial data.

### Some external libraries worth mentioning and used in the application are following
- [AutoMapper](https://automapper.org/)
- [FluentValidation](https://docs.fluentvalidation.net/)
- [MediatR](https://github.com/jbogard/MediatR)