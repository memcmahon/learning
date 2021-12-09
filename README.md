# Learning C#

## Getting Set Up
1. Downloaded [Visual Studio for Mac](https://visualstudio.microsoft.com/downloads/)
    * Opted to also download toolkit for iOS development
    * Did not install XCode (yet)
    * Chose Visual Studio for Mac shortcuts

## [Udemy: C# for Beginners](https://www.udemy.com/course/csharp-tutorial-for-beginners/)
- C# is the language, .NET is the framework for building applications
- Code is compiled into IL (Intermediate Language) that is hardware agnostic, then compiled by CLR (Common Language Runtime) into native language.  This is done Just In Time (JIT)
  - JIT is the complition of IL code into Native *at runtime*
- .NET framework relies on classes (with attributes (data) and behaviors (methods)). Classes are organized and contained into Namespaces. Namespaces are contained into an Assembly. Many Assemblies can be contained within an application.
  - An assemply is a file (executable or DLL) that contains one or more namespaces and classes. It is a single unit of deployment of .NET applications

### Hello World
* How do I compile and run on a Mac?
* [Coding in C# on Mac w/ VS](https://www.youtube.com/watch?v=71i5C0l4POw)
   * ```$ cd <to your project directory>```
   * ```$ csc Program.cs```
   * ```$ mono Program.exe```

### Variables & Constants
- Constants are immutable
- need to declare type before assignment: 
  ```cs
  int number = 3;
  const int AnotherNumber = 3;
  ```
- Naming conventions: camelCase for variables, PascalCase for constants
- Primative Data Types
<img width="600" alt="Primative DataTypes" src="https://user-images.githubusercontent.com/32604200/145458990-7c6941b9-bd74-454d-800e-1280c2bdc963.png">
- when declaring a real number, the compiler would assume a .NET type of 'double'.  You need to include a type suffix to tell the compiler what to do:
  ```cs
  float number = 3.1f;
  decimal AnotherNumber = 3.1m;
  ```
