
## Package manager 
Add-Migration Initial -Context VirtoCommerce.CoreModule.Data.Repositories.CoreDbContext  -Verbose -OutputDir Migrations -Project VirtoCommerce.CoreModule.Data.PostgreSql -StartupProject VirtoCommerce.CoreModule.Data.PostgreSql  -Debug



### Entity Framework Core Commands
```
dotnet tool install --global dotnet-ef --version 6.*
```

**Generate Migrations**

```
dotnet ef migrations add Initial -- "{connection string}"
dotnet ef migrations add Update1 -- "{connection string}"
dotnet ef migrations add Update2 -- "{connection string}"
```

etc..

**Apply Migrations**

`dotnet ef database update -- "{connection string}"`
