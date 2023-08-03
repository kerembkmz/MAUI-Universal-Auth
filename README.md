# Login and Signup with GUI in .Net MAUI

This project is a Login and Signup system with user authentication using a MySQL database. The system allows users to register with their name, surname, email, username, password, and age. The passwords are securely stored in the database using the WarBCrypt library for hashing with salt and red pepper. The system validates user credentials during the login process.

## Prerequisites
Before running the application, ensure you have the following prerequisites:

1. .NET (DotNet) framework installed.
2. MySQL server installed.
3. The MySQL Connector/NET installed as a NuGet package in the project.
4. WarBCrypt library installed as a NuGet package.

## Database Setup

~To use the system, create a MySQL database named auth_schema. The query for creating the users table is:
CREATE TABLE users (
    id BIGINT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(256) NOT NULL,
    surname VARCHAR(256) NOT NULL,
    email VARCHAR(64) NOT NULL,
    username VARCHAR(256) NOT NULL,
    password VARCHAR(256) NOT NULL,
    age INT NOT NULL,
    salt VARCHAR(256) NOT NULL,
    redPepper VARCHAR(256) NOT NULL
);


### Usage
Clone the project or download the source files.
Open the project in your preferred IDE (e.g., Visual Studio).
Make sure the MySQL Connector/NET is installed as a NuGet package in the project.
Adjust the database connection parameters in the databaseService class constructor (connectionString) to match your MySQL server setup.
Build and run the application.

### Login
Launch the application and navigate to the Login page.
Enter your registered username and password.
Click the "Login" button.
If the credentials are correct, you will be logged in, and the system will display a success message.
If the credentials are incorrect, you will receive an error message.
### Signup
Navigate to the Signup page if you don't have an account yet.
Provide your name, surname, email, username, password, and age in the respective input fields.
Accept the rules by checking the checkbox.
Click the "Sign Up" button.
If the registration is successful, you will receive a success message, and your account will be added to the database.
If there are any errors during registration, you will receive an error message.

## Notes
The system uses the WarBCrypt library to securely hash passwords with salt and red pepper.
The databaseService class handles the communication with the MySQL database, including user registration and login.
The system uses a local MySQL server with credentials provided through allKeys.getDBUsername() and allKeys.getDBPassword(). You may need to adjust these to match your database setup.
It's important to keep the database connection secure and ensure proper access controls to protect user data.