set V=2.10.5
nuget push VirtoCommerce.CoreModule.Client.%V%.nupkg -Source nuget.org -ApiKey %1
nuget push VirtoCommerce.Domain.%V%.nupkg -Source nuget.org -ApiKey %1
nuget push VirtoCommerce.CoreModule.Data.%V%.nupkg -Source nuget.org -ApiKey %1
