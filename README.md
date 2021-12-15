# Learning C#/.NET

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
  
  
