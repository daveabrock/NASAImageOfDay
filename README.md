# Blast off with Blazor

![Azure Static Web Apps CI/CD](https://github.com/daveabrock/NASAImageOfDay/workflows/Azure%20Static%20Web%20Apps%20CI/CD/badge.svg)

This is an app I wrote to show off the Azure Static Web Apps functionality over Blazor. This site uses Blazor Web Assembly to call off to an Azure Function, which in turn gets images originally belonging to the NASA Astronomy Picture of the Day (APOD) API. I wrote a function to migrate the data to Azure Storage and Cosmos DB, and I [wrote about it as well](https://daveabrock.com/2020/11/25/images-azure-blobs-cosmos).

This app is meant to showcase my learnings on Blazor best practices. Any suggestions? Create a pull request!

## Run locally

After you clone, to work with Azure Cosmos DB adjust your function's `local.settings.json` file appropriately. Here's how mine looks:

```json
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet",
    "RepositoryOptions:CosmosConnectionString": "<your-connection-string>",
    "RepositoryOptions:DatabaseId": "<your-database-id",
    "RepositoryOptions:ContainerId": "<your-container-id>"
  }
}
```

### Modify solution properties

In your solution properties, under `Startup Project`, select `Multiple startup projects` and set `Api` and `Client` to `Start`.



