# Vehicle Bid Calculation API

## Description

The Vehicle Bid Calculation API is an ASP.NET Core Web API designed to calculate the total price of a vehicle at a car auction. It takes into account various fees and costs associated with the vehicle's price and type.

## Features

Calculate Total Price: The API provides an endpoint to calculate the total price of a vehicle. It considers the vehicle's price, type (Common or Luxury), and adds applicable fees.


## Getting Started

### Prerequisites
.NET 6 SDK<br/>
Visual Studio 2022<br/>

### Installation

Clone the repository:<br/>
git clone https://github.com/alejocastano/BlankFactor.git<br/>
Open the solution file (BlankFactor.sln) in Visual Studio 2022.<br/>
Restore the NuGet packages by right-clicking on the solution and selecting "Restore NuGet Packages."<br/>
Build the solution by pressing Ctrl + Shift + B.<br/>

## Running the Application
Set the API project as the startup project by right-clicking on the project in the Solution Explorer and selecting "Set as Startup Project."<br/>
Start the application by pressing F5 or clicking the "Start" button in Visual Studio. This will run the application and open a web browser with the Swagger UI.<br/>
Use the Swagger UI to test the API endpoints.<br/>

## API Usage
Calculate Total Price<br/>
Endpoint: POST /api/Vehicle/CalculateTotalPrice<br/>
Description: Calculates the total price of a vehicle based on its price and type.<br/>
Request Body Examples:<br/>
<br/>
For a common vehicle:<br/>

```json
{
    "price": 1000,
    "type": "Common"
}
```
For a luxury vehicle:<br/>

```json
{
    "price": 1000,
    "type": "Luxury"
}
```

<br/>
Responses:<br/><br/>
200 OK: Returns the total price of the vehicle.<br/><br/>
400 Bad Request: If the vehicle object is null or invalid.<br/><br/>
500 Internal Server Error: If an error occurs while processing the request.<br/><br/>
