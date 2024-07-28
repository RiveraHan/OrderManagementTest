## OrderManagement

## Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker](https://www.docker.com/get-started) (optional, for running RabbitMQ in a container)

### Structure Services
Example
```
OrderService
│
├── Controllers
│   └── OrderController.cs
│
├── Domain
│   └── Models
│       └── Order.cs
│
├── Application
│   └── Handlers
│       ├── CreateOrderCommandHandler.cs
│       ├── GetOrderByIdQueryHandler.cs
│       └── GetAllOrdersQueryHandler.cs
│   └── Commands
│       └── CreateOrderCommand.cs
│   └── Queries
│       ├── GetOrderByIdQuery.cs
│       └── GetAllOrdersQuery.cs
│
├── Infrastructure
│   ├── Data
│       └── ApplicationDbContext.cs
│   ├── MessageBus
│       └── RabbitMQMessageBus.cs
│   └── Repositories
│       ├── IOrderRepository.cs
│       └── OrderRepository.cs
│
├── Startup.cs
└── Program.cs

```


### Run docker

```sh
cd OrderManagament
docker-compose up --build
```

### Curls Services Test Postman or Insomnia

```curl
curl --request POST \
  --url http://localhost:8080/api/User \
  --header 'Content-Type: application/json' \
  --header 'User-Agent: insomnia/9.3.2' \
  --data '{
  "Username": "usertest",
  "Password": "password123",
	"Email": "correo@correo.com"
}'
```
```curl
curl --request GET \
  --url http://localhost:8080/api/User/1 \
  --header 'User-Agent: insomnia/9.3.2'
```

```curl
curl --request POST \
  --url http://localhost:8080/api/User/authenticate \
  --header 'Content-Type: application/json' \
  --header 'User-Agent: insomnia/9.3.2' \
  --data '{
  "Username": "usertest",
  "Password": "password123"
}'
```

```curl
curl --request POST \
  --url http://localhost:8080/api/Order \
  --header 'Content-Type: application/json' \
  --header 'User-Agent: insomnia/9.3.2' \
  --data '{
	"ProductName": "TV",
	"Quantity": 2
}'
```

```curl
curl --request GET \
  --url http://localhost:8080/api/Order \
  --header 'Content-Type: application/json' \
  --header 'User-Agent: insomnia/9.3.2' \
  --data '{
	"ProductName": "TV",
	"Quantity": 2
}'
```
