# RdwApi
A wrapper for the Rdw OpenData Api

## About
This library is spread so that other developers don't have to bother with wrong
status codes, integers in strings, incorrect boolean usage, weird date formats (yyyymmdd)
and empty lists when an item isn't found.

## Endpoints
For now the endpoints that are available are:
 - Car info 
 - Car fuel info

You **DON'T** need an Api Key for these endpoints. 


## Usage
### Initialize
```csharp
var rdw = new RdwClient();
```

In these examples I use full license plates: `1-BBB-11`. You can also use a license plate without dashes: `1BBB11`.

### Car info
```csharp
var car = rdw.GetCar("1-BBB-11");		 
// or GetCarAsync("1-BBB-11");

Console.WriteLine(car.Brand);               // output: BMW
```

### Fuel info
```csharp
var fuelInfo = rdw.GetFuelInfo("1-BBB-11");
// or GetFuelInfoAsync("1-BBB-11");

Console.WriteLine(fuelInfo.PowerHp);        // output: 140
```

Note: The `Car` model also contains a `FuelInfo` property that will run the `GetFuelInfo()` method in the 
background when first accessed:
```csharp
var car = rdw.GetCar("1-BBB-11");
Console.WriteLine(car.FuelInfo.PowerHp);    // output: 140
```
