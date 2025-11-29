# Personal Finance Tracker API

## Project Description

This project is a robust and scalable backend API for a personal finance tracking application. It is designed to help users manage their expenses, track their income, set financial goals, and gain a clear overview of their monthly spending.

The API is built using **.NET 9.0** and is structured following modern architectural principles (Clean Architecture/CQRS) to ensure maintainability, testability, and performance.

## Key Features

*   **Multi-Currency Support:** Users can log both income and expenses in any currency. The system automatically converts all transactions to the user's **Base Currency** for unified reporting.
*   **Dynamic Base Currency:** The user's initial base currency is determined by their provided address (simulated geolocation). Users have the flexibility to change their base currency at any time.
*   **Income Tracking:** A dedicated `Income` model allows users to log various sources of income, including automatic salary entries based on their `MonthlySalary` and `MonthlyDate`.
*   **Notification System:** Integrated `Notification` model and service to alert users about important events (e.g., large expenses, goal progress, or salary receipt).
*   **Monthly Expense Aggregation:** The `MonthExpense` model automatically aggregates spending to provide a clear monthly summary.
*   **Financial Goals:** Users can define and track progress towards specific financial goals.

## Architecture Overview

The project is designed with a layered architecture, separating concerns for clarity and scalability:

1.  **Domain:** Contains the core business entities (`User`, `Expense`, `Income`, etc.) and interfaces for Repositories and Services.
2.  **Application:** Houses the application logic, including **Commands** and **Queries** (CQRS pattern) and their **Handlers** (e.g., using MediatR).
3.  **Infrastructure:** Implements the external details, such as the Entity Framework Core `DbContext`, concrete Repository classes, and external service implementations (e.g., the `CurrencyService` implementation).
4.  **Presentation (API):** The entry point, containing the Controllers that receive HTTP requests and dispatch Commands/Queries to the Application layer.

## Getting Started

### Prerequisites

*   .NET 9 SDK or later
*   A preferred IDE (Visual Studio, VS Code)

### Setup

1.  **Clone the repository:**
    ```bash
    git clone https://github.com/A7medM7md/Savora.git
    cd Savora
    ```
2.  **Restore dependencies:**
    ```bash
    dotnet restore
    ```
3.  **Run the application:**
    ```bash
    dotnet run --project Savora.Api
    ```

The API will typically run on `https://localhost:7001` (or a similar port). You can access the Swagger UI at `/swagger` to test the endpoints.
