# **ReadilyAPI - Online Bookstore API**

## **Installation Instructions**

Follow these steps to set up and run the project on your local machine:

### **Prerequisites**

Make sure you have the following installed on your machine:

- .NET 8 SDK
- SQL Server or SQL Server Express (for local development)
- Any preferred IDE (e.g., Visual Studio, VS Code)

### **1. Clone the Repository**

Clone this repository to your local machine:
```sh
git clone https://github.com/NikolaSamardzic/ReadilyAPI.git
cd .\ReadilyAPI
```
### **2. Configure appsettings.json**

Before running the project, you'll need to configure the `appsettings.json` file.
##### **Copy the example configuration**:

Copy `appsettings.example.json` to `appsettings.json`:
```sh
cd .\ReadilyAPI.API\
cp appsettings.example.json appsettings.json
```

##### **Edit appsettings.json**:

 Open `appsettings.json` in your preferred text editor and replace the placeholder values with your actual configuration:
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "Jwt": {
    "SecretKey": "<your-jwt-secret-key>",
    "DurationSeconds": 600,
    "Issuer": "Readily"
  },
  "SmtpSettings": {
    "Server": "smtp.gmail.com",
    "Port": 587,
    "SenderName": "Readily",
    "SenderEmail": "<your-sender-email>",
    "Username": "<your-smtp-username>",
    "Password": "<your-smtp-password>",
    "EnableSsl": true
  }
}
```

### **3. Update the Database**

Before applying migrations, ensure that the database has been created in SQL Server:
##### **Create the Database**:

- Open SQL Server Management Studio (SSMS) or your preferred SQL management tool.
 - Create a new database with the name Readily
##### **Apply the Migrations**:

 After creating the database, run the following command in the terminal to apply the migrations and update the database schema:
```sh
cd .\ReadilyAPI.DataAccess\
dotnet ef database update
```

This will apply the existing migrations and create the necessary database tables.

### **4. Run the Project**

Now that the database is ready, you can run the project using the following command:
```sh
cd ..
cd .\ReadilyAPI.API\
dotnet run
```

Once the project is running, the API will be available at `http://localhost:<port>`.

### **5. Seed the Database (Optional)**

After updating the database, you can seed the database with default data by hitting the following endpoint:
```sh
http://localhost:<port>/api/databaseseed
```
> Replace `<port>` with the actual port your application is running on.

### **6. API Documentation**

For detailed documentation on the API's endpoints, please visit the project's [Wiki](https://github.com/NikolaSamardzic/ReadilyAPI/wiki).