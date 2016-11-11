# OpenExchangeRatesSharp

A simple C# wrapper over the [https://penexchangerates.org](penexchangerates.org) API

## Getting Started

1. Register on the site and get an API Key
2. Use the api

### Example Usage:

```javascript

var result = sut.GetLatest();
result.Rates; // A dictionary of the rates

```

## Free Account Users

If you are using the free account, do not use anything other than the defaults.


## Paid Account Users

This library has not been tested with a paid account but should still work.

Created by Luke warren. More about me at [http://lukewarrendev.co.za](LukeWarrenDev.co.za)

## Contributers

To run the tests you will need to add an App.config file to the root of the integration test project

### Example

```xml

<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <appSettings>
    <add key="api.key" value="your_api_key" />
    <add key="base.country.key" value="USD" />
  </appSettings>
</configuration>

```


