# Conceptos de ASP core .NET C# POP

## Dependency injection

Es el uso de constructores para inicializar clases de una forma limpia y escalable

### Tipos de Injection en .NET

services.AddSingleton Es instanciado hasta que la aplicacion se para
service.AddScoped Its live in the Http recuest live , is use in the context of the request
service.AddTrasient is used like the scope but is not recommends for https endpoind methos

## Entities

Private
Protected
public defualt en C#
set get
Linq queries

ORM
Translate our code into SQL commands that update our tables in the database

Features

- Querying
- Change Tracking
- Saving
- Concurrency
- Transactions
- Catching
- BUilt in coventions
- Configurations
- Migrations

**_SQLite Provider_**

## Identity

## User table cryptography

Salt
Hash

Este tipo de encryptacion es para asegura

es un metodo estandar para generar constraseñas

## DTOs / Data Transfate Object

Sirve para mandar y recibir el cuerpo de un endpoint

validar datos antes

## JWT / JSON Token Authentication

Json web token

Tiene tres partes separadas por puntos

Header Tipo
payload Data
verify signature ID expiracion

Features:
No usa sessiones no session manage
Portable means podemos usar entre webservices
performance

Nuget Package System.IdentityModel.Tokens.Jwt
https://jwt.io/
validate token

## Authentication

.Net Core
[Authorize]
[AllowAnonymous]

## SOLID

### Single responsability principals

Crear a service to controller auth

## Entity Framework

### Define Tables

[Table("Photos")] This is to create a table without create a DbSet

```cs
 // File DataContext.cs
 public DbSet<AppUser> Users { get; set; }

```

### Relations ships

#### One to many

Below an simple example on one to many relation
User have many Photos

```cs
// Entity AppUser
public ICollection<Photo> Photos { get; set; }

// Entity Photo
public AppUser AppUser { get; set; }
public int AppUserId { get; set; }
```

#### Many to many

```cs
// Entity Userlike
 public class UserLike
    {
        public AppUser SourceUser { get; set; }
        public int SourceUserId { get; set; }

        public AppUser LikedUser { get; set; }
        public int LikedUserId { get; set; }
    }

// Entity AppUser Add this collections

// Relation many likes, from other users
public ICollection<UserLike> LikedByUsers { get; set; }

// Relation many likes, my likes
public ICollection<UserLike> LikedUsers { get; set; }

```

> [!IMPORTANT]
> Check the DataContext relation ships to run the migrations
> **/Users/issnoe/Matersoft/netCoreTraining/DatingApp/API/Data/DataContex.cs**

Update migrations

> dotnet ef migrations add Likes

### Queries

In base on Repository pattern

[_context] makes reference to the entities and the relation bewteen

so

[_context] could acces to all entititis just like this

```csharp

// Path full file /Users/issnoe/Matersoft/netCoreTraining/DatingApp/API/Data/DataContex.cs
_context.Likes.
_context.Users.
--->
// Examples methos
.FindAsync(...)
.Find(...)
.AsQueryable()
.Where(...)
.ProjectTo(...)
.Include(...)
.Select(...)

_context.
-->
.SaveChangesAsync()
.Entry(...)


```

####

### Queries Linq

This extencione methos are used to make queries with entities

```csharp
_context.Users.OrderBy(...)

.OrderBy(...)


```

#### Select where in Enumerable & Linq

```csharp

likes = likes.Where(like => like.SourceUserId == userId);
users = likes.Select(like => like.LikedUser);


```

### Conventions

### Relationships

## Patterns

### Repositoty Pattern

Description It is and a abstraction on the database

This is a layer to abtract the DbContext
Encaptuced the logig in one file
Reduce duplicate logic for other controllers
Share methos into diferente Controllers
Easy made Unit Test Using **MockRepository**

IN mandatory use Unit of work to to transactions

Example

```cs

// UserController
var user = UserRepo.GetUser()
// MessageController
var user = UserRepo.GetUser()
// LikesController
var user = UserRepo.GetUser()
// ??Controller
var user = UserRepo.GetUser()


// Repositpry

public User GetUser(){
    // As in the preview way that
    return context.User.Include(x=>x.Thing).FirstOrDefault();
}


```

#### Other example

##### Steps

###### Interface

```cs
// Convenction I<EntityName> PLURAL+ Repository

ILikesRepository.cs

Define methos to implement into the Reposotory class

```

###### Repository

In this clase is injected the context db or mapper or other service

```cs
// Convenction <EntityName> PLURAL + Repository

LikesRepository.cs

```

###### Setting on service

```cs
// In DataApp is on the extencion ApplicationServiceExtencions
services.AddScoped<ILikesRepository, LikesRepository>();
```

#### Install Auto mapper

This pacages is use to copy the Entitity into the DTO

Example
AppUser into MemberDto

Get with the name
AutoMapper

### Unit of Work
