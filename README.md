# Cadocr
![.NET Core](https://github.com/approvers/cadocr/workflows/.NET%20Core/badge.svg)
![Docker](https://github.com/approvers/cadocr/workflows/Docker/badge.svg)  
Registers meigens from captured image on Discord.

## Prerequisites
- .NET Core Runtime 3.1 or Docker with Compose 3.8+
- A application on Discord with bot access
- An IAM user on Google Cloud Platform with Cloud Vision access

## Installation
### Using Docker
1. Pull an image from GitHub Packages Registry.
2. Configure with environment variables or `appsettings.local.json` .
3. Create and run a container with the image.

### Otherwise
1. Clone this repository.
2. Configure with environment variables or `appsettings.local.json` .
3. Build the project with `dotnet build -c Release -o bin` .
4. Run the built application with `docker ./bin/Cadocr.dll` .

## Configuration
### Using environment variables
```sh
Discord__Bot__Token="[YOUR DISCORD BOT TOKEN]"
CloudVision__Credentials__Path="[YOUR CLOUDVISION CREDENTIALS JSON PATH]"
```

### Using `appsettings.local.json`
```json
{
  "Discord": {
    "Bot": {
      "Token": "[YOUR DISCORD BOT TOKEN]"
    }
  },
  "CloudVision": {
    "Credentials": {
      "Path": "[YOUR CLOUDVISION CREDENTIALS JSON PATH]"
    }
  }
}
```

If you are using Docker, make sure you mounted the config file to your container.

```yaml
volumes:
  - ./appsettings.local.json:/app/appsettings.local.json:ro
```
