# WebAuctions App

## Project Overview

WebAuctions is a .NET web application that implements an online auction platform. It utilizes Identity for user authentication and a self-implemented SQL database from Visual Studio for managing auctions, bids, and items. This app allows users to list auctions, display individual auctions, modify auction descriptions, place bids on auctions, and view their own auctions and the auctions they have won. Additionally, administrators have the ability to view all users and auctions and remove auctions as needed.

To get an overview of the project's functionality, you can watch a video demonstration [here](https://youtu.be/Tb82G0tqd3k).

## Project Structure

The project follows the Model-View-Controller (MVC) architectural pattern and is organized as follows:

- **DB**: The database layer where data storage and retrieval are managed.
- **InterfaceDB**: The database interface, which defines the contract for data access.
- **Service**: The service layer responsible for business logic and interacting with the database.
- **Service Interface**: The service interface defining the contract for application services.
- **Controller**: The controller layer for handling HTTP requests and controlling the application's flow.
- Views are used to display data to the user.

## Features

### User Management
- User registration and login using Identity.
- User profile with personal information.

### Auctions
- Create new auctions with item descriptions and starting bids.
- View a list of available auctions.
- View detailed information for a single auction.
- Modify the description of auctions you've created.

### Bidding
- Place bids on auctions with a specified amount.
- Keep track of the highest bid on each auction.

### Auction History
- View a list of auctions you have created.
- See a list of auctions you have won as a user.

### Admin Features
- Admins can view a list of all users and their details.
- Admins can view a list of all auctions.
- Admins have the ability to remove auctions if necessary.

## Getting Started

To run the WebAuctions app on your local machine, follow these steps:

1. Clone the repository to your local environment.


2. Open the project in Visual Studio.

3. Configure the connection string in the appsettings.json file to point to your SQL database.

4. Build and run the application.

5. Register as a user or log in to access the full functionality.

## Technologies Used

- .NET Core
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- Identity Framework

## Contributors

- [Your Name]
- [Contributor 2]
- [Contributor 3]

## License

This project is licensed under the [License Name] - see the [LICENSE](LICENSE) file for details.

## Acknowledgments

- [Author's Acknowledgments]

Feel free to reach out to us if you have any questions or encounter any issues. Thank you for using the WebAuctions app!
