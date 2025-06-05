# CleanArchitecture

This project follows the **Clean Architecture** principles to ensure scalability, maintainability, and separation of concerns. The architecture is organized into clear layers, each with its own responsibility.


### Project Structure

├─ domain # Core business logic and entities
├─ application # Use cases and application services
├─ infrastructure # External dependencies (e.g., DB, APIs)
├─ presentation # UI layer / Controllers / Routes


### Key Concepts

- **Domain Layer**: Contains enterprise-wide business rules and core models.
- **Application Layer**: Coordinates application activity and implements use cases.
- **Infrastructure Layer**: Implements communication with external systems (database, network, etc.).
- **Presentation Layer**: Handles user interaction and framework-specific interfaces (like HTTP controllers or UI).

### Benefits

- **Testability**: Easy to write unit tests for core logic.
- **Flexibility**: Swap external components without affecting the business logic.
- **Maintainability**: Changes in one layer have minimal effect on others.
