# Touristic Management System - EgyXplore

## 1. Project Overview
EgyXplore is a comprehensive Touristic Management System designed to gamify and enhance the tourist experience in Egypt. 

**The problem it addresses:** 
Tourists often lack a structured, engaging way to explore historical sites and destinations. Traditional tourism apps provide information but fail to incentivize exploration and engagement.

**The purpose of the application:**
To provide a platform where tourists can plan trips, visit destinations, complete specific missions at those locations, earn points, and redeem those points for real-world rewards provided by sponsors.

**Main users/use cases:**
- **Tourists:** Can browse destinations, plan trips, complete missions, and redeem rewards.
- **Administrators:** Can manage destinations, missions, sponsors, rewards, and oversee user activity.

## 2. System Objectives
- **Gamification of Tourism:** Encourage exploration through a point-based mission system.
- **Trip Planning:** Allow tourists to organize and schedule their visits to various destinations.
- **Reward System:** Create an ecosystem where tourists are rewarded for their engagement by partnering with local sponsors.
- **Centralized Management:** Provide an administrative backend to manage the core data (destinations, sponsors, rewards, missions).

## 3. My Contribution
**Note: This Touristic Management System was built collaboratively as a team project.**

My specific contribution focused primarily on the **Sponsors Module**, which is a critical part of the reward ecosystem. My responsibilities included:
- **Sponsors Model:** Designing and implementing the data structure for sponsors.
- **Sponsors Controller:** Developing the business logic and routing for sponsor management.
- **Sponsors Views:** Creating the user interface for displaying, creating, editing, and deleting sponsors.
- **Sponsor Repository:** Implementing the data access layer for the Sponsors module using the generic repository pattern.

## 4. Technologies
The project was built using the following technologies:
- **ASP.NET Core MVC** (Framework)
- **C#** (Backend logic)
- **Entity Framework Core** (ORM)
- **SQL Server** (Database)
- **HTML & CSS** (Markup and styling, including a custom Egyptian theme)
- **Bootstrap 5** (Responsive UI framework)
- **JavaScript** (Frontend interactivity)

## 5. System Architecture
The application follows a standard **Model-View-Controller (MVC)** architecture.

- **Models:** Define the domain entities (e.g., Tourist, Destination, Sponsor, Reward) and database schema.
- **Views:** Razor pages (`.cshtml`) that render the UI using HTML/CSS/Bootstrap, receiving data from controllers.
- **Controllers:** Handle incoming HTTP requests, interact with repositories to fetch/modify data, and return appropriate views.
- **Data Access (Repositories):** A generic repository pattern is used alongside specialized repositories (e.g., `SponsorRepository`) to abstract Entity Framework Core interactions from the controllers.

**Data Flow:**
1. A user interacts with a View (e.g., clicks "Sponsors").
2. The request is routed to the corresponding Controller (`SponsorController`).
3. The Controller calls the Repository layer to fetch data from the SQL Server Database via EF Core.
4. The Controller passes the retrieved data to a View Model or directly to the View.
5. The View renders the HTML and returns it to the user.

## 6. Sponsors Module (My Contribution)
The Sponsors module is designed to manage the entities that provide rewards to tourists. 

- **Purpose:** To maintain a directory of partners (hotels, airlines, agencies) who offer tangible rewards in exchange for points earned by tourists.
- **Sponsor Data Model:** Contains properties such as `Id`, `Name`, `Type` (e.g., Hotel, Airline), `Address`, and `ContactNumber`. It also maintains a one-to-many relationship with the `Reward` entity.
- **Controller Responsibilities (`SponsorController`):** 
  - Handles the Index view with filtering capabilities (by name or type).
  - Handles the Details view to show sponsor information and their associated rewards.
  - Manages Admin-only operations for creating, editing, and deleting sponsors.
- **Views:** Built using Razor syntax, integrating with the project's custom Egyptian theme and Bootstrap for responsiveness. Forms include client-side and server-side validation.
- **CRUD Operations:** Full Create, Read, Update, and Delete operations were implemented. Create, Edit, and Delete are protected by `[Authorize(Roles = "Admin")]`.
- **Database Interaction:** Handled through the `ISponsorRepository` and `SponsorRepository`, utilizing EF Core to query the `Sponsors` DbSet.

## 7. Database
The database is managed using **Entity Framework Core** with a Code-First approach.

- **Relevant Tables:** `Sponsors`, `Rewards`, `Tourists`, `Destinations`, `TripPlans`, `Missions`, `UserMissions`, `Redemptions`.
- **Important Relationships:** 
  - **Sponsor (1) to Rewards (Many):** A sponsor can offer multiple rewards.
  - Tourist (1) to Redemptions (Many).
  - Destination (1) to Missions (Many).
- **EF Core Usage:** The `TouristContext` configures the database schema and includes extensive seed data to populate initial destinations, tourists, sponsors, and missions.
- **Sponsor Interaction:** The `Sponsors` table stores the core details. When querying a sponsor's details, `.Include(s => s.Rewards)` is used to eagerly load the associated rewards.

## 8. Key Features
**Overall System Features (Team):**
- Tourist authentication and role management (Admin/User).
- Destination catalog with categorization and visit tracking.
- Trip planning capabilities for tourists.
- Mission assignment and point accumulation system.
- Reward redemption system using earned points.

**My Specific Features (Sponsors Module):**
- Comprehensive Sponsor directory with search and filter functionality.
- Admin dashboard for managing sponsor partnerships.
- Integration between Sponsors and the Rewards system, allowing the platform to link specific rewards to their providing partners.

## 9. Screenshots

*(Replace the placeholder links below with actual screenshots of the application)*

### Sponsors Directory
![Sponsors Index](path/to/sponsor-index-screenshot.png)

### Sponsor Details
![Sponsor Details](path/to/sponsor-details-screenshot.png)

### Admin: Add/Edit Sponsor
![Edit Sponsor](path/to/sponsor-edit-screenshot.png)

### Overall Application (Home)
![Home Page](path/to/home-page-screenshot.png)
