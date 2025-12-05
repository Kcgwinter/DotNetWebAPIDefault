## Connections - 
SQL Connection: 69.62.64.145 Port 1433 DB: TestDB User: TestUser PW: TestUserPW


## Prequise
Entity Framework Core:
- SQL Server


## To Add a new Feature:
Follow the following steps:
Model				//Sets Props of Object -> Inherit BaseModel
InterfaceRepository		// Gives playrules for repository (model controller)
Repository			// Model Controller Inherits from InterfaceRepository
Add Repositories to Program CS //builder.Services.AddScoped<ITodoRepository, TodoRepository>();
DTOs				// Create DTO(return Object on regular request)
	Create DTO		// Create Create DTO  (DTO presented by Frontend for create Object)
	Update DTO		// Create Update DTO  (DTO presended by Frontend for update Object)
Controller			// API Entry point, inherit BaseAPIController