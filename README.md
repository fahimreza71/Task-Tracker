# Task Tracker

A web-based task tracking application built with ASP.NET Core that helps users manage their tasks and to-dos.

## Tech Stack

- **Frontend**: .NET Core Razor Pages with Bootstrap
- **Backend**: ASP.NET Core
- **Database**: MSSQL Server
- **Design Pattern**: MVC (Model-View-Controller)
- **ORM**: Entity Framework Core
- **Framework**: .NET 8.0

## Features

- Secure login and registration using ASP.NET Core Identity
- Task Management (Add, Update, Delete)
- Filter tasks by completion status
- Sort tasks by due date (ascending or descending)
- Admin can
  - View all registered users
  - See all tasks of any user
  - Edit or delete user's details

## Project Structure

```
Task-Tracker/
├── Areas/                  # Areas for Identity
│   └── Identity/          # Identity related views and pages
│
├── Controllers/           # MVC Controllers
│   ├── HomeController.cs
│   ├── TasksController.cs
│   └── AdminController.cs
│
├── Data/                  # Database context and configurations
│   ├── ApplicationDbContext.cs
│
├── Interfaces/           # Interface definitions
│   ├── ITaskService.cs
|   └── IAdminService.cs
│
├── Models/               # Data models
│   ├── TaskItem.cs      # Task entity model
│   └── AppUser.cs       # User model extended identity
│
├── Services/             # Business logic services
│   ├── TaskService.cs
|   └── AdminService.cs
│
├── Views/                # MVC Views
│   ├── Tasks/           # Task-related views
│   ├── Home/            # Home page views
│   ├── Admin/           # Admin panel views
│   ├── Shared/          # Shared layouts and partials
│   ├── _ViewStart.cshtml
│   └── _ViewImports.cshtml
│
├── wwwroot/             # Static files
├── Migrations/          # Database migrations
├── Program.cs          # Application entry point
├── appsettings.json    # Application settings
└── TaskTracker.csproj  # Project file
```

## Setup Instructions

### Prerequisites
1. .NET 8.0 SDK
2. SQL Server 2019 or later
4. Visual Studio 2022 or VS Code

### Clone this repository
```bash
   git clone https://github.com/fahimreza71/Task-Tracker.git
```

### Database Setup
1. Update connection string in `appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=YOUR-SERVER-NAME;Database=TaskTrackerDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true"
     }
   }
   ```
2. Run migrations:
   ```bash
   dotnet ef database update
   ```

### Development Setup

```bash
# Restore dependencies
dotnet restore

# Build & Run
dotnet build
dotnet run
```

## Known Issues and Incomplete Features

1. **Incomplete CSS**
   - Current styling is basic and needs improvement
   - Responsive design needs enhancement

3. **Real-time Updates**
   - Currently requires page reload for updates
   - Could implement real-time changes using JavaScript

4. **Identity Features**
   - Login/registration & Role-based authorization implemented
   - Potential improvements:
     - Social media authentication
     - Two-factor authentication
     - Password recovery
     - User profile management
