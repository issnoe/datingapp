# CLI commands


**Get info**
dotnet --info
dotnet new -h 

new 
sln // New solution file

dotnet new mvc --auth Individual
dotnet new razorcomponent
dotnet new --help

## Git 

dotnet new gitignore

***Pasos para creat un API***

dotnet new sln 
dotnet new webapi -o API
dotnet sln add API/


# Extenciones

C #
Material Icon theme
nuget gallary
C # Extenciones
sqlite

**Custom syntasis**
go settings then search for private, write _
search this then disable


## Setting up
Auto save disabled

Setting : exclude 
**/bin
**/obj

***Run DatingApp**
cd API
dotnet run 
dotnet watch run 

Importante
dotnet dev-certs https --trust
Password:
A valid HTTPS certificate is already present.

## Install entitiframework

Steps : cmd p --- nuget --- search 

Nuget 
Microsoft.EntityFrameworkCore.Sqlite

> dotnet add /Users/issnoe/Matersoft/netCoreTraining/DatingApp/API/API.csproj package Microsoft.EntityFrameworkCore.Sqlite -v 3.1.8 -s https://api.nuget.org/v3/index.json 

Verificar en pack.josn 
API.csproj



## Dotnet Ef 

Description : Make Migrations 
https://www.nuget.org/packages/dotnet-ef/5.0.0-rc.1.20451.13



Install 
> dotnet tool install --global dotnet-ef --version 5.0.0-rc.1.20451.13
> dotnet tool install --global dotnet-ef --version 3.1.8

UNINSTALL
> dotnet tool uninstall --global dotnet-ef 
> dotnet tool uninstall --global dotnet-ef --version 3.1.8


NOTE: Important install Microsoft.EntityFrameworkCore.Design

Commands

> dotnet ef migrations add InitialCreate -o Data/Migrations
> dotnet ef migrations add UserPassword 

Enables these commonly used dotnet-ef commands:
dotnet ef migrations add 
dotnet ef migrations list
dotnet ef migrations script
dotnet ef dbcontext info
dotnet ef dbcontext scaffold
dotnet ef database drop
dotnet ef database update


dotnet ef migrations remove

[Crear Base de datos]

dotnet ef database update
