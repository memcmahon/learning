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

3. Add the project to the solution
```
$ dotnet sln add StringLibrary/StringLibrary.csproj
```

4. Create a class

5. Build to verify project compiles without error
```
$ dotnet build
```

6. Add a console app to the solution
```
$ dotnet new console -o ShowCase
$ dotnet sln add ShowCase/ShowCase.csproj
```

7. Add some code to the console app that uses the StringLibrary

8. Build and see that a reference needs to be added

9. Add reference in project to the StringLibrary
```
$ dotnet add ShowCase/ShowCase.csproj reference StringLibrary/StringLibrary.csproj
```

10. Run the project
```
$ dotnet run --project ShowCase/ShowCase.csproj
```

11. Create a Unit Test Project
```
$ dotnet new mstest -o StringLibraryTest
```

12. Add the test project to the solution
```
$ dotnet sln add StringLibraryTest/StringLibraryTest.csproj
```

13. Add a project reference
```
$ dotnet add StringLibraryTest/StringLibraryTest.csproj reference StringLibrary/StringLibrary.csproj
```

14. Add tests

15. run with `dotnet test`

**IMPORTANT**

In order to test classes without making them public, you will need to add an assembly update to the project .csproj file:

```c#
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net6.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <AssemblyAttribute Include="System.Runtime.CompilerServices.InternalsVisibleTo">
    <_Parameter1>WebScraperTests</_Parameter1>
    </AssemblyAttribute>
  </ItemGroup>

</Project>
```
