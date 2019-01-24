# Dot Net Exercises

Repository contain solved exercices from [Book](https://www.amazon.com/7-1-NET-Core-2-0-Cross-Platform/dp/1788398076)

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

## How to Run project?
- Be sure you have installed [dotnet](https://dotnet.microsoft.com/download)
- Open folder with project
- Run into you terminal `dotnet run`
  
e.q
```terminal
cd Chapter02/Exercise02
dotnet run
```

