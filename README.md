# demoappconfigfeatureflag
## Steps to create and run this project:
- Create App Configuration in Azure Portal: `go to Azure Portal and create App Configuration resource`
- Create the following Configuration Entries:

| Key| Value|
| ----------- | ----------- |
| TestApp:Settings:BackgroundColor| white|
| TestApp:Settings:FontColor | black|
| TestApp:Settings:FontSize | 24|
| TestApp:Settings:Message | Data from Azure App Configuration|

- Create the Feature Flags from App Configuration:

| Feature Flag|
| ----------- |
| BetaPageDecorator |
| BetaPageIfStatement |
| BetaPageTag | 

- Build
```
dotnet build
```

- Run
```
dotnet run
```

## Steps to create this project from scratch:

- Create the project: 
```
dotnet new webapp --output TestAppConfig
cd TestAppConfig
```
- Add nuget packages for: AppConfiguration and Feature Flags
```
dotnet add package Microsoft.Azure.AppConfiguration.AspNetCore
dotnet add package Microsoft.FeatureManagement.AspNetCore
```
- To avoid using Secrets in your local environment, use the dotnet Secret Manager:
```
dotnet user-secrets init
dotnet user-secrets set ConnectionStrings:AppConfig "<your_connection_string>"
```


## Resources:

- https://learn.microsoft.com/en-us/azure/azure-app-configuration/quickstart-aspnet-core-app?tabs=core6x
- https://learn.microsoft.com/en-us/azure/azure-app-configuration/quickstart-feature-flag-aspnet-core?tabs=core6x