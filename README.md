api_thieu_nhi  

Welcome to api_thieu_nhi, an ASP.NET Core Web API built to showcase my backend development skills for job applications.This project highlights my expertise in creating scalable, containerized RESTful APIs using .NET, Entity Framework Core, and Docker.

Project Overview
api_thieu_nhi is a RESTful Web API developed with ASP.NET Core on both Ubuntu with VS Code and Windows with Visual Studio CE , demonstrates my ability to implement secure authentication, efficient data handling, and containerized deployment for production-ready applications.
  
Features

Secure user authentication using JWT and ASP.NET Identity  
CRUD operations  
Interactive API documentation via Swagger UI  
Data persistence with Entity Framework Core and MSSQL  
Containerized deployment with Docker  
Unit testing with xUnit, Moq and Shouldly  

Tech Stack  

Backend: ASP.NET Core (.NET 9)  
Database: MSSQL  
ORM: Entity Framework Core  
Containerization: Docker  
Testing: xUnit, Moq, Shouldly  
Tools: Swagger, Git  

Installation
To set up the project locally, ensure you have Docker and Git installed, then follow these steps:  
git clone https://github.com/phuAnhh03/api_thieu_nhi.git  
cd api_thieu_nhi  

Prerequisites:

.NET 9 SDK and MSSQL (optional for non-Docker machines)  
Docker (Docker Desktop or Docker CLI)  

Usage
Build and run the API in a Docker container:  
docker build -t api_thieu_nhi -f src/api/Dockerfile .  
docker run -p 5145:8080 api_thieu_nhi  
  
Access the API:  

Swagger UI: http://localhost:5145/swagger  

To run locally without Docker:  
cd src/api  
dotnet run  

Contact  
Feel free to reach out:    

Email: [ducphubui623@gmail.com]  
Facebook: [www.facebook.com/devphu]  
