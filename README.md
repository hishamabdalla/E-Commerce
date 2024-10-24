# Nilura - E-Commerce for Clothes

 **Nilura** is an eCommerce platform for fashion and apparel, built as part of my graduation project for the **Digital Egypt Pioneers Initiative (DEPI)** using **ASP.NET MVC**.

 This platform provides a complete online shopping experience, from browsing to order management, all while leveraging modern web development practices to ensure scalability and maintainability.


## Tech Stack & Architecture

- **N-Tier Architecture**: Divides the project into multiple layers for improved modularity and separation of concerns.
  - **MVC**: Manages views and controllers for user interactions.
  - **Data Access**: Interacts with the database to perform CRUD operations.
  - **Models**: Represents the core business logic and data structure.
  - **Utility Layer**: Contains constants and static data for reuse throughout the application.
- **Repository Pattern & Unit of Work**: Ensures clean and maintainable code, making data access more efficient and modular.
- **Database Initialization**: Seed data is populated using a custom DbInitializer during deployment.

## Features

### User Features:
- **Product Browsing**: Explore clothing items with detailed descriptions, prices, and available sizes.
- **Shopping Cart**: A session-based shopping cart where users can add items and checkout seamlessly.
- **Order Tracking**: Track orders with filters based on order status (e.g., pending, shipped).
- **Secure Authentication**: Sign up, log in, and manage accounts using ASP.NET Identity.

### Admin Features:
- **CRUD Operations**: Admins have full control over products, categories, productItem, users, and orders.
- **Role Management**: Admins can assign roles such as Employee, Customer, and Company.

### Payment Processing:
- **Stripe Integration**: Secure payment gateway to handle all transactions efficiently.


## Schema
![Schema](https://github.com/user-attachments/assets/d867ff1a-93b7-418e-9337-067d1b2b03ee)

