<!DOCTYPE html>
<html>
<head>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 20px;
        }

        h1 {
            color: #333;
        }

        h2 {
            color: #666;
        }

        p {
            color: #777;
        }

        .video-link {
            display: block;
            margin-top: 20px;
        }

        img {
            max-width: 100%;
            height: auto;
        }
    </style>
</head>
<body>
    <h1>WebAuctions App</h1>

    <h2>Video of Project</h2>
    <a href="https://www.youtube.com/watch?v=Tb82G0tqd3k" class="video-link">
        <img src="your-video-thumbnail-image-link-here.jpg" alt="WebAuctions App Video">
    </a>

    <h2>Project Overview</h2>
    <p>
        WebAuctions is a .NET web application that implements an online auction platform. It utilizes Identity for user authentication and a self-implemented SQL database from Visual Studio for managing auctions, bids, and items. This app allows users to list auctions, display individual auctions, modify auction descriptions, place bids on auctions, and view their own auctions and the auctions they have won. Additionally, administrators have the ability to view all users and auctions and remove auctions as needed.
    </p>

    <h2>Project Structure</h2>
    <p>
        The project follows the Model-View-Controller (MVC) architectural pattern and is organized as follows:
    </p>
    <ul>
        <li><strong>DB:</strong> The database layer where data storage and retrieval are managed.</li>
        <li><strong>InterfaceDB:</strong> The database interface, which defines the contract for data access.</li>
        <li><strong>Service:</strong> The service layer responsible for business logic and interacting with the database.</li>
        <li><strong>Service Interface:</strong> The service interface defining the contract for application services.</li>
        <li><strong>Controller:</strong> The controller layer for handling HTTP requests and controlling the application's flow.</li>
    </ul>
    
    <h2>Features</h2>
    <!-- Add feature descriptions here -->

    <h2>Getting Started</h2>
    <p>
        To run the WebAuctions app on your local machine, follow these steps:
    </p>
    <ol>
        <li>Clone the repository to your local environment.</li>
        <li>Open the project in Visual Studio.</li>
        <li>Configure the connection string in the appsettings.json file to point to your SQL database.</li>
        <li>Build and run the application.</li>
        <li>Register as a user or log in to access the full functionality.</li>
    </ol>

    <h2>Technologies Used</h2>
    <ul>
        <li>.NET Core</li>
        <li>ASP.NET Core MVC</li>
        <li>Entity Framework Core</li>
        <li>SQL Server</li>
        <li>Identity Framework</li>
    </ul>

    <h2>Contributors</h2>
    <ul>
        <li>Samuel Tegsten</li>
        <li>Esteban Masaya</li>
    </ul>
</body>
</html>
