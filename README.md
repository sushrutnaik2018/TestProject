# ApiTestProject
This is a RESTful API testing project using C#, .NET Core, NUnit, Extent Report, HttpClient and Fluent Assertions to test JSONPlaceholder REST API.

## Extent Report
Use define, manage and generate elegant html report in .NET projects.
https://www.extentreports.com/

## Target framework
.NET 6.0

## NUnit
NUnit is a unit-testing framework for all .Net languages. Initially ported from JUnit, the current production release, version 3, has been completely rewritten with many new features and support for a wide range of .NET platforms.
https://nunit.org/

## JSONPlaceholder
JSONPlaceholder is a free online REST API that you can use whenever you need some fake data. It's great for tutorials, testing new libraries, sharing code examples.
https://jsonplaceholder.typicode.com/

## Routes Tested
The following HTTP methods are tested:
* GET
* POST
* PUT
* PATCH
* DELETE

## HttpClient
HttpClient class provides a base class for sending/receiving the HTTP requests/responses from a URL. It is a supported async feature of .NET framework. HttpClient is able to process multiple concurrent requests. It is a layer over HttpWebRequest and HttpWebResponse. All methods with HttpClient are asynchronous.
https://docs.microsoft.com/en-us/uwp/api/windows.web.http.httpclient

## Assertions
Fluent Assertions is used for validation.
https://fluentassertions.com/ 

## Integrated Development Environment
Microsoft Visual Studio IDE is used to develop this project.

### Build Solution
* Build => Build Solution

### Run Tests
* Test => Windows => Test Explorer => Run All

### Run Tests with Command Prompt/Windows PowerShell
* Open Folder in File Explorer: ..\ApiTestProject\bin\Debug\net6.0
* Open Command Prompt/Windows PowerShell
* Run "dotnet vstest ApiTestProject.dll"


# UITestProject
This is a UI testing Framework using C#, .NET Core, NUnit, Extent Report, Selenium WebDriver, Webdriver Manager using POM to test Sample application under test.

## Extent Report
Use define, manage and generate elegant html report in .NET projects.
https://www.extentreports.com/

## Target framework
.NET 6.0

## Selenium WebDriver
WebDriver drives a browser natively, as a user would, either locally or on a remote machine using the Selenium server, marks a leap forward in terms of browser automation.
https://www.selenium.dev/documentation/webdriver/

## POM
A Page Object only models these as objects within the test code. This reduces the amount of duplicated code and means that if the UI changes, the fix needs only to be applied in one place.
https://www.selenium.dev/documentation/test_practices/encouraged/page_object_models/

## NUnit
NUnit is a unit-testing framework for all .Net languages. Initially ported from JUnit, the current production release, version 3, has been completely rewritten with many new features and support for a wide range of .NET platforms.
https://nunit.org/

## WebDriver Manager
This is small library aimed to automate the Selenium WebDriver binaries management inside a .Net project.
https://github.com/rosolko/WebDriverManager.Net

## Integrated Development Environment
Microsoft Visual Studio IDE is used to develop this project.

### Build Solution
* Build => Build Solution

### Run Tests
* Test => Windows => Test Explorer => Run All

### Run Tests with Command Prompt/Windows PowerShell
* Open Folder in File Explorer: ..\UITestProject\bin\Debug\net6.0
* Open Command Prompt/Windows PowerShell
* Run "dotnet vstest UITestProject.dll"
