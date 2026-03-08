# Savora – Smart Expense & Financial Planning Platform

Savora is a **modern microservices-based expense tracking and financial planning platform** designed to help users monitor their spending, manage monthly budgets, and achieve financial goals using smart insights and automation.

The platform is designed with **scalability, modularity, and real-world backend architecture** in mind, making it a strong demonstration of modern backend engineering practices using **.NET and microservices**.

---

# Project Vision

Savora is more than just an expense tracker.

The goal is to build a **smart financial assistant** that helps users:

* Track expenses in real-time
* Manage monthly budgets automatically
* Achieve financial goals
* Analyze spending behavior
* Receive AI-driven financial advice

Future versions will also include **financial insights powered by AI** and **predictive budgeting**.

---

# System Architecture

Savora follows a **microservices architecture** where each service is responsible for a specific domain.

```
Client Applications (Web / Mobile)
            │
            ▼
        API Gateway
            │
 ┌──────────┼──────────┐
 │          │          │
 ▼          ▼          ▼
Auth     Expense   Notification
Service   Service     Service
 │          │          │
 ▼          ▼          ▼
Auth DB   Expense DB  Notification DB
```

Each service is **independent, scalable, and deployable**.

The system will also support **event-driven communication** between services.

---

# Solution Structure

```
Savora
│
├── docker
│   Docker configurations
│
├── gateway
│   API Gateway responsible for routing requests
│
├── services
│   ├── auth-service
│   │   Authentication and identity management
│   │
│   ├── expense-service
│   │   Core financial system (budgets, expenses, goals)
│   │
│   └── notification-service
│       Email / push notifications and alerts
│
└── shared
    Shared building blocks between services
```

---

# Core Services

## Auth Service

Handles authentication and authorization.

Responsibilities:

* User registration
* User login
* JWT authentication
* Role management
* Secure access control

---

## Expense Service (Core System)

The heart of the platform.

Responsibilities:

* Monthly salary tracking
* Automatic monthly budget creation
* Expense tracking
* Expense categorization
* Financial goal management
* Savings tracking
* Financial insights

Key concepts:

* Salary cycle
* Monthly financial tracking
* Expense priority (essential vs lifestyle)
* Savings and goals

---

## Notification Service

Responsible for notifying users about important events.

Examples:

* Goal completion alerts
* Budget warnings
* Spending alerts
* System notifications

Future integrations:

* Email notifications
* Push notifications
* Real-time alerts

---

# Core Features

## Expense Tracking

Users can record and categorize their daily expenses.

Features include:

* Expense categories
* Priority classification
* Monthly analytics
* Spending history

---

## Monthly Budget Automation

Users define:

* Monthly salary
* Salary day

When the salary day arrives:

A new **monthly budget cycle** is automatically created.

This allows users to track spending **per financial cycle instead of calendar months**.

---

## Financial Goals

Users can define goals such as:

* Buying a phone
* Saving for travel
* Building emergency funds

The system tracks:

* Goal progress
* Contributions
* Completion status

---

## Savings Tracking

Users can track savings independently from expenses.

This allows Savora to calculate:

* Total savings
* Remaining budget
* Financial progress

---

## Smart Insights (AI Ready)

Savora stores financial behavior insights that can later be generated using AI.

Examples:

* Overspending alerts
* Spending pattern analysis
* Budget recommendations

This enables future integration with **AI financial advisors**.

---

# Future Services

Savora is designed to grow with additional microservices.

Planned services include:

### Currency Exchange Service

Real-time currency conversion and exchange rate management.

Use cases:

* Multi-currency expenses
* Global financial tracking

---

### Analytics Service

Advanced financial analytics such as:

* spending patterns
* financial health score
* predictive budgeting

---

### AI Advisor Service

AI-powered financial assistant capable of:

* analyzing spending behavior
* suggesting savings strategies
* recommending budgets

---

### Payment & Subscription Service

For SaaS capabilities including:

* premium plans
* advanced analytics
* AI insights

---

# Technologies Used

Backend:

* .NET
* ASP.NET Core
* Entity Framework Core
* Microservices Architecture

Infrastructure:

* Docker
* API Gateway

Security:

* JWT Authentication
* OAuth (Sign-in with Google)

Future Integrations:

* Message brokers
* AI services
* distributed caching

---

# Key Architectural Principles

Savora follows modern backend engineering practices:

* Microservices architecture
* Separation of concerns
* Independent service deployment
* Scalable infrastructure design
* Event-driven communication (future)

---

# Development Goals

This project is built as a **production-style backend system** to demonstrate:

* microservices architecture
* scalable backend design
* clean code practices
* real-world system design

It serves as both a **learning project and a professional backend portfolio**.

---

# Roadmap

Upcoming improvements include:

* Event-driven communication
* Background jobs for salary cycles
* AI financial insights
* Real-time notifications
* Advanced analytics dashboards
* Multi-currency support
* SaaS subscription plans

---

# Author

Ahmed Elgebaly

Backend Developer focused on building scalable systems using .NET and modern backend architecture.

---

# License

This project is currently under development and intended for educational and portfolio purposes.
