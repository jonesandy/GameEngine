<img src="./_docs/2092016.png" align="left" height="150px" />

# Testing Code with xUnit

![Pluralsight badge](https://img.shields.io/badge/-Pluralsight-grey?style=flat-square&logo=pluralsight)
![Skills practice badge](https://img.shields.io/badge/Skills-Practice-ff69b4?style=flat-square)
![Testing with xUnit badge](https://img.shields.io/badge/Testing-xUnit-black?style=flat-square)

----

## About

This repo is for housing practicals following along with a Pluralsight course on testing .NET code with [xUnit](https://xunit.net/) framework. It is one repo in a series of repositories for the Pluralsight xUnit learning pathway.

This course was an introduction to some of the features available inside xunit and to get up and running with this framework.

It was interesting to discover some of the Asserts that are available, how to catagorise tests to enable running of certain subsets of tests, creating data driven tests, and how to share contexts between test methods and test classes.

## Running tests

To use this project you will need .NET Core 3.1 installed.

To run tests via a command line/terminal navigate to the ```GameEngine.Tests``` folder then run

```powershell

dotnet test

```

The following traits are available for running certain subsets of tests via command line:

```powershell
Category=Enemy
Category=GameState
Category=NonPlayer
Category=Player
SharedCollection=GameState
Theory=HealthDamageData
Theory=InlineData
Theory=MemberData

# Example use from inside the GameEngine.Tests folder
dotnet test --filter Category=Player
```

If using Visual Studio code, use the Test Explorer to run using build in tools.
