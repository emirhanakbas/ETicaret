# ETicaret API - E-Commerce Backend System

## Programming Language Selection / Programlama Dili Seçimi

This document explains the technology stack and programming language choices made for this e-commerce API project.

### Technology Stack / Teknoloji Yığını

#### Core Framework / Ana Framework
- **Language:** C# (.NET 8.0)
- **Framework:** ASP.NET Core Web API
- **Architecture:** Clean Architecture (Onion Architecture)

#### Database / Veritabanı
- **Database:** PostgreSQL 16
- **ORM:** Entity Framework Core 9.0.7
- **Migration Support:** Code-First Migrations

#### Development Tools / Geliştirme Araçları
- **Container:** Docker & Docker Compose
- **API Documentation:** Swagger/OpenAPI
- **Database Admin:** pgAdmin 4

### Why C# and .NET 8? / Neden C# ve .NET 8?

#### 1. **Performance / Performans**
- .NET 8 offers excellent performance for web APIs
- Compiled language with optimized runtime
- Minimal memory footprint and fast startup times

#### 2. **Enterprise-Ready / Kurumsal Hazır**
- Mature ecosystem with extensive libraries
- Strong typing system reduces runtime errors
- Excellent tooling and IDE support (Visual Studio, VS Code)

#### 3. **Scalability / Ölçeklenebilirlik**
- Built-in support for microservices architecture
- Excellent asynchronous programming model
- Container-ready with Docker support

#### 4. **Security / Güvenlik**
- Built-in security features
- Regular security updates from Microsoft
- Strong authentication and authorization mechanisms

#### 5. **Cross-Platform / Çapraz Platform**
- Runs on Windows, Linux, and macOS
- Cloud-ready (Azure, AWS, Google Cloud)
- Docker containerization support

### Project Architecture / Proje Mimarisi

```
ETicaretAPI/
├── ETicaretAPI.API/           # Presentation Layer - API Controllers
├── ETicaret.Application/      # Application Layer - Business Logic
├── ETicaretAPI.Domain/        # Domain Layer - Entities & Contracts
├── ETicaretApp.Infrastructure/ # Infrastructure Layer - External Services
└── ETicaretApp.Persistence/   # Persistence Layer - Database Access
```

#### Clean Architecture Benefits / Temiz Mimari Avantajları
- **Separation of Concerns:** Each layer has distinct responsibilities
- **Testability:** Easy to unit test business logic
- **Maintainability:** Changes in one layer don't affect others
- **Independence:** Domain logic is independent of frameworks

### Database Choice: PostgreSQL / Veritabanı Seçimi: PostgreSQL

#### Why PostgreSQL? / Neden PostgreSQL?
- **Open Source:** No licensing costs
- **ACID Compliance:** Reliable transactions
- **JSON Support:** Modern data types for flexible schemas
- **Performance:** Excellent for read and write operations
- **Extensibility:** Rich ecosystem of extensions

### Development Setup / Geliştirme Ortamı Kurulumu

#### Prerequisites / Ön Gereksinimler
- .NET 8.0 SDK
- Docker & Docker Compose
- Visual Studio 2022 or VS Code

#### Getting Started / Başlangıç

1. **Clone the repository / Repoyu klonlayın:**
   ```bash
   git clone https://github.com/emirhanakbas/ETicaret.git
   cd ETicaret
   ```

2. **Start the database / Veritabanını başlatın:**
   ```bash
   cd pg-setup
   docker-compose up -d
   ```

3. **Run database migrations / Veritabanı migrasyonlarını çalıştırın:**
   ```bash
   cd ETicaretAPI
   dotnet ef database update --project ETicaretApp.Persistence --startup-project ETicaretAPI.API
   ```

4. **Run the API / API'yi çalıştırın:**
   ```bash
   cd ETicaretAPI
   dotnet run --project ETicaretAPI.API
   ```

5. **Access the API / API'ye erişin:**
   - API: https://localhost:7071
   - Swagger Documentation: https://localhost:7071/swagger
   - pgAdmin: http://localhost:5050 (admin@admin.com / admin123)

### API Endpoints / API Uç Noktaları

The API follows RESTful conventions and includes:
- Product management
- Customer management  
- Order processing
- Full CRUD operations for all entities

### Database Connection / Veritabanı Bağlantısı

```json
{
  "ConnectionStrings": {
    "PostgreSQL": "User ID=admin;Password=123456;Host=localhost;Port=5432;Database=ETicaretAPIDb"
  }
}
```

### Future Considerations / Gelecek Planları

1. **Authentication & Authorization** - JWT implementation
2. **Caching** - Redis integration
3. **Logging** - Structured logging with Serilog
4. **API Versioning** - Support for multiple API versions
5. **Rate Limiting** - API throttling mechanisms
6. **Health Checks** - Monitoring endpoints

### Contributing / Katkıda Bulunma

1. Fork the project
2. Create a feature branch
3. Make your changes
4. Add tests if applicable
5. Submit a pull request

### License / Lisans

This project is licensed under the MIT License.

---

**Note:** This technology stack was chosen to provide a robust, scalable, and maintainable foundation for an e-commerce platform while leveraging modern development practices and tools.

**Not:** Bu teknoloji yığını, modern geliştirme pratiklerini ve araçlarını kullanarak e-ticaret platformu için sağlam, ölçeklenebilir ve sürdürülebilir bir temel sağlamak amacıyla seçilmiştir.