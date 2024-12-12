# StirCraft - A Cooking Recipe Web Application

Welcome to **StirCraft**, a web application designed for amateur hobbyist cooks to explore, share, and interact with recipes. The app combines features of social engagement, creativity, and gamification to make cooking a fun and collaborative experience.
The project is developed during the ASP.NET Advanced course in Soft Uni and after its presentation will be further developed.

---

## Table of Contents

1. [About the Project](#about-the-project)
2. [Features](#features)
3. [Tech Stack](#tech-stack)
4. [Getting Started](#getting-started)
5. [Folder Structure /Project Structure](#folder-structure)
6. [Database Design](#database-design)
7. [Gamification System](#gamification-system)
8. [Security Features](#security-features)
9. [Testing](#testing)
10. [License](#license)

---

## About the Project

**StirCraft** is a web application that allows users to:

- Browse, filter, and explore recipes.
- Interact with other users by favoriting, commenting, and rating recipes.
- Upload their own recipes and photos of meals.
- Gain ranks and points through active participation.

Admins manage content quality by reviewing and approving new recipes and ingredients.

---

## Features

### For Non-Logged Users

- Browse recipes and cooks.
- Browse ingredients and filter them by name and/or being allergen, browsing recipes that have said ingredient
- Filter recipes by category, name, ingredients, or likes.
- Filter cooks by name and rank.

### For Users

- All of the above that is available to non logged user and more:
- Comment on recipes, edit their comments and delete them
- Reply to comments, edit their replies and delete them
- Apply to become cook
- Change avatar
- Rate recipes - unique action to regular users
- Like recipes - liking a recipe adds it to a list of favorites, unique action to regular users

### For Cooks

- All of the above that is available to logged and non logged users except for recipe like and rating, but also:
- Add recipes and upload meal photos.
- Edit and delete existing recipes they created
- Suggest new ingredients to enrich the ingredient database.

### For Admins

- Approve or reject new recipes and ingredients.
- Admins cannot comment, reply to comment, like or rate recipe

---

## Tech Stack

### Backend:

- **Framework:** ASP.NET Core Web API (.NET 8.0)
- **Database:** Microsoft SQL Server
- **ORM:** Entity Framework Core
- **Authentication:** ASP.NET Identity
- **Patterns:** Unit of Work, Repository, Specification
- **Programming Language:** C#

### Frontend:

- **Framework:** Angular 18
- **Styling:** Angular Material with Tailwind

### Tools:

- **IDE:** Visual Studio 2022 or JetBrains Rider
- **Version Control:** Git and GitHub
- **Testing:** xUnit for unit tests

---

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/) (8.0)
- [Node.js](https://nodejs.org/) (LTS version recommended)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/)
- [Angular CLI](https://angular.io/cli)

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/DenitsaBebrevenska/StirCraftApp.git
   ```

2. Navigate to the project directory:

   ```bash
   cd stircraft
   ```

3. Set up the backend:

   ```bash
   cd StirCraftApp.Api
   dotnet restore
   dotnet run
   ```

4. Set up the frontend:

   ```bash
   cd StirCraftApp.ClientApp
   npm install
   ng serve
   ```

5. Access the app at `https://localhost:4200`.

---

## Folder Structure

```
StirCraftApp/
├── StirCraftApp.Api/            # Backend API
├── StirCraftApp.Application/    # Application logic and services
├── StirCraftApp.Domain/         # Domain entities and business rules
├── StirCraftApp.Infrastructure/ # Data access and seeding
├── StirCraftApp.Tests/          # Unit tests
├── StirCraftApp.ClientApp/      # Angular client application
└── README.md
```

The attempted structure of the project follows principles of Clean Architecture.
However the assignment calls for the usage of ASP.Net Identity and therefore in the domain layer
a dependency on Microsoft.Extensions.Identity.Stores is introduced. While the project initially
kept its domain "pure", the trade off for keeping it that way were not worth it.

-- Domain Layer - Contains entities, contracts, constants, enums, specifications 

-- Infrastructure Layer - Contains Seed data as json files and a json seed helper, context configurations, specification evaluator, actual implementation of 

Unit of work and Repositoty, entity configurations 

-- Application Layer - Contains service contracts, actual service implementations, paginated result class, 

DTOs, custom exceptions, mapping extensions (personal preference not to use AutoMapper) 

-- Api Layer - Contains controllers, custom attributes, service collection extensions 

-- Client App - Angular project with its belonging structure 


---

## Database Design

The database uses **Entity Framework Core** with the following entities:

- **AppUser:** Represents application users, extends the Identity User.
- **Cook:** Represents a user with Cook Role that can create, edit and delete recipes.
- **Category:** Culinary category a recipe can have.
- **Comment:** Comment posted by user to certain recipe.
- **Reply:** Reply posted by user to certain recipe comment.
- **Recipe:** Stores recipe details.
- **Ingredient:** Culinary ingredients.
- **RecipeImage:** Image URL pointing to recipe photo.
- **RecipeRating:** Rating by user for a recipe.
- **MeasurementUnit:** Stores units for ingredient quantities.
- **RecipeIngredient:** A culinary ingredient with its measurement unit used in a recipe.
- **CookingRank:** Implements gamified user ranks.

Soft deletion is implemented for entities using an `ISoftDeletable` interface.

### Seed Data

Initial data is seeded using JSON files located in `StirCraftApp.Infrastructure/Data/SeedData/SeedJsons`.

### Database Diagram

![Database diagram](https://github.com/user-attachments/assets/0bb6195c-1920-4750-b4ff-87b0003ee73f)

---

## Gamification System

Cooks earn points for:

- Uploading recipes. Points are given when the recipe is approved by admin.
- Getting likes on their recipes.

Removing a recipe or it getting removed from user`s favorite will result in points loss.

Ranks:

1. **StirCraftNovice** required minimum points 0
2. **StirSpecialist** required minimum points 500
3. **FlavorOperative** required minimum points 1000
4. **SeasonedCommander** required minimum points 1500
5. **MasterOfStirCraft** required minimum points 2000
6. **CulinaryOverlord** required minimum points 3000
7. **StirCraftGod** required minimum points 5000

---

## Security Features

**Authentication and Authorization**:

- Role-based access control for Admin, Cook and User roles.
- ASP.NET Identity for user management.
- Authentication is cookie based

---

## Testing

- Unit tests cover at currently 83% of the application services.
  ![testCoverage](https://github.com/user-attachments/assets/e0de60b9-579f-42d1-ad98-47a74eab158e)

To run tests:

```bash
cd StirCraftApp.Tests
dotnet test
```

---

## License

This project is licensed under the MIT License. See the `LICENSE` file for details.

---
