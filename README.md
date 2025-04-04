# ADPFA1
Municipality Management System
ASP.NET Core MVC
A web-based solution to streamline municipal services, built using ASP.NET Core MVC.

Table of Contents
About the Project
Features
Technologies Used
Setup Instructions
Database Design
Screenshots
Testing
Future Enhancements
License
About the Project
The Municipality Management System is a web application designed to manage citizens, service requests, staff, and reports in a municipal environment. It enables efficient administration and improves service delivery through a user-friendly interface and robust backend functionality.

Objectives
Provide tools for managing citizens and their information.
Enable citizens to submit and track service requests.
Maintain staff records and departmental organization.
Handle citizen-submitted reports and streamline their review process.
Features
1. Citizen Management
Add, edit, delete, and view citizens.
Manage citizen information, including name, address, email, and phone number.
2. Service Request Management
Submit and track service requests.
Update the status of service requests (e.g., Pending, In Progress, or Completed).
3. Staff Management
Add, edit, delete, and view staff records.
Manage staff details, including their position, department, and contact information.
4. Reports Management
Submit reports for municipal issues.
Review, update, and delete reports.
Technologies Used
Frontend: Razor Views, HTML, CSS, and Bootstrap.
Backend: ASP.NET Core MVC (C#).
Database: Microsoft SQL Server with Entity Framework Core.
Testing: xUnit, Moq, and Microsoft.EntityFrameworkCore.InMemory for unit and integration tests.
Setup Instructions
Prerequisites
.NET 6.0 SDK or later
Visual Studio 2022 or later
SQL Server (LocalDB or any SQL Server instance)
Steps
Clone the repository:
bash

Copy
git clone https://github.com/your-username/municipality-management-system.git
cd municipality-management-system
Open the project in Visual Studio.
Restore dependencies:
bash

Copy
dotnet restore
Update the database:
bash

Copy
dotnet ef database update
Run the application:
bash

Copy
dotnet run
Access the application in your browser at https://localhost:5001.
Database Design
Entity-Relationship Diagram (ERD)
The system includes the following entities:

Citizen
CitizenID (Primary Key)
FullName, Address, PhoneNumber, Email, DateOfBirth, RegistrationDate
ServiceRequest
RequestID (Primary Key)
CitizenID (Foreign Key)
ServiceType, RequestDate, Status
Staff
StaffID (Primary Key)
FullName, Position, Department, Email, PhoneNumber, HireDate
Report
ReportID (Primary Key)
CitizenID (Foreign Key)
ReportType, Details, SubmissionDate, Status
Screenshots
1. Home Page
Home Page

2. Citizen Management
Citizen Management

3. Service Request Management
Service Request Management

4. Staff Management
Staff Management

5. Report Management
Report Management

Testing
The project includes unit and integration tests for all major functionalities.

Test Frameworks
xUnit: For unit tests.
Moq: For mocking dependencies.
Microsoft.EntityFrameworkCore.InMemory: For in-memory database testing.
How to Run Tests
Open the Test Explorer in Visual Studio.
Click on Run All to execute the tests.
Review the test results.
Future Enhancements
Add real-time notifications for service request updates.
Integrate email notifications for citizen registration and service progress.
Implement advanced reporting and analytics for municipal operation
