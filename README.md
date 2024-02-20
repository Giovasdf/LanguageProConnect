# .NET Core API Project

This project is a .NET Core API for managing language-related data. It includes a seed function to populate initial data into the database.

## Database Setup

Before running the application, ensure you have set up the database and updated the connection string in the context file. You can seed the database with initial data by running the application.

### Seeding Data

To seed the database with initial data, you can use the following code snippet in your DbContext:

```csharp
dbContext.LanguageSpokens.AddRange(
    new LanguageSpoken { Id = Guid.NewGuid(), Name = "English" },
    new LanguageSpoken { Id = Guid.NewGuid(), Name = "Spanish" },
    new LanguageSpoken { Id = Guid.NewGuid(), Name = "Portuguese" }
);

dbContext.Schools.AddRange(
    new School { Id = Guid.NewGuid(), Name = "School Ireland", Country = "Ireland", City = "Limerick" },
    new School { Id = Guid.NewGuid(), Name = "Santiago Campus", Country = "Chile", City = "Santiago" },
    new School { Id = Guid.NewGuid(), Name = "Toronto College", Country = "Canada", City = "Toronto" }
);
```
Ensure to replace dbContext with your actual database context variable.

###Database Context
In the database context file, make sure to update the connection string to reflect your database setup. Additionally, you can modify the seeding logic according to your requirements.

###Run the Application
Once the database setup and seeding are complete, you can run the application to start using the API.
```bash
dotnet run
```
The API will be accessible at the specified endpoint, and you can begin making requests to manage language data.

Remember to adjust the instructions and code snippets according to your specific project structure and requirements.
