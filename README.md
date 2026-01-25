# HajjSystem - Hajj Management System

A comprehensive ASP.NET Core 8.0 Web API for managing Hajj operations including registrations, users, companies, locations, vehicles, airline routes, and meal services.

## Prerequisites

- .NET 8.0 SDK
- PostgreSQL 14.5+
- Entity Framework Core Tools

## Project Structure

```
Sources/
├── HajjSystem.Models/          # Domain entities and DTOs
│   ├── Entities/               # Database entities
│   ├── Enums/                  # Enumerations
│   └── Models/                 # Data transfer objects
├── HajjSystem.Data/            # Data access layer
│   ├── Configurations/         # EF Core configurations
│   ├── Migrations/             # Database migrations
│   └── Repositories/           # Repository implementations
├── HajjSystem.Services/        # Business logic layer
│   └── Services/               # Service implementations
└── HajjSystem.Webapi/          # REST API controllers
    └── Controllers/            # API endpoints

inset_sql/                      # Database seed scripts
Tests/                          # Unit and integration tests
```

## Database Setup

### Connection Configuration

Update connection strings in:
- `Sources/HajjSystem.Webapi/appsettings.json`
- `Sources/HajjSystem.Webapi/appsettings.Development.json`

Default connection:
```json
"ConnectionStrings": {
  "HajjSystemConnectionString": "Host=127.0.0.1;Port=7074;Database=db1;Username=user1;Password=password1"
}
```

### Database Migrations

Navigate to the Data project:
```bash
cd Sources/HajjSystem.Data
```

Create a new migration:
```bash
dotnet ef migrations add MigrationName --startup-project ../HajjSystem.Webapi
```

Apply migrations to database:
```bash
dotnet ef database update --startup-project ../HajjSystem.Webapi
```

List all migrations:
```bash
dotnet ef migrations list --startup-project ../HajjSystem.Webapi
```

Remove last migration (if not applied):
```bash
dotnet ef migrations remove --startup-project ../HajjSystem.Webapi
```

### Drop All Tables

To reset the database:
```bash
cd /Volumes/development/hulul-workspace/HajjSystem
PGPASSWORD=password1 psql -h 127.0.0.1 -p 7074 -U user1 -d db1 -f inset_sql/DropAllTables.sql
```

### Seed Data

Insert default roles:
```bash
PGPASSWORD=password1 psql -h 127.0.0.1 -p 7074 -U user1 -d db1 -f inset_sql/RoleInsert.sql
```

Insert airline routes (6,726 airports):
```bash
PGPASSWORD=password1 psql -h 127.0.0.1 -p 7074 -U user1 -d db1 -f inset_sql/AirlineRouteInsert.sql
```

## Running the Application

### Build the solution:
```bash
dotnet build HajjSystem.sln
```

### Run the Web API:
```bash
cd Sources/HajjSystem.Webapi
dotnet run
```

### Run with hot reload:
```bash
dotnet watch run
```

### Access Swagger UI:
```
http://localhost:5116/swagger/index.html
```

## Docker Deployment

### Standard deployment:
```bash
docker-compose up -d
```

### Hot-reload development:
```bash
docker-compose -f docker-compose-hot-reload.yml up
```





## Notes

- Database uses PostgreSQL with Npgsql provider
- All migrations are in `HajjSystem.Data/Migrations/`
- Seed scripts are in `inset_sql/` directory
- Connection string must be updated in both appsettings.json files
- Role names are unique with database constraint