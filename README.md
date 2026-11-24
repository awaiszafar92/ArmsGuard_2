# ArmsGuard Frontend

ArmsGuard is a responsive ASP.NET Core MVC frontend for a weapon information, marketplace enquiry, and licensing information platform. It is an interactive demonstration only; all catalog entries, users, applications, and enquiries are fictional sample data.

## Software requirements

- Visual Studio Community 2026 (or a compatible Visual Studio version with ASP.NET and web development installed)
- .NET 10 SDK
- A modern browser

No database, SQL Server, or third-party online service is required. Bootstrap 5 and supporting browser libraries are included under `wwwroot/lib`.

## Open and run in Visual Studio

1. Extract the complete project folder from the ZIP.
2. Open `ARMSGUARD.slnx` (or `ARMSGUARD.sln` if using the generated traditional solution) in Visual Studio.
3. Allow NuGet dependency restore to complete. The project currently has no external NuGet package dependencies.
4. Set `ARMSGUARD` as the startup project if prompted.
5. Select the HTTPS or HTTP launch profile and press **F5** or **Ctrl+F5**.

The app can also be started from a terminal in the project directory:

```powershell
dotnet restore ARMSGUARD.csproj
dotnet run --project ARMSGUARD.csproj
```

Open the local address printed by `dotnet run`.

## Pages and routes

| Page | Route |
| --- | --- |
| Home | `/` or `/Home/Index` |
| Administrator demo login | `/Account/Login` |
| Signup validation demonstration | `/Account/Signup` |
| Weapon information catalog | `/Weapon/Catalog` |
| Weapon details | `/Weapon/Details/{id}` (sample IDs: `atlas-compact`, `ridgefield-sport`, `heritage-field`, `legacy-1874`) |
| Marketplace information | `/Marketplace` or `/Marketplace/Index` |
| Licensing information request | `/Licensing/Apply` |
| Application tracking | `/Licensing/Tracking` |
| Administrator dashboard | `/Admin/Dashboard` |

## Temporary administrator demonstration credentials

- Email: `admin@armsguard.local`
- Password: `GuardDemo!26`

The login is validated in browser JavaScript and stores a short-lived session flag in `sessionStorage` to demonstrate the dashboard navigation flow. The dashboard also checks that flag in browser JavaScript and returns unauthenticated visitors to the login page. These checks are deliberately not server-side security and can be bypassed; never use these credentials or checks to protect real data. The logout button clears the demonstration flag.

## Frontend-only behavior

- Signup and licensing forms validate in the browser and display a demonstration result; neither creates nor stores an account or application.
- Catalog search, category and manufacturer filters, sample details, enquiry notices, and tracking records work locally in the browser.
- Tracking references and dashboard records are fictional and do not relate to real people or official processes.
- Dashboard table search, sample status changes, record details, catalog/user demonstration controls, navigation, and logout are client-side only. Changes are not persisted.
- Marketplace enquiries are simulated requests for administrative and legal review only. The site does not offer sales, payments, delivery, ownership transfer, or transaction processing.
- All illustrations are local SVG assets. The interface does not require network-hosted images.

## Reserved for a future backend phase

This frontend does not implement database creation or connections, SQL/ADO.NET, Entity Framework database operations, APIs, ASP.NET Core Identity, real authentication or authorization, cookies/session-based accounts, persistent CRUD, file uploads, government license issuance, real purchase processing, payments, or transfers. Future work can introduce server-side view models, data services, parameterized SQL operations, secure authentication and authorization, and asynchronous persistence without changing the user-facing route structure.

## Project structure

- `Controllers/` — MVC page controllers
- `Models/` — fictional weapon reference records
- `Views/` — nine separate Razor pages and shared public, auth, and admin layouts
- `wwwroot/css/` — responsive public, auth, and dashboard styling
- `wwwroot/js/` — client-side demonstration interactions
- `wwwroot/images/` — local catalog illustrations

This project targets `net10.0` to match the existing workspace configuration.
