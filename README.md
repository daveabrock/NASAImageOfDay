# Blast off with Blazor

![Azure Static Web Apps CI/CD](https://github.com/daveabrock/NASAImageOfDay/workflows/Azure%20Static%20Web%20Apps%20CI/CD/badge.svg)

This is an app I wrote to show off the Azure Static Web Apps functionality over Blazor. This site uses Blazor Web Assembly to call off to an Azure Function, which in turn calls the external NASA Astronomy Picture of the Day (APOD) API (it's the first API [at this link](https://api.nasa.gov)). On initialize, the app fetches a random image from between the site's start date (June 16, 1995) and today.

```csharp
... // setup code
var response = await httpClient.GetAsync($"https://api.nasa.gov/planetary/apod?api_key={apiKey}&hd=true&date={GetRandomDate()}");
...

private static string GetRandomDate()
{
   var random = new Random();
   var startDate = new DateTime(1995, 06, 16);
   var range = (DateTime.Today - startDate).Days;
   return startDate.AddDays(random.Next(range)).ToString("yyyy-MM-dd");
}
```

In the API call, only the `apiKey` is mandatory. If you don't specify a date, the API grabs the latest image. The `hd` flag will return both a `url` and an `hdurl`.

This app is meant to showcase my learnings on Blazor best practices. Any suggestions? Create a pull request!

## Run locally

After you clone, the only thing you'll need to do is [register for an API key](https://api.nasa.gov/#signUp) (which is free). 

Then, create a `local.settings.json` file in the API project with something like this:

```json
{
	"IsEncrypted": false,
	"Values": {
		"AzureWebJobsStorage": "UseDevelopmentStorage=true",
		"FUNCTIONS_WORKER_RUNTIME": "dotnet",
		"ApiKey": "my-api-key"
	}
}
```
