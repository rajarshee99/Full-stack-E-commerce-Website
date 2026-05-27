# 🛒 E-Commerce Website

A full-stack web application built with **ASP.NET Core MVC** and **Entity Framework Core**, featuring a dual-role system for Admins and Customers with session-based authentication, product management, and a session-powered shopping cart.

---

## 🚀 Features

### 👤 Customer
- Register and log in with email and password
- Browse all available products
- Add products to cart / remove items from cart
- View cart with total amount calculation

### 🔧 Admin
- Secure login (pre-seeded accounts via EF Core migrations)
- Full product CRUD — Create, Read, Edit, Delete
- Session-protected routes (redirects to login if unauthenticated)
- Logout functionality

---

## 🛠️ Tech Stack

| Layer | Technology |
|---|---|
| Framework | ASP.NET Core MVC (.NET 6+) |
| ORM | Entity Framework Core (Code First) |
| Database | Microsoft SQL Server |
| Session / State | ASP.NET Core Session + Newtonsoft.Json |
| View Engine | Razor Views |
| Frontend | HTML, CSS, Bootstrap (wwwroot) |

---

## 📁 Project Structure

```
E_commerce_website(final_project)/
├── Controllers/
│   ├── AdminController.cs       # Admin login / logout
│   ├── ProductController1.cs    # Product CRUD + Cart logic
│   ├── UserController.cs        # Customer registration, login, product listing
│   └── HomeController.cs        # Landing page
├── Models/
│   ├── admin.cs                 # Admin entity (email PK, password)
│   ├── customer.cs              # Customer entity (email PK, password, address)
│   ├── product.cs               # Product entity (id, name, qty, price, image)
│   └── projectcontext.cs        # EF Core DbContext with seed data
├── Views/                       # Razor views per controller
├── Migrations/                  # EF Core migration files
├── wwwroot/                     # Static assets (CSS, JS, images)
├── appsettings.json             # DB connection string config
└── Program.cs                   # App entry point and service registration
```

---

## ⚙️ Getting Started

### Prerequisites
- [.NET 6 SDK](https://dotnet.microsoft.com/download) or higher
- Microsoft SQL Server (local instance)
- Visual Studio 2022 (recommended) or VS Code

### Setup Steps

**1. Clone the repository**
```bash
git clone https://github.com/rajarshee99/Full-stack-E-commerce-Website.git
cd Full-stack-E-commerce-Website
```

**2. Configure the database connection**

Open `appsettings.json` and update the connection string to match your SQL Server instance:
```json
"ConnectionStrings": {
  "ecommercestring": "Data Source=YOUR_SERVER_NAME;Initial Catalog=e_commerce_project;Integrated Security=True;Encrypt=false"
}
```

**3. Apply migrations**
```bash
dotnet ef database update
```
This creates the database and seeds two default admin accounts (see below).

**4. Run the application**
```bash
dotnet run
```
Or press **F5** in Visual Studio.

---

## 🔐 Default Admin Credentials

These accounts are seeded automatically during migration:

| Email | Password |
|---|---|
| a@gmail.com | 1234 |
| b@gmail.com | 5678 |

> ⚠️ Change these credentials before deploying to production.

---

## 🗃️ Database Schema

### `admins`
| Column | Type | Notes |
|---|---|---|
| a_e_mail | VARCHAR(200) | Primary Key |
| a_password | VARCHAR(100) | |

### `customers`
| Column | Type | Notes |
|---|---|---|
| c_e_mail | VARCHAR(200) | Primary Key |
| c_password | VARCHAR(100) | |
| c_address | VARCHAR(200) | |

### `products`
| Column | Type | Notes |
|---|---|---|
| p_id | INT | Primary Key, Auto-increment |
| p_name | VARCHAR(200) | |
| p_qty | INT | |
| p_price | INT | |
| p_pic | VARCHAR | Image filename/path |

---

## 🛒 Cart Implementation

The cart is stored entirely in **ASP.NET Core Session** as a JSON-serialized `List<product>`. Each product in the cart tracks its own quantity (`p_qty`). No database table is needed — the cart persists for the duration of the user session.

---

## 📌 Known Limitations

- Passwords are stored in **plain text** — bcrypt hashing should be added before any production use.
- Cart total calculation has a minor bug (multiplicative total resets each loop iteration instead of accumulating).
- No payment gateway integration.
- Image upload is modelled but upload/save logic may need completion.

---

## 🤝 Contributing

Pull requests are welcome. For major changes, open an issue first to discuss what you'd like to change.

---

## 📄 License

This project is open source and available under the [MIT License](LICENSE).
