# Moonpig
Moonpig automated tests

Description
===========
This automated test example was developed to show a very simple starting point for test automation. 
It was written in C# .NET with Selenium using Visual Studio, as these technologies are commonly used in Moonpig (according to some internet researching). They were also used to demonstrate a mix of several skillsets (C#, Selenium, Selenium).
Currently hey simply use the unit test call 'Assert' for gathering results, but another approach could easily be implemented if required.

Pre-requisites
==============

1. Download the entire project into a folder called C:\Tests\Moonpig.

3. Download the Chrome web driver from https://sites.google.com/a/chromium.org/chromedriver/downloads.

4. Add the folder containing the chromedriver.exe file to the Windows PATH variable.


Running the tests
=================

1. Open the project in Visual Studio.

2. Press CTRL+r then "a" to run all the tests.

The results are displayed in the Test Results pane of Visual Studio. 

They are also saved to C:\Tests\Moonpig\TestResults\TestResults_*.txt in a format that could easily be read into a more sophisticated reporting system, developed at a later stage.
