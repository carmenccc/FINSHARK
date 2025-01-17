# Project Demo
(https://finsharkcc.netlify.app/)

# Finshark Finance Project
> Copywrite: This is a duplicate project for study purpose, with extra features such as front-end details and deployment functions added for polish purpose. For original code please refer to (https://github.com/teddysmithdev/FinShark)
# Project Overview

Finshark is a financial information website providing features for easy search and review on company financial performance. This project has a full stack implementation for building the website, including a React front-end framework and a custom api built on .net back-end framework. Data source is a combination of custom database and external api.

Backend framework: Models + Controllers, Repository Pattern + DI, Dtos + Mappers

Frontend framework: React, Authentication Context + Data API Services, TailwindCSS

Skill Stacks Implementation:
- Custom database api: .net, providing local database data CRUD
- Login system: Entity Framework Identity, JWT token, React useAuth Context, Protected Route
- Company stock data: external API fetching using HttpClient service in backend and axios request in frontend
- User profile & comment system: relational database set up using Entity Framework fluent api CRUD on asp.net
- Dashboard components built using front-end framework: tables and lists using config object, react-form-hook, yup validation


# Feature Showcase

- Login & Authorization
  
- Search Company Stocks
- Add Company To User Profile
- Company Dashboard
- Comment System

# Back-end API Documentation
## Overview
This API provides endpoints for managing user accounts, comments, portfolios, and stocks. All endpoints require Bearer token authentication via JSON Web Tokens (JWT).
### Base URL
```
http://localhost:5195
```
## Authentication

**Security:** Bearer token authentication is required. Include the token in the `Authorization` header as follows:

```
Authorization: Bearer <your-token>
```
## Endpoints
### Account Endpoints
|Endpoint |  Method |  Description |
| --- | --- | --- |
| /api/account/registerl |  POST | Register a new account  |
| /api/account/login | POST |  Log in to an account |

### Stock Endpoints
|Endpoint  |  Method |  Description |
| --- | --- | --- |
| /api/stock | GET |  Retrieve stock details |
| /api/stock | POST |  Add a new stock  |
| /api/stock/{id} | GET |  Retrieve details of a specific stock |
| /api/stock/{id} | PUT |  Update details of a specific stock  |
| /api/stock/{id} | DELETE |  Delete a specific stock from the list |
|  |  |  |


### Comment Endpoints
|Endpoint |  Method  |  Description |
| --- | --- | --- |
| /api/comment | GET |  Retrieve comments |
| /api/comment/{id} | GET |  Retrieve a specific comment by ID |
| /api/comment/{id) | PUT |  Update a specific comment by ID |
|  /api/comment/{id} | DELETE |  Delete a specific comment by ID |
| /api/comment/{symbol} | POST |  Create a comment for a specific symbol  |

### Portfolio Endpoints
|Endpoint  |  Method |  Description  |
| --- | --- | --- |
| /api/portfolio | GET |  Retrieve portfolio details |
| /api/portfolio | POST |  Add an item to the portfolio |
| /api/portfolio | DELETE |  Remove an item from portfoliol |


