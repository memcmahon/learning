# Learning C#/.NET

## Getting Set Up (Visual Studio)
1. Downloaded [Visual Studio for Mac](https://visualstudio.microsoft.com/downloads/)
    * Opted to also download toolkit for iOS development
    * Did not install XCode (yet)
    * Chose Visual Studio for Mac shortcuts

## Getting Set Up (VS Code)
After using Visual Studio, I switched to VSCode.  Since I already had dotnet installed from the steps above, I can now run the following to startup and run a console app:
```bash
$ mkdir project_directory && cd project_directory
$ dotnet new console
$ dotnet run
```

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
- Non-Primative Types: String, Array, Enum, Class
- Char uses single quotes, String uses double quotes: ```char letter = 'A'; string word = "hello";```
- **In most cases, it is sufficient to declare variables with `var` which will auto determine datatype: ```var number = 3```**

### Overflow
- There is no automatic checking of variable manipulation to see if you are going to exceed your memory allocation,  if you go over at compilation, that variable will be reset.  You can use `checked` to raise an exception on runtime if there will be any overflow
  ```cs
  byte number = 255 //max value of byte type
  number = number + 1 //now number will be 0
  ```
  ```cs
  checked {
    byte number = 255
    number = number + 1
  }
  //this will raise an exception at runtime
  ```

### Type Conversion
- Implicit; the compiler will handle these just fine because there is no chance of data loss - the conversion is from small to large
  ```cs
  byte b = 1;  // 00000001
  int i = b;   // 00000000 00000000 00000000 00000001
  ```
- Explicit; When the conversion is from large to small, there is a chance for data loss, so the compiler will not auto convert
  ```cs
  int i = 1;
  byte b = i; // won't compile, so you need to:

  int i = 1;
  byte b = (byte) i; // this is called casting
  ```
 - Non-compatible types; when you need to convert say a string to a number
   ```cs
   string s = "1";
   int i = Convert.ToInt32(s);
   int j = int.Parse(s);
   ```

 ### Operator weirdness
 - Incrementing by one with `++` or `--`.  Can be used as prefix or postfix:
   ```cs
   var a = 1;
   var b = a++;

   //a: 2, b: 1
   ```
   ```cs
   var a = 1;
   var b = ++a;

   //a: 2, b: 2

 ### Class
 ```cs
  public class Person
    {
        public string FirstName;
        public string LastName;

        public void Introduce()
        {
            Console.WriteLine("My name is " + FirstName + " " + LastName);
        }
    }

var john = new Person();
john.FirstName = "John";
john.LastName = "Smith";
john.Introduce();
```

```cs
public class Calculator
    {
        public static int Add(int a, int b)
        {
            return a + b;
        }
    }

Calculator.Add(1, 3);
```

- When declaring a method on a class, you must indicate the return type, or 'void' if there is none.
- Static methods are like ruby class methods - they are called on the class itself, not on an instance of that class.
- typically one class per file 😰 after moving classes to different files, it became much more difficult to compile and execute from terminal, so I went back to running code through VS itself.

- To create an instance with attributes already defined:
  ```cs
  public class Person
  {
      public int Age;
  }

  var person = new Person() {Age = 20};
  ```

### Structs
- Similar to classes, structs combine data and functions.
- In the real world, you will most often use classes, not structures.
- Use structures when you want to define very small things, like RgbColor, or a Point (with x/y coord)
- Structs are good when you need to create ALOT of something

```cs
public struct Point
{
  public int x;
  public int y;
}
```

### Arrays
- Stores a collection of variables of the same type:
  ```cs
  int number1;
  int number2;
  int number3;

  //could be arrayed as:

  int[] numbers = new int[3];
  ```
- Arrays have a fixed size, it must be indicated at creation and cannot be changed.
- Array is a class, because it is an object, we need to allocate memory for it.
- example:
  ```cs
  var numbers = new int[3];
  numbers[0] = 1;
  numbers[1] = 2;
  numbers[2] = 3;

  //OR

  var numbers = new int[3] {1, 2, 3};
  ```

- If you do not assign values to each index, the values will be the default for that datatype (0 for int, false for bool, etc...)

### Strings
- A string is a sequence of characters (not just one)
- string literal ```var name = "John";```
- string concatenation ```var name = firstName + " " + lastName;```
- string format ```var name = string.Format("{0} {1}", firstName, lastName);```
- string join ```var numbers = new int[3] {1, 2, 3}; var list = string.Join(",", numbers);```
- string characters can be accessed with an index.
- in c#, strings are immutable; once created, they can not be changed.
  - there are methods that can manipulate strings, but they return *new* strings, the original is not changed.
- verbatim string (to avoid having to escape characters) ```string path = @"c:\projects\project1\folder1"```
- STRINGS ARE IMMUTABLE


### Enums
- used to translate codes to actions/status
- often used instead of a group of related constants
- defined at the namespace level
```cs
namespace DemoProject
{
    public enum ShippingMethod
    {
        RegularAirMail = 1,
        RegisteredAirMail = 2,
        Express = 3
    }

    class Program
    {
        static void Main(string[] args)
        {
            var method = ShippingMethod.RegularAirMail;
            Console.WriteLine((int)method);

            var methodId = 3;
            Console.WriteLine((ShippingMethod)methodId);

            Console.WriteLine(method.ToString());
            // Console.WriteLine will automatically call .ToString() on any argument

            var methodName = "RegisteredAirMail";
            var shippingMethod = (ShippingMethod)Enum.Parse(typeof(ShippingMethod), methodName);
            Console.WriteLine(shippingMethod);
        }
    }
}
```

### Conditional Statements
- If/Else
  ```cs
  if (condition)
  {
    //some action
  }
  else if (condition)
  {
    //some action
  }
  else
  {
    //some action
  }
  ```
- curly braces are only _necessary_ when the block is more than one line long, but may be best convention to always use them?
- condition operator ```condition ? resultIfTrue : resultIfFalse;```


- Switch/Case
  ```cs
  var season = Season.Autumn;

  switch (season)
  {
      case Season.Autumn:
          Console.WriteLine("It's Autumn; what a beautiful season!");
          break;
      case Season.Summer:
          Console.WriteLine("We've got a promotion");
          break;
      default:
          Console.WriteLine("I don't understand this season!");
          break;
  }
  ```
  ```cs
  var season = Season.Autumn;

  switch (season)
  {
      case Season.Autumn:
      case Season.Summer:
          Console.WriteLine("We've got a promotion");
          break;
      default:
          Console.WriteLine("I don't understand this season!");
          break;
  }

  // this will return 'promotion' for either autumn or summer.
  ```

### Iterative Statements
- Four iteration statements: for, foreach, while, dowhile
- For Loops
  ```cs
  for (var i = 0; i < 10; i++) // initialization clause; condition clause; iteration clause
  {
    ...
  }
  ```
- Foreach Loops (used for any numerical)
  ```cs
  foreach (var number in numbers)
  {
    ...
  }
  ```
- While Loop
  ```cs
  while (i < 10)
  {
    ...
  }
  ```
- Do-While Loops (the loop is executed at least once)
  ```cs
  do
  {
    ...
    i++
  } while (i < 10);
  ```
- `break;` jumps out of a loop
- `continue;` goes to the next iteration

### Arrays
- There are single, and multi-dimensional arrays.
- Single:
- Multidemensional:
  - can be rectangular or jagged
  - rectangular (2D):
    - `var matrix = new int[3, 5];`
    - ```cs
      var matrix = new int[3, 5]
      {
        { 1, 2, 3, 4, 5 },
        { 6, 7, 8, 9, 10 },
        { 11, 12, 13, 14, 15 }
      };
      ```
    - above is the object initialization syntax
    - accessing an element: `var element = matrix[0, 0]`;
  - rectangular (3D):
    - `var colors = new int[3, 5, 4];`
  - Jagged (array of arrays)
  - First, create a top level array, then initialize each element into a new array (the two square brackets indicate that it will be a jagged array):
    - ```cs
      var array = new int[3][];
      array[0] = new int[4];
      array[1] = new int[5];
      array[2] = new int[3];
      ```
  - Some useful methods:
    - instance: .Length
    - static: .IndexOf(), .Clear(), .Copy(), .Reverse(), .Sort()


### Lists
- Similar to Array, but it has dynamic size
- `var numbers = new List<int>();`
- `var numbers = new List<int>() { 1, 2, 3 };`
- Some useful methods:
  - Add(), AddRange(), Remove(), RemoveAt(), IndexOf(), Contains(), Count

**Important** You can not modify an array or list inside a `foreach`, to do this, you must use a basic `for` loop

### StringBuilder
- Allows you to create and work with _mutable_ strings.
- Not optimized for searching (no IndexOf, etc...)

### Out vs Ref
Consider the following:
```c#
class Program
{
    static void Main(string[] args)
    {
        int a = 10;
        ChangeNumber(a);
        Console.WriteLine(a);
    }

    static void ChangeNumber(int a)
    {
        a = 90;
    }
}
```

This snippet would output `10` to the terminal because integers are pass by value, or a Value Type.  But, we can force arguments to be treated as reference by using the `ref` or `out` keywords. `ref` requires that the variable be assigned prior to use; `out` requires that the argument be changed during method execution:

```c#
class Program
{
    static void Main(string[] args)
    {
        int a = 10;
        ChangeNumber(ref a);
        Console.WriteLine(a);
    }

    static void ChangeNumber(ref int a)
    {
        a = 90;
    }
}

// OR

class Program
{
    static void Main(string[] args)
    {
        int a;
        ChangeNumber(out a);
        Console.WriteLine(a);
    }

    static void ChangeNumber(out int a)
    {
        a = 90;
    }
}
```

### Null Coalescing Operator
```c#
class Program
{
    static void Main(string[] args)
    {
        string person = null;
        string newPerson = person ?? "Megan";

        Console.WriteLine(newPerson);
    }
}
```

### const vs readonly

`const` is implicitly _static_, `readonly` in implicitly _instance_.  `readonly` can also be declared without assignment.  `const`s can only hold standard c# types, no custom class types.

### Classes
```c#
// Person.cs
using System;

namespace SomeName
{
    class Person
    {
        // Fields - should remain private to the class, and are private by default.
        string _ssn;

        // Properties - getter/setter methods that should be used to reveal some/all field information.
        public string Birthday { get; set; }
        public string FirstName { get; }
        public string LastName { get; }
        public string SSN {
            get {
                return _ssn;
            }
            set {
                if (value.Length < 1)
                {
                    Console.WriteLine("Invalid Input");
                }

                _ssn = value;
            }
        }

        // Constructor - allows you to set some field/property information on instanciation.
        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        // Methods - behaviors
        public void Eat()
        {
            Console.WriteLine("I'm Eating");
        }

        public void Sleep()
        {
            Console.WriteLine("I'm Sleeping");
        }
    }
}

// SuperPerson.cs
using System;

namespace SomeName
{
    // SuperPerson Inherits from Person
    class SuperPerson : Person
    {
        // constructor uses the base setup of the inherited class, and could do additional constructing, if needed.
        public SuperPerson(string FirstName, string LastName) :
            base(FirstName, LastName)
        {
        }

        public void Fly()
        {
            Console.WriteLine("I'm flying!");
        }
    }
}

// Program.cs
using System;

namespace WebScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new SuperPerson("Megan", "McMahon");
            person.Birthday = "June 19";
            person.SSN = "DATA";
            Console.WriteLine(person.Birthday);
            Console.WriteLine(person.FirstName);
            Console.WriteLine(person.SSN);
            Console.WriteLine(person.LastName);
            person.Eat();
            person.Sleep();
            person.Fly();
        }
    }
}
```



## [Building a .Net API](https://docs.microsoft.com/en-us/learn/modules/build-web-api-aspnet-core/)
### Setup
- downloaded VSCode
- downloaded .Net 6.0 ARM
- Trying to download
  ```bash
  $ dotnet tool install -g Microsoft.dotnet-httprepl
    Tools directory '/Users/megan/.dotnet/tools' is not currently on the PATH environment variable.
    If you are using zsh, you can add it to your profile by running the following command:

    cat << \EOF >> ~/.zprofile
    # Add .NET Core SDK tools
    export PATH="$PATH:/Users/megan/.dotnet/tools"
    EOF

    And run `zsh -l` to make it available for current session.

    You can only add it to the current session by running the following command:

    export PATH="$PATH:/Users/megan/.dotnet/tools"

    You can invoke the tool using the following command: httprepl
    Tool 'microsoft.dotnet-httprepl' (version '6.0.0') was successfully installed.
  $ cat << \EOF >> ~/.zshrc   
    # Add .NET Core SDK tools
    export PATH="$PATH:/Users/megan/.dotnet/tools"
    EOF
  $ zsh -l
  $ dotnet tool install -g Microsoft.dotnet-httprepl
    Tool 'microsoft.dotnet-httprepl' is already installed.
  ```
- In order to get httprepl running per the instructions in Unit 3.5, I needed to ```$ dotnet dev-certs https --trust```
