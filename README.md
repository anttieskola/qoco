# Introduction
This is a repository for a coding task given by Qoco where I am currently applying for a job.

# Task
A startup company is running a large-scale SaaS application for image analysis. One of the
requirements is to be able to tell numbers present in an image. Currently the engine can
recognise numbers in the decimal numeral system, but the new requirement is to recognise
also Roman numerals. Since the result of the analysis must still be expressed in the decimal
numeral system, a conversion is required.

Your task is to implement a solution for the conversion. Since the service is based on
microservice architecture, you should implement the conversion as a new microservice with
a simple HTTP REST API. You must use C#. Other technologies and implementation details
you can choose freely. API should be very simple: It takes a string representing the number
in the Roman numeral system as the input and returns the corresponding decimal value as
the output.

The startup company values that the solution is working as expected and that the code is
easy to follow, possibly even developed further in the future. Development of this first version
shouldn’t take much longer than two hours.

# Solution

API Input: Roman numeral string
API Output: Decimal value

Command convert roman numeral string -> Event: Decimal value

# Implementation
Used dotnet templates
- sln
- classlib
- xunit
- webapi

Stole sonarbuild script from my current own project and used same libraries etc...

# Time spend
- 1.5h for project structure (first commit)
    - Even tho I copied structure from my current own project it took some time to setup
- 2.5h for the actual conversion logic, integration and unit testing
    - thought the logic would be simple but it was not until figured out using list and
    checking position and deciding if to add or subtract

# Development environment
- Debian 12
- Dotnet 7.0
- Visual Studio Code + many addons

# Links
- [Wikipedia](https://en.wikipedia.org/wiki/Roman_numerals)
