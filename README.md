# Application Communication & API Documentation

## Overview

This application consists of an Angular 20 frontend and a .NET 8 backend API. The communication between these layers is secured using JWT authentication and follows RESTful principles.

## Key Communication Patterns

### 1. Authentication Flow
- User credentials are sent from the Login Component to the backend's `/api/auth/login` endpoint
- Backend validates credentials against the database using BCrypt password hashing
- On success, a JWT token is generated with 24-hour expiry
- Token is stored in browser cookies and used for subsequent requests

### 2. Request Authorization
- Every protected route is guarded by the `authenticationGuard`
- The Auth Interceptor automatically adds the JWT token as a Bearer token to all HTTP requests
- Backend validates the JWT token for every protected endpoint using the Authorization middleware

### 3. API Communication Structure
- **Base URL**: `https://localhost:44336/api/`
- All API calls are made through Angular services (AuthenticationService, CustomersService)
- Services extend BaseService which provides common HTTP methods
- Interceptors handle cross-cutting concerns (auth, caching, error handling)

### 4. Data Flow Architecture
```
Angular Component → Service → Interceptors → Backend Controller → Service → Entity Framework → Database
                                    ↓                                                             ↓
                              Bearer Token                                                   SQL Server
```

### 5. Real-time Feedback
- Toast notifications provide immediate feedback for all operations
- Modal service handles confirmations and forms
- Error interceptor catches and displays all HTTP errors

## API Endpoints Reference

### Base URL
`https://localhost:44336/api/`

### Authentication Endpoints

| Method | Endpoint | Description | Request Body | Response | Protected |
|--------|----------|-------------|--------------|----------|-----------|
| POST | `/api/auth/register` | Register new user | `{ username, password }` | Success message or conflict | ❌ |
| POST | `/api/auth/login` | User login | `{ username, password }` | `{ token: "JWT..." }` | ❌ |
| GET | `/api/auth/users` | Get all users | - | User list with id, username, password | ✅ |

### Customer Endpoints (All Protected ✅)

| Method | Endpoint | Description | Request Body | Response |
|--------|----------|-------------|--------------|----------|
| GET | `/api/customers` | Get all customers | - | `CustomerDTO[]` |
| GET | `/api/customers/{number}` | Get customer by number | - | `CustomerDTO` |
| POST | `/api/customers` | Create new customer | `{ name, dateOfBirth, gender }` | `CustomerDTO` with assigned number |
| PUT | `/api/customers/{number}` | Update customer | `{ name?, dateOfBirth?, gender? }` | Updated `CustomerDTO` |
| DELETE | `/api/customers/{number}` | Delete customer | - | `{ message: "Customer deleted" }` |

## Data Transfer Objects

### AuthenticationDTO
```typescript
{
  username: string;
  password: string;
}
```

### CustomerDTO
```typescript
{
  number: number;      // Auto-generated primary key
  name: string;
  dateOfBirth: string; // Format: "YYYY-MM-DD"
  gender: string;      // "M" or "F"
}
```

### CreateCustomerDTO
```typescript
{
  name: string;
  dateOfBirth: string;
  gender: string;
}
```

### UpdateCustomerDTO (All fields optional)
```typescript
{
  name?: string;
  dateOfBirth?: string;
  gender?: string;
}
```

## Security & Authentication

### JWT Token Configuration
- **Issuer**: "NBK-TASK-BE"
- **Audience**: "NBK-TASK-FE"
- **Expiry**: 24 hours from generation
- **Claims**: User ID and Username
- **Algorithm**: HMAC SHA256
- **Storage**: HTTP-only cookies

### Request Headers for Protected Endpoints
```
Authorization: Bearer <JWT_TOKEN>
Content-Type: application/json
```

### CORS Configuration
- **Allowed Origin**: `http://localhost:4200`
- **Allowed Methods**: All HTTP methods
- **Allowed Headers**: All headers
- **Credentials**: Allowed

## Error Handling

### HTTP Status Codes

| Status | Description | Example Scenario |
|--------|-------------|------------------|
| 200 | Success | Successful GET, PUT operations |
| 201 | Created | Successful POST with resource creation |
| 401 | Unauthorized | Invalid or missing JWT token |
| 404 | Not Found | Customer with specified number doesn't exist |
| 409 | Conflict | Username already exists during registration |

### Error Interceptor Behavior
- Catches all HTTP errors
- Logs errors to console
- Displays user-friendly messages via Toast Service
- 401 errors trigger redirect to login page

## Caching Strategy

### Cache Interceptor Rules
- **Cached Operations**: GET requests only
- **Cache Duration**: 1 minute (60,000ms)
- **Cache Invalidation**: Automatic on any mutating operation (POST, PUT, DELETE, PATCH)
- **Cache Key**: Full URL with parameters
- **Storage**: In-memory JavaScript Map

### Example Cache Flow
```
1. GET /api/customers → Check cache → Not found → Make request → Store in cache → Return data
2. GET /api/customers → Check cache → Found & valid → Return cached data
3. POST /api/customers → Clear all customer-related cache entries → Make request
4. GET /api/customers → Check cache → Not found → Make fresh request
```

## Frontend Services Architecture

### Service Hierarchy
```
BaseService (HTTP methods)
    ├── AuthenticationService
    │   ├── login()
    │   └── register()
    └── CustomersService
        ├── getCustomers()
        ├── getCustomerByNumber()
        ├── AddCustomer()
        ├── updateCustomer()
        └── deleteCustomer()
```

### Component Services
- **ModalService**: Manages modal dialogs for forms and confirmations
- **ToastService**: Displays success/error notifications
- **CookieService**: Handles JWT token storage and retrieval

## Development URLs

- **Frontend**: http://localhost:4200
- **Backend API**: https://localhost:44336
- **Swagger UI**: https://localhost:44336/swagger

## Database Schema

### Users Table
- Id (int, PK)
- Username (string, max 255, unique)
- Password (string, max 100, hashed)

### Customers Table
- Number (int, PK, auto-increment)
- Name (string, max 255, required)
- DateOfBirth (DateOnly, required)
- Gender (string, length 1, required)

### Seeded Data
- 1 default user: username "azmarafi", password "password123"
- 20 sample customers (numbers 1-20)
