# Dating app

## Run DatingApp

cd API
dotnet run  
dotnet watceht

Importante
dotnet dev-certs https --trust
Password:
A valid HTTPS certificate is already present.
https://localhost:5001/weatherforecast

## Migrations

Inicialized a migration

> dotnet ef migrations add InitialCreate -o Data/Migrations

Add here is like update the database migration OR ->

> dotnet ef migrations add UserPassword

OR When you update the entitities folder you should run this command

> dotnet ef migrations add <Name or description>

When you want to quit the last

> dotnet ef migrations remove

## Migration Update DataBase

> dotnet ef database update
> dotnet ef database drop

## Database

## Seed
