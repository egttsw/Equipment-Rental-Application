## Overview

I made the project as ASP.NET 5.0 MVC Core Application following the principles of CRUD operations and using EntityFramework Core.
I used code first approach with the SQL database creation to store both form inputs as well as the order history. User management was skipped.
Although I created the databases with code I still used MSSQL server for testing.

For running the project I used IIS Express with Google Chrome as the development browser.


## Models

- Equipment model is for storing the equipment that is available for loan. I used the example data given in the assignment.
- Item model store the data that is entered by the user and serves as a shopping cart.
- History model holds the order history and is also used for generating the invoice.


## Views

The main information is given on the home screen and the other views are mostly self-explanatory.
Validation is added for the duration and is not needed for rented items since that input is limited with the dropdown menu.
The data is mostly represented in tables that are linked with the database.


## Controllers

Since purchase history was one of the options on the Home page and had so little function on itself, I included it to the Home controller.
The only other APIs that it hosts is clearing the databases mapped to Item and History models. But that is just for testing purposes.

The rest of the functionality is made in the Item controller where the CRUD opperations are stored. The orders are also stored to history within this controller.


## Helpers

The price calculations were needed for both controllers so I used an external helper class to do so. That is found in the Helpers folder.


## Invoice

I used Rotativa.AspNetCore NuGet package for creating the PDF. The template for the invoice was taken from an open-source example on GitHub and the reference is in the invoice view.


## Loayalty points

Because user management is not implemented, I made the loyalty point calculations with a simple Javascript onload function. Otherwise I would have also stored those as a property of the user model.
PS! Similar Javascript function is also used for calculating the total price for the Items list.


## Unit tests

I made some simple unit tests to check the routes taken in the controller APIs. I also did tests for the price calculation function.

The project containing the unit tests is in the following repository: https://github.com/egttsw/UnitTestRentalApp
I used the NuGet package MS.Test.TestAdapter. Simply installing the latest NuGet test package and running all tests should do the trick.
Right click the Dependancies and Add Project Reference: Equpment-Rental-Application.
 
If I had more time I would have implemented integration or end-to-end testing for detecting any problems related to storing data in the SQL databases. I currently skipped it since I was already past the expected deadline.


## Style

I did not focus much effort on the styling nor the design. I used Bootstrap here and there to keep it from looking absolutely disgraceful.