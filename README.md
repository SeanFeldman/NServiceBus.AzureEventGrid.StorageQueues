![Icon](https://github.com/SeanFeldman/NServiceBus.AzureEventGrid.StorageQueues/blob/develop/images/project-icon.png)

## Icon

Created by Cuby Design from the Noun Project.


### This is an extention to allow processing of Azure Event Grid events with NServiceBus using Storage Queues transport

[![license](https://img.shields.io/github/license/mashape/apistatus.svg)](https://github.com/SeanFeldman/NServiceBus.AzureEventGrid.StorageQueues/blob/develop/LICENSE)
[![develop](https://img.shields.io/appveyor/ci/seanfeldman/NServiceBus.AzureEventGrid.StorageQueues/develop.svg?style=flat-square&branch=develop)](https://ci.appveyor.com/project/seanfeldman/NServiceBus.AzureEventGrid.StorageQueues)
[![opened issues](https://img.shields.io/github/issues-raw/badges/shields/website.svg)](https://github.com/SeanFeldman/NServiceBus.AzureEventGrid.StorageQueues/issues)

### Nuget package

[![NuGet Status](https://buildstats.info/nuget/NServiceBus.AzureEventGrid.StorageQueues?includePreReleases=true)](https://www.nuget.org/packages/NServiceBus.AzureEventGrid.StorageQueues/)

Available here http://nuget.org/packages/NServiceBus.AzureEventGrid.StorageQueues

To Install from the Nuget Package Manager Console 
    
    PM> Install-Package NServiceBus.AzureEventGrid.StorageQueues
    
### Usage

```c#
endpointConfiguration.UseTransport<AzureStorageQueueTransport>().EnableSupportForEventGridEvents();
```
