# Quick Start Guide

## 1️⃣ Get Your API Key

1. Go to https://openweathermap.org/api
2. Sign up for a free account
3. Get your API key from the dashboard

## 2️⃣ Configure the Application

Edit `appsettings.json` and add your API key:

```json
{
  "OpenWeatherMap": {
    "ApiKey": "paste_your_api_key_here"
  }
}
```

## 3️⃣ Choose Your Method

### Method 1: Visual Studio (Recommended)

1. Open `WeatherApp.sln` in Visual Studio 2022
2. Press **F5** to run
3. Browser opens automatically to Swagger UI

### Method 2: Command Line

**Windows:**
```powershell
.\run.ps1
```

**Linux/Mac:**
```bash
./run.sh
```

**Or manually:**
```bash
dotnet restore
dotnet run
```

### Method 3: Docker

```bash
# Build the image
docker build -t weatherapp .

# Run the container
docker run -p 5000:8080 -e OpenWeatherMap__ApiKey=YOUR_KEY weatherapp

# Or use docker-compose
docker-compose up
```

## 4️⃣ Test the API

Open your browser:
- **Swagger UI**: http://localhost:5000/swagger
- **Health Check**: http://localhost:5000/api/weather/health

Try these endpoints:
```bash
# Current weather
curl http://localhost:5000/api/weather/current/London

# 5-day forecast
curl http://localhost:5000/api/weather/forecast/Paris?days=5
```

## 🎉 That's It!

Your weather API is now running. Visit the Swagger UI to explore all endpoints.

## Need Help?

- Check the main [README.md](README.md) for detailed documentation
- Review the Swagger documentation at `/swagger`
- Make sure your API key is valid
