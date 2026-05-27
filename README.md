<div align="center">

# 🛒 Full-Stack E-Commerce Website

**A dual-role e-commerce platform with product management, session-based auth, and a live shopping cart.**

<br/>

![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-MVC-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![Entity Framework](https://img.shields.io/badge/Entity_Framework_Core-Code_First-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)
![Bootstrap](https://img.shields.io/badge/Bootstrap-7952B3?style=for-the-badge&logo=bootstrap&logoColor=white)
![Razor](https://img.shields.io/badge/Razor_Views-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Newtonsoft](https://img.shields.io/badge/Newtonsoft.Json-Session_Cart-black?style=for-the-badge)

</div>

---

## 🏗️ Architecture

```
┌─────────────────────────────────────────────────────────────┐
│                         Browser                             │
└────────────────────┬────────────────────┬───────────────────┘
                     │                    │
           ┌─────────▼──────┐   ┌─────────▼──────┐
           │   Customer     │   │     Admin       │
           │   Flow         │   │     Flow        │
           └─────────┬──────┘   └─────────┬───────┘
                     │                    │
           ┌─────────▼──────┐   ┌─────────▼───────┐
           │ Register/Login │   │  Login (seeded) │
           │ UserController │   │ AdminController │
           └─────────┬──────┘   └─────────┬───────┘
                     │                    │
           ┌─────────▼──────┐   ┌─────────▼───────┐
           │ Browse Products│   │  Product CRUD   │
           │ Add / Remove   │   │  Create, Edit,  │
           │ Cart (Session) │   │  Delete, List   │
           └─────────┬──────┘   └─────────┬───────┘
                     │                    │
           └─────────────────┬────────────┘
                             │
                  ┌──────────▼──────────┐
                  │  EF Core (Code First)│
                  │   projectcontext    │
                  └──────────┬──────────┘
                             │
                  ┌──────────▼──────────┐
                  │   SQL Server DB     │
                  │  admins | customers │
                  │      products       │
                  └─────────────────────┘
```

> **Session Layer:** Both roles use `HttpContext.Session` for auth state. The cart is stored as a JSON-serialized `List<product>` in session — no extra DB table needed.

---

## ✨ Features

### 👤 Customer
- Register and log in with email + password
- Browse full product catalogue
- Add to cart / remove from cart
- View cart with live total amount

### 🔧 Admin
- Secure login with pre-seeded credentials
- Create, Edit, Delete, and List products
- Session-protected routes — auto-redirect to login if unauthenticated
- Logout

---

## 📁 Project Structure

```
Full-stack-E-commerce-Website/
├── Controllers/
│   ├── AdminController.cs        # Admin login / logout
│   ├── ProductController1.cs     # Product CRUD + cart operations
│   ├── UserController.cs         # Customer register, login, product view
│   └── HomeController.cs         # Public landing page
├── Models/
│   ├── admin.cs                  # Admin entity  (email PK)
│   ├── customer.cs               # Customer entity (email PK, address)
│   ├── product.cs                # Product entity (id, name, qty, price, image)
│   └── projectcontext.cs         # EF Core DbContext + seed data
├── Views/                        # Razor views per controller
├── Migrations/                   # EF Core migration history
├── wwwroot/                      # Static assets — CSS, JS, images
├── appsettings.json              # Connection string config
└── Program.cs                    # Service registration + middleware pipeline
```

---

## ⚙️ Getting Started

### Prerequisites
- [.NET 6 SDK](https://dotnet.microsoft.com/download) or higher
- Microsoft SQL Server (local instance)
- Visual Studio 2022 or VS Code

### Setup

```bash
# 1. Clone
git clone https://github.com/rajarshee99/Full-stack-E-commerce-Website.git
cd Full-stack-E-commerce-Website

# 2. Update connection string in appsettings.json
# "ecommercestring": "Data Source=YOUR_SERVER;Initial Catalog=e_commerce_project;Integrated Security=True;Encrypt=false"

# 3. Apply migrations (creates DB + seeds admin accounts)
dotnet ef database update

# 4. Run
dotnet run
```

---

## 🔐 Default Admin Credentials

> Seeded automatically via `OnModelCreating` in `projectcontext.cs`

| Email | Password |
|---|---|
| a@gmail.com | 1234 |
| b@gmail.com | 5678 |

> ⚠️ Change these before any production deployment.

---

## 🗃️ Database Schema

### `admins`
| Column | Type | Constraint |
|---|---|---|
| a_e_mail | VARCHAR(200) | PK |
| a_password | VARCHAR(100) | Required |

### `customers`
| Column | Type | Constraint |
|---|---|---|
| c_e_mail | VARCHAR(200) | PK |
| c_password | VARCHAR(100) | Required |
| c_address | VARCHAR(200) | Required |

### `products`
| Column | Type | Constraint |
|---|---|---|
| p_id | INT | PK, Auto-increment |
| p_name | VARCHAR(200) | Required |
| p_qty | INT | Required |
| p_price | INT | Required |
| p_pic | VARCHAR | Optional (image path) |

---

## 📌 Known Limitations

- Passwords stored in plain text — `BCrypt` hashing recommended before production use
- No payment gateway integration
- Image upload is modelled (`IFormFile`) but save logic needs completion

---

## 📄 License

This project is open source and available under the [MIT License](LICENSE).
