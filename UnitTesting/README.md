# Testing
## Unit Testing

While working through this udemy course, I needed to take a step back to the docs to research how to test with VS Code and one of the testing libraries (mstest).

To walk through the docs, I am going to start with [this class tutorial](https://docs.microsoft.com/en-us/dotnet/core/tutorials/library-with-visual-studio-code?pivots=dotnet-6-0), followed by the [testing tutorial](https://docs.microsoft.com/en-us/dotnet/core/tutorials/testing-library-with-visual-studio-code?pivots=dotnet-6-0).

Also diving in to more [docs/videos](https://www.youtube.com/playlist?list=PLdo4fOcmZ0oWoazjhXQzBKMrFuArxpW80) on .NET.

### Creating a Class Library

Commits will be after each step.

1. Create new solution (in the UnitTesting directory)
```
$ dotnet new sln
```

2. Create a class library project
```
$ dotnet new classlib -o StringLibrary
```
