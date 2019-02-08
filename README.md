# Dot Net Exercises

Repository contain solved exercices from [C# 7.1 and .NET Core 2.0 - Modern Cross-Platform Development - Third Edition](https://www.amazon.com/7-1-NET-Core-2-0-Cross-Platform/dp/1788398076) book

## Table of Contents
### Chapter 02. Speaking C#

- `Exercise02` - Create a console application that outputs the number of bytes
in memory that each of the following number types use and the minimum and maximum
possible values they can have: `sbyte`, `byte`, `short`, `ushort`, `int`, `uint`, `long`, `ulong`, `float`, `double`, and `decimal`.

```terminal
- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
Type       Byte(s) of Memory                Min                            Max
- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
sbyte      1                               -128                            127
byte       1                                  0                            255
short      2                             -32768                          32767
ushort     2                                  0                          65535
int        4                        -2147483648                     2147483647
uint       4                                  0                     4294967295
long       8               -9223372036854775808            9223372036854775807
ulong      8                                  0           18446744073709551615
float      4                      -3.402823E+38                   3.402823E+38
double     8             -1.79769313486232E+308          1.79769313486232E+308
decimal    16    -79228162514264337593543950335  79228162514264337593543950335
- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
```

### Chapter 03. Controlling the Flow and Converting Types
- `Exercise03` - simulated FizzBuzz game counting up to 100.

```terminal
1, 2, Fizz, 4, Buzz, Fizz, 7, 8, Fizz, Buzz, 11, Fizz, 13, 14, FizzBuzz, 16, 17,
Fizz, 19, Buzz, Fizz, 22, 23, Fizz, Buzz, 26, Fizz, 28, 29, FizzBuzz, 31, 32,
Fizz, 34, Buzz, Fizz, 37, 38, Fizz, Buzz, 41, Fizz, 43, 44, FizzBuzz, 46, 47,
Fizz, 49, Buzz, Fizz, 52, 53, Fizz, Buzz, 56, Fizz, 58, 59, FizzBuzz, 61, 62,
Fizz, 64, Buzz, Fizz, 67, 68, Fizz, Buzz, 71, Fizz, 73, 74, FizzBuzz, 76, 77,
Fizz, 79, Buzz, Fizz, 82, 83, Fizz, Buzz, 86, Fizz, 88, 89, FizzBuzz, 91, 92,
Fizz, 94, Buzz, Fizz, 97, 98, Fizz, Buzz,
```
- `Exercise04` - Create a console application that asks the user for two numbers in the range *0-255* and then divides the first number by the second:

```terminal
Enter a number between 0 and 255: 100
Enter a second number between 0 and 255: 10
100 / 10 = 10

Enter a number between 0 and 255: 900
Enter a second number between 0 and 255: apple
Input string shold be a number, try 10

Enter a number between 0 and 255: 900
Enter a second number between 0 and 255: -5
System.ArgumentException firstNumber must be lower than 255 and bigger than 0.
```
### Chapter 04. Writing, Debugging, and Testing Functions
-`Exercise05` - Create a console application with method named `PrimeFactors`
that, when passed an int variable as a parameter, returns a string showing its prime factors.

For this exercise I created `PrimeFactorLib` which contain classlib `PrimeFactor` with method `Calculate`.
`PrimeFactorUnitTests` - using `xUnit` and test functionality for `PrimeFactorLib`.

For adding `PrimeFactorLib` to `Exercise05` console application I added line into `Exercise05.csproj`

```xml
<ItemGroup>
    <ProjectReference Include="../PrimeFactorLib/PrimeFactorLib.csproj" />
</ItemGroup>
```

```terminal
Please add a number: 4
Prime Factor for 4 = 2*2

Please add a number: 40
Prime Factor for 40 = 2*2*2*5

Please add a number: banana
You add is not a number
```

### Chapter 05/06 Classes and Interfaces.
Create a class named `Shape` with properties named `Height`, `Width`, and `Area`.
Add three classes that derive from it `Rectangle`, `Square`, and `Circle` with any
additional members you feel are appropriate and that override and implement the `Area`
property correctly.

Created a `ShapeLibrary` where all classes are implement, and ShapeLibTests for testing those classes.
```terminal
$ dotnet test
Total tests: 12. Passed: 12. Failed: 0. Skipped: 0.
Test Run Successful.
```

### Chapter 07/08. Using Common .NET Standard Types

Create a console application that prompts the user to enter a regular
expression, and then prompts the user to enter some input and compare the two for a match until the user presses `Esc`:

```terminal
Enter a regular exeption or use default ^[a-z]+$:
Enter some inputs: apple
apple mathces to ^[a-z]+$: True
Press ESC to end or any key to try again
Enter a regular exeption or use default ^[a-z]+$: ^[0-9]+$
Enter some inputs: 09991345
09991345 mathces to ^[0-9]+$: True
Press ESC to end or any key to try again
```

### Chapter 09. Working with Files, Streams, and Serialization.

Create a console application that creates a list of shapes, uses
serialization to save it to the filesystem using XML, and then deserializes it back.
Shapes should have a read-only property named `Area` so that when you deserialize, you
can output a list of shapes, including their areas, as shown here:

I created XML serialization and JSON serialization
```terminal
Written 546 bytes of XML to Chapter09/Exercise09/shapes.xml
Written 264 bytes of JSON to Chapter09/Exercise09/shapes.json
```

Most probably for solving this exercise should use [IXmlSerializable](https://docs.microsoft.com/en-us/dotnet/api/system.xml.serialization.ixmlserializable)
But I dont get how it works.

## How to Run project?
- Be sure you have installed [dotnet](https://dotnet.microsoft.com/download)
- Open folder with project
- Run into you terminal `dotnet run`
  
e.q
```terminal
cd Chapter02/Exercise02
dotnet run
```

