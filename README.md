# ✅ TodoTracker

**TodoTracker** is a task management web application built using **ASP.NET Core MVC**, **Entity Framework Core**, and **Bootstrap 5**. It allows users to add, edit, categorize, complete, and delete tasks with a simple and responsive user interface.

---

## 📸 Screenshots

> Coming soon... *(screenshots to showcase UI)*

---

## 🔧 Features

- ✅ Create, edit, and delete tasks  
- 📂 Organize tasks into multiple categories  
- 🟢 Mark tasks as completed  
- 🗂 View all tasks with category tags  
- 🎨 Responsive Bootstrap 5 UI with icons and clean layout  
- 🕒 Dynamic footer year display

---

## 🧑‍💻 Tech Stack

- **ASP.NET Core MVC** (.NET 6+)
- **Entity Framework Core**
- **Bootstrap 5** & **Bootstrap Icons**
- **SQL Server / LocalDb**
- **Razor Views + ViewModels Pattern**

---

## 🚀 Getting Started

### Prerequisites

- [.NET SDK 6.0+](https://dotnet.microsoft.com/download)
- [SQL Server Express or LocalDb](https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb)



### Setup Instructions

1. **Clone the repository:**
   ```bash
   git clone https://github.com/Nirob-Barman/TodoTracker.git
   cd TodoTracker
	```

2. **Restore dependencies:**
   ```bash
   dotnet restore
	```

3. **Apply migrations and create the database:**
   ```bash
   dotnet ef database update
	```

4. **Run the project:**
   ```bash
   dotnet run
	```

5. **Open your browser and visit:**
   ```bash
   https://localhost:5001
	```

## 🔐 Configuration
Before running the project, make sure to set up your own `appsettings.json` file with the correct database connection string. For security, sensitive information like usernames and passwords should not be committed to version control.

A `sample.appsettings.json` file is included for reference. Create your actual `appsettings.json` in the project root like this:

<details>
<summary>Click to view sample.appsettings.json</summary>

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=YOUR_DATABASE_NAME;Trusted_Connection=True;User Id=YOUR_USERNAME;Password=YOUR_PASSWORD;TrustServerCertificate=True;"
  },
  "AllowedHosts": "*"
}
```

</details>
📝 Replace YOUR_SERVER_NAME, YOUR_DATABASE_NAME, YOUR_USERNAME, and YOUR_PASSWORD with your actual SQL Server values.


## 🗃 Project Structure
	```
	TodoTracker/
	├── Controllers/           # MVC Controllers
	├── Models/                # Data models
	├── ViewModels/            # Task & Category view models
	├── Views/                 # Razor views (CSHTML files)
	├── Data/                  # DbContext
	├── wwwroot/               # Static files (CSS, JS, icons)
	└── Program.cs             # Entry point
	```

## ✍️ Author

- 👤 **Nirob Barman**  
- 🌐 [medium.com/@nirob-barman](https://nirob-barman.medium.com/)

---

## 📄 License

This project is licensed under the [MIT License](LICENSE).

