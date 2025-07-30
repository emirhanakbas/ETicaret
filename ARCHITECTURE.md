# Technical Architecture Documentation

## Project Overview

ETicaret API is a modern e-commerce backend system built with .NET 8.0, following Clean Architecture principles and Domain-Driven Design patterns.

## Architecture Layers

### 1. Domain Layer (`ETicaretAPI.Domain`)
**Purpose:** Contains enterprise business rules and entities

**Components:**
- **Entities:** Core business objects (Product, Customer, Order)
- **Value Objects:** Immutable objects representing concepts
- **Domain Events:** Business events that occur in the domain
- **Interfaces:** Contracts for repositories and services

**Key Files:**
```
ETicaretAPI.Domain/
├── Entities/
│   ├── Common/           # Base entity classes
│   ├── Customer.cs       # Customer entity
│   ├── Order.cs         # Order entity
│   └── Product.cs       # Product entity
└── ETicaretAPI.Domain.csproj
```

### 2. Application Layer (`ETicaret.Application`)
**Purpose:** Contains application business rules and orchestrates domain objects

**Components:**
- **Use Cases:** Application-specific business logic
- **DTOs:** Data Transfer Objects for API contracts
- **Interfaces:** Application service contracts
- **Validators:** Input validation logic
- **Mappers:** Object mapping configurations

### 3. Infrastructure Layer (`ETicaretApp.Infrastructure`)
**Purpose:** Implements external concerns like file systems, web services, email, etc.

**Components:**
- **External Services:** Third-party integrations
- **File Storage:** File upload/download handling
- **Email Services:** Email notification implementations
- **Logging:** Application logging infrastructure

### 4. Persistence Layer (`ETicaretApp.Persistence`)
**Purpose:** Implements data access and database concerns

**Components:**
- **DbContext:** Entity Framework database context
- **Repositories:** Data access implementations
- **Configurations:** Entity configurations
- **Migrations:** Database schema changes

**Key Files:**
```
ETicaretApp.Persistence/
├── Contexts/             # Database contexts
├── Migrations/           # EF Core migrations
├── Configurations.cs    # Entity configurations
├── DesignTimeDbContextFactory.cs
└── ServiceRegistration.cs
```

### 5. API Layer (`ETicaretAPI.API`)
**Purpose:** Entry point for the application, handles HTTP requests

**Components:**
- **Controllers:** API endpoints
- **Middleware:** Cross-cutting concerns
- **Configuration:** Application settings
- **Startup Logic:** Dependency injection setup

**Key Files:**
```
ETicaretAPI.API/
├── Controllers/          # (To be implemented)
├── Properties/
│   └── launchSettings.json
├── Program.cs           # Application entry point
├── appsettings.json     # Configuration
└── ETicaretAPI.API.csproj
```

## Dependency Flow

```
┌─────────────────┐
│   API Layer    │ ──┐
└─────────────────┘   │
                      ▼
┌─────────────────┐ ┌─────────────────┐
│Infrastructure   │ │  Application    │
│     Layer       │ │     Layer       │
└─────────────────┘ └─────────────────┘
          │                   │
          └─────────┬─────────┘
                    ▼
          ┌─────────────────┐
          │  Domain Layer   │
          └─────────────────┘
                    ▲
          ┌─────────────────┐
          │ Persistence     │
          │     Layer       │
          └─────────────────┘
```

## Technology Stack Details

### Core Framework
- **.NET 8.0:** Latest LTS version with performance improvements
- **ASP.NET Core:** Web API framework
- **C# 12:** Latest language features and nullable reference types

### Database & ORM
- **PostgreSQL 16:** Primary database
- **Entity Framework Core 9.0.7:** Object-Relational Mapping
- **Npgsql:** PostgreSQL provider for .NET

### Development Tools
- **Docker:** Containerization
- **Docker Compose:** Multi-container orchestration
- **Swagger/OpenAPI:** API documentation
- **pgAdmin 4:** Database administration

### Key NuGet Packages
```xml
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="9.0.7" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="9.0.7" />
<PackageReference Include="Swashbuckle.AspNetCore" Version="6.6.2" />
```

## Database Schema

### Current Entities

#### Customer
```csharp
public class Customer : BaseEntity
{
    public Guid Id { get; set; }
    public ICollection<Order> Orders { get; set; }
    public string Name { get; set; }
}
```

#### Product
```csharp
public class Product : BaseEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Stock { get; set; }
    public float Price { get; set; }
    public ICollection<Order> Orders { get; set; }
}
```

#### Order
```csharp
public class Order : BaseEntity
{
    public Guid Id { get; set; }
    public int CustomerId { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public Product Product { get; set; }
    public Customer Customer { get; set; }
}
```

## Configuration

### Database Connection
```json
{
  "ConnectionStrings": {
    "PostgreSQL": "User ID=admin;Password=123456;Host=localhost;Port=5432;Database=ETicaretAPIDb"
  }
}
```

### Docker Services
- **PostgreSQL:** Port 5432
- **pgAdmin:** Port 5050
- **API:** HTTPS 7071, HTTP 5071

## Development Workflow

### 1. Local Development Setup
```bash
# Start database
cd pg-setup
docker-compose up -d

# Run migrations
cd ETicaretAPI
dotnet ef database update --project ETicaretApp.Persistence --startup-project ETicaretAPI.API

# Start API
dotnet run --project ETicaretAPI.API
```

### 2. Adding New Features
1. Define entities in Domain layer
2. Create application services in Application layer
3. Implement data access in Persistence layer
4. Add API controllers in API layer
5. Update database with migrations

### 3. Database Migrations
```bash
# Add migration
dotnet ef migrations add MigrationName --project ETicaretApp.Persistence --startup-project ETicaretAPI.API

# Update database
dotnet ef database update --project ETicaretApp.Persistence --startup-project ETicaretAPI.API
```

## Best Practices Implemented

### 1. Separation of Concerns
- Each layer has a single responsibility
- Cross-cutting concerns handled by infrastructure
- Business logic isolated in domain layer

### 2. Dependency Inversion
- High-level modules don't depend on low-level modules
- Dependencies injected through interfaces
- Framework-independent business logic

### 3. Single Responsibility Principle
- Each class has one reason to change
- Small, focused methods and classes
- Clear naming conventions

### 4. Open/Closed Principle
- Open for extension, closed for modification
- Interface-based design
- Plugin architecture support

## Performance Considerations

### 1. Database Optimization
- Proper indexing strategy
- Efficient query patterns
- Connection pooling

### 2. API Performance
- Async/await throughout
- Minimal allocations
- Response caching where appropriate

### 3. Memory Management
- Disposable pattern implementation
- Avoiding memory leaks
- Efficient object lifecycle management

## Security Features

### 1. Current Security
- HTTPS enforcement
- Connection string protection
- Input validation

### 2. Planned Security Enhancements
- JWT authentication
- Role-based authorization
- API rate limiting
- Input sanitization
- SQL injection prevention

## Monitoring & Logging

### Current Implementation
- Built-in ASP.NET Core logging
- Development environment logging

### Planned Enhancements
- Structured logging with Serilog
- Application Performance Monitoring (APM)
- Health check endpoints
- Metrics collection

---

This architecture provides a solid foundation for building a scalable, maintainable e-commerce platform while following industry best practices and modern .NET development patterns.