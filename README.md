# Weather Application API

A modern C# ASP.NET Core Web API for fetching weather information using OpenWeatherMap API.

## Features

- ✅ Get current weather for any city
- ✅ Get weather forecast (up to 5 days)
- ✅ RESTful API with Swagger documentation
- ✅ Docker support
- ✅ Comprehensive error handling
- ✅ Health check endpoint
- ✅ CORS enabled

## Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)
- [Docker Desktop](https://www.docker.com/products/docker-desktop) (for containerization)
- OpenWeatherMap API Key (free at https://openweathermap.org/api)

## Getting Started

### 1. Get OpenWeatherMap API Key

1. Go to https://openweathermap.org/api
2. Sign up for a free account
3. Generate an API key from your account dashboard
4. Copy the API key for use in the application

### 2. Open in Visual Studio

**Option A: Using Solution File**
1. Open `WeatherApp.sln` in Visual Studio 2022
2. Visual Studio will restore NuGet packages automatically

**Option B: Using Folder**
1. File → Open → Folder
2. Select the `WeatherApp` folder
3. Visual Studio will detect the project

### 3. Configure API Key

Open `appsettings.json` or `appsettings.Development.json` and replace `YOUR_API_KEY_HERE`:

```json
{
  "OpenWeatherMap": {
    "ApiKey": "your_actual_api_key_here"
  }
}
```

### 4. Run the Application

**In Visual Studio:**
- Press `F5` or click the "Run" button
- The application will start at `https://localhost:5001` or `http://localhost:5000`

**Using .NET CLI:**
```bash
dotnet restore
dotnet build
dotnet run
```

### 5. Access Swagger UI

Open your browser and navigate to:
- https://localhost:5001/swagger (HTTPS)
- http://localhost:5000/swagger (HTTP)

## API Endpoints

### Get Current Weather
```
GET /api/weather/current/{city}
```

Example:
```bash
curl http://localhost:5000/api/weather/current/London
```

Response:
```json
{
  "city": "London",
  "country": "GB",
  "temperature": 15.5,
  "feelsLike": 14.2,
  "description": "partly cloudy",
  "humidity": 72,
  "windSpeed": 5.2,
  "icon": "02d",
  "dateTime": "2024-02-03T14:30:00"
}
```

### Get Weather Forecast
```
GET /api/weather/forecast/{city}?days={days}
```

Example:
```bash
curl http://localhost:5000/api/weather/forecast/Paris?days=3
```

### Health Check
```
GET /api/weather/health
```

## Docker Deployment

### Build Docker Image

```bash

docker build -t weatherapp:latest .

```

### Run Docker Container

**Option 1: Using docker run**
```bash
docker run -d -p 5000:8080 -e OpenWeatherMap__ApiKey=xxx -e ASPNETCORE_ENVIRONMENT='Development' --name weatherapp weatherapp:latest
```
# WeatherAPIKEYa788f7f566f8188a0f751918b1d6b0fd

**Option 2: Using docker-compose**
```bash
# Set your API key as environment variable
export OPENWEATHER_API_KEY=your_api_key_here

# Or edit docker-compose.yml directly

# Start the container
docker-compose up -d
```

### Access the Application

Once running in Docker, access at:
- http://localhost:5000/swagger
- http://localhost:5000/api/weather/current/Athens

### Stop and Remove Container

```bash
docker-compose down

# Or using docker commands
docker stop weatherapp
docker rm weatherapp
```

## Project Structure

```
WeatherApp/
├── Controllers/
│   └── WeatherController.cs      # API endpoints
├── Models/
│   └── WeatherModels.cs           # Data models
├── Services/
│   └── WeatherService.cs          # Business logic
├── Program.cs                     # Application entry point
├── WeatherApp.csproj              # Project file
├── appsettings.json               # Configuration
├── Dockerfile                     # Docker configuration
├── docker-compose.yml             # Docker Compose configuration
└── README.md                      # This file
```

## Configuration

### Environment Variables

- `ASPNETCORE_ENVIRONMENT`: Set to `Development` or `Production`
- `OpenWeatherMap__ApiKey`: Your OpenWeatherMap API key
- `ASPNETCORE_URLS`: Server URLs (default: http://+:8080 in Docker)

### appsettings.json

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information"
    }
  },
  "OpenWeatherMap": {
    "ApiKey": "YOUR_API_KEY_HERE"
  }
}
```

## Development Tips

### Debug in Visual Studio
1. Set breakpoints by clicking in the left margin
2. Press F5 to start debugging
3. Use the Debug menu for step-through debugging

### Hot Reload
Visual Studio 2022 supports hot reload - make changes while debugging and see them immediately!

### View Logs
- In Visual Studio: View → Output → Show output from: Debug
- In Docker: `docker logs weatherapp`

## Troubleshooting

### API Key Issues
- Ensure your API key is valid and active
- Free API keys may have rate limits
- Check the OpenWeatherMap dashboard for API usage

### Port Conflicts
If port 5000 is already in use:
- Change the port in `docker-compose.yml`
- Or use: `docker run -p 8080:8080 ...`

### Docker Build Fails
```bash
# Clean Docker cache and rebuild
docker system prune -a
docker build --no-cache -t weatherapp:latest .
```

## Technologies Used

- **ASP.NET Core 8.0** - Web API framework
- **Swagger/OpenAPI** - API documentation
- **Newtonsoft.Json** - JSON serialization
- **Docker** - Containerization
- **OpenWeatherMap API** - Weather data provider

## License

This project is provided as-is for educational purposes.

## Support

For issues or questions:
1. Check the Swagger documentation at `/swagger`
2. Review the logs for error messages
3. Verify your API key is configured correctly

## Next Steps

- Add caching to reduce API calls
- Implement authentication
- Add database for storing historical weather data
- Create a frontend UI (Blazor, React, or Angular)
- Add unit tests
- Deploy to Azure App Service or AWS

---

**Happy Coding! 🌤️**


---

When you’re ready to release a version:

bash
git checkout br1-docker
git pull
git tag v1.0.0
git push origin v1.0.0
GitHub Actions will automatically:

Build the Docker image

Tag it with v1.0.0

Push it to Docker Hub

No manual version editing, no secrets, no mistakes.