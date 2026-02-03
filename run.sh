#!/bin/bash

echo "=========================================="
echo "Weather Application Launcher"
echo "=========================================="
echo ""

# Check if .NET SDK is installed
if ! command -v dotnet &> /dev/null
then
    echo "❌ .NET SDK is not installed!"
    echo "Please install .NET 8.0 SDK from: https://dotnet.microsoft.com/download"
    exit 1
fi

echo "✅ .NET SDK found: $(dotnet --version)"
echo ""

# Restore dependencies
echo "📦 Restoring NuGet packages..."
dotnet restore

if [ $? -ne 0 ]; then
    echo "❌ Failed to restore packages"
    exit 1
fi

echo "✅ Packages restored successfully"
echo ""

# Build the project
echo "🔨 Building the project..."
dotnet build

if [ $? -ne 0 ]; then
    echo "❌ Build failed"
    exit 1
fi

echo "✅ Build completed successfully"
echo ""

# Run the application
echo "🚀 Starting Weather API..."
echo ""
echo "📍 API will be available at:"
echo "   - http://localhost:5000"
echo "   - https://localhost:5001"
echo ""
echo "📚 Swagger UI will be available at:"
echo "   - http://localhost:5000/swagger"
echo "   - https://localhost:5001/swagger"
echo ""
echo "Press Ctrl+C to stop the application"
echo ""

dotnet run
