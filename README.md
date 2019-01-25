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

## Chapter 03. Controlling the Flow and Converting Types
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

## How to Run project?
- Be sure you have installed [dotnet](https://dotnet.microsoft.com/download)
- Open folder with project
- Run into you terminal `dotnet run`
  
e.q
```terminal
cd Chapter02/Exercise02
dotnet run
```

