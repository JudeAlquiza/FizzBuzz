# Fizz Buzz Application

## Problem
Develop a web application in C# or NodeJS that accepts an array of values. The application should do the following for each value in the array:

1.	If the value is a multiple of 3 then output the word “Fizz”
2.	If the value is a multiple of 5 then output the word “Buzz”
3.	If the value is divisible by both 3 and 5 then output the word “FizzBuzz”
4.	At the end of the run the program should display each division that was performed. 

The table below shows a list of inputs and their corresponding expected outputs.

|Input|Result|
|-----|------|
|1|Divided 1 by 3|
||Divided 1 by 5|
|3|Fizz|
|5|Buzz|
|\<empty>|Invalid Item|
|15|FizzBuzz|
|A|Invalid item|
|23|Divided 23 by 3|
||Divided 23 by 5|

&nbsp;
## Solution
The web application is built using C# and the ASP.NET Core (.NET 6) Blazor WebAssembly App project template. XUnit is used for unit tests.

The initial working version of the app was driven by a bunch of if-else constructs but has now been refactored to using the **Chain of Responsibility** design pattern which takes the messy if-else approach and turns it into an object oriented one.

The rules stated above in the problem statement has been turned into four different handlers in the code, each of these handlers handles the processing and implementation of the rules specified in the problem.

By using the **Chain of Responsibility** design pattern the rules are able to live in their own separate handler classes and can easily be unit tested. Each of the handlers have their corresponding set of unit tests, a total 39 unit tests for the handlers.

Using the **Chain of Responsibility** design pattern for this problem is a bit too much but the main take away is that when we want to introduce new rules in the future, it will not be a pain to maintain the code, compared to having a lot of if-else statements. This makes the code more de-coupled, maintainable easily testable, and can accomodate extensibility in the future without too much changes in the existing code.

&nbsp;
## Summary
The code is hosted in a git repo in GitHub which can be access via this url https://github.com/JudeAlquiza/FizzBuzz.

GitHub Action is used for Continues Integration and Deployment (CI/CD).

The C# ASP.NET Core (.NET 6) Blazor WebAssembly App is currently hosted in Azure (Free Tier Web App Service) and can be accessed via this url https://fizzbuzzbb.azurewebsites.net.
