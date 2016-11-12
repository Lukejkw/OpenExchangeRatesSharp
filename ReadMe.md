# OpenExchangeRatesSharp

[![Build status](https://ci.appveyor.com/api/projects/status/pgqxlne84y94sb2n?svg=true)](https://ci.appveyor.com/project/Lukejkw/openexchangeratessharp)

A simple C# wrapper over the [https://openexchangerates.org](penexchangerates.org) API

## Getting Started

1. Register on the site and get an API Key
2. Install via Nuget ```Install-Package OpenExchangeRatesSharp```
3. Use the API

### Example Usage:

```javascript

var client = new RateClient("your_api_key")
var result = client.GetLatest();
var rates = result.Rates; // A dictionary of the rates

```

## Free Account Users

If you are using the free account, do not use anything other than the defaults.


## Paid Account Users

This library has not been tested with a paid account but should still work.

## Contributers

To run the tests you will need to add an App.config file to the root of the integration test project

### Example

```xml

<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <appSettings>
    <add key="api.key" value="your_api_key" />
  </appSettings>
</configuration>

```

Created by Luke warren. More about me at [http://lukewarrendev.co.za](LukeWarrenDev.co.za)