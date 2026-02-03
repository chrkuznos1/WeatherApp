# Weather Application Launcher for Windows

Write-Host "==========================================" -ForegroundColor Cyan
Write-Host "Weather Application Launcher" -ForegroundColor Cyan
Write-Host "==========================================" -ForegroundColor Cyan
Write-Host ""

# Check if .NET SDK is installed
try {
    $dotnetVersion = dotnet --version
    Write-Host "✅ .NET SDK found: $dotnetVersion" -ForegroundColor Green
} catch {
    Write-Host "❌ .NET SDK is not installed!" -ForegroundColor Red
    Write-Host "Please install .NET 8.0 SDK from: https://dotnet.microsoft.com/download" -ForegroundColor Yellow
    exit 1
}

Write-Host ""

# Restore dependencies
Write-Host "📦 Restoring NuGet packages..." -ForegroundColor Yellow
dotnet restore

if ($LASTEXITCODE -ne 0) {
    Write-Host "❌ Failed to restore packages" -ForegroundColor Red
    exit 1
}

Write-Host "✅ Packages restored successfully" -ForegroundColor Green
Write-Host ""

# Build the project
Write-Host "🔨 Building the project..." -ForegroundColor Yellow
dotnet build

if ($LASTEXITCODE -ne 0) {
    Write-Host "❌ Build failed" -ForegroundColor Red
    exit 1
}

Write-Host "✅ Build completed successfully" -ForegroundColor Green
Write-Host ""

# Run the application
Write-Host "🚀 Starting Weather API..." -ForegroundColor Cyan
Write-Host ""
Write-Host "📍 API will be available at:" -ForegroundColor White
Write-Host "   - http://localhost:5000" -ForegroundColor White
Write-Host "   - https://localhost:5001" -ForegroundColor White
Write-Host ""
Write-Host "📚 Swagger UI will be available at:" -ForegroundColor White
Write-Host "   - http://localhost:5000/swagger" -ForegroundColor White
Write-Host "   - https://localhost:5001/swagger" -ForegroundColor White
Write-Host ""
Write-Host "Press Ctrl+C to stop the application" -ForegroundColor Yellow
Write-Host ""

dotnet run
