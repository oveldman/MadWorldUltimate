[![.NET Build & Test](https://github.com/oveldman/MadWorldUltimate/actions/workflows/dotnet.yml/badge.svg)](https://github.com/oveldman/MadWorldUltimate/actions/workflows/dotnet.yml)
[![CodeQL](https://github.com/oveldman/MadWorldUltimate/actions/workflows/codeql-analysis.yml/badge.svg)](https://github.com/oveldman/MadWorldUltimate/actions/workflows/codeql-analysis.yml)
[![SonarQube Scan](https://github.com/oveldman/MadWorldUltimate/actions/workflows/sonarqube.yml/badge.svg)](https://github.com/oveldman/MadWorldUltimate/actions/workflows/sonarqube.yml)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=oveldman_MadWorldUltimate&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=oveldman_MadWorldUltimate)
[![Azure Static Web App published](https://github.com/oveldman/MadWorldUltimate/actions/workflows/azure-static-web-apps-jolly-tree-08fdeb903.yml/badge.svg?branch=main)](https://github.com/oveldman/MadWorldUltimate/actions/workflows/azure-static-web-apps-jolly-tree-08fdeb903.yml)
[![Build and deply to Mad-World.nl/Api](https://github.com/oveldman/MadWorldUltimate/actions/workflows/main_madworld-api.yml/badge.svg?branch=main)](https://github.com/oveldman/MadWorldUltimate/actions/workflows/main_madworld-api.yml)
[![Build and deply to Mad-World.nl/ApiAnonymous](https://github.com/oveldman/MadWorldUltimate/actions/workflows/main_madworld-api-anonymous.yml/badge.svg)](https://github.com/oveldman/MadWorldUltimate/actions/workflows/main_madworld-api-anonymous.yml)

# MadWorldUltimate

Welcome to my hobby project. I try to build new stuff like Blazor and Azure components. You can find my website here: [Mad-World.nl](https://www.mad-world.nl/)

For every pull request, SonarQube will generate another rapport:
[SonarQube Rapport](https://sonarcloud.io/project/overview?id=oveldman_MadWorldUltimate)

I deployed the following resources on azure:
- Application Insight
- API Management Service
- Azure Functions (2x)
- Azure Static Website
- Blob Storage
- Azure Active Directory B2C
- Resource Group
- Subscription

## Running the project

You need to run the following projects inside the solution:
- MadWorld.Api
- MadWorld.Api.Anonymous
- MadWorld.Web

You need also to run the following services locally:
- Azurite (Azure Storage Emulator)

Set our own appinsight instrumentation key in the following files:
- MadWorld.Api/local.settings.json
- MadWorld.Api.Anonymous/local.settings.json
- MadWorld.Web/wwwroot/index.html

Set our own Azure B2C settings in the following file:
- MadWorld.Web/wwwroot/appsettings.development.json

Now you can run the project.

## Tests

You can run the tests from the main folder by typing `dotnet test MadWorld`