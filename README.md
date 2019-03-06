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

### Chapter 10. Protecting Your Data and Applications

Create a console application that protects an XML file. The credit card must be encrypted so that it can be decrypted
and used later, and the password must be salted and hashed.
Opens the XML file that you protected
in the preceding code and decrypts the credit card number.

XML file like a DB, so I there we can store `Salt`, `HashedPassword` and `CardNumber`.
HashedPassword is generated by SHA256 Algorithm and `slat` which was created dynamically for each user, so even if user has the same password `HashedPassword` must be different.

For `DecryptCardNumber` and `EncryptCardNumber` use [Rfc2898DeriveBytes](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.rfc2898derivebytes?view=netframework-4.7.2)

If password from user input is not the same, which was stored on XML, application throw `ArgumentError`

[XMLFile](Chapter10/Exercise10/customers.xml)

```terminal
See cusomers.xml document

Press enter for Decrypt

Please provide a password for a user Artem Halas
1234567
Artem Halas have card 4242424242
Please provide a password for a user John Snow
IDontKnow
Wrong Password for John Snow
```

### Chapter 11. Working with Databases Using Entity Framework Core
Create a console application that queries the `Northwind` database for
all the categories and products, and then serializes the data using at least three formats of serialization available to .NET Core.
Which format of serialization uses the least number of bytes?

### Chapter 12. Querying and Manipulating Data Using LINQ
Create a console application, that prompts the user for a city and then
lists the company names for `Northwind` customers in that city.
Enhance the application by displaying a list of all unique cities that customers already reside in as a prompt to the user before they enter their preferred city.

```terminal
There are available cities:
Aachen, Albuquerque, Anchorage, Barcelona, Barquisimeto, Bergamo, Berlin, Bern,
Boise, Brandenburg, Bruxelles, Bräcke, Buenos Aires, Butte, Campinas, Caracas,
Charleroi, Cork, Cowes, Cunewalde, Elgin, Eugene, Frankfurt a.M., Genève, Graz,
Helsinki, I. de Margarita, Kirkland, Kobenhavn, Köln, Lander, Leipzig, Lille,
Lisboa, London, Luleå, Lyon, Madrid, Mannheim, Marseille, Montréal, México D.F.,
München, Münster, Nantes, Oulu, Paris, Portland, Reggio Emilia, Reims, Resende,
Rio de Janeiro, Salzburg, San Cristóbal, San Francisco, Sao Paulo, Seattle,
Sevilla, Stavern, Strasbourg, Stuttgart, Torino, Toulouse, Tsawassen, Vancouver,
Versailles, Walla Walla, Warszawa, Århus, 

Enter name of the city: London
There are 6 customers in London
Around the Horn
B's Beverages
Consolidated Holdings
Eastern Connection
North/South
Seven Seas Imports
```

### Part 3.
### NorthiwindWeb
Simple web app uses [RazorPages](https://docs.microsoft.com/en-us/aspnet/core/razor-pages/?view=aspnetcore-2.2&tabs=visual-studio-code)
Includes these pages:
- `suppliers` - display all Suppliers from db
- `suppliers/detail/:id` - display all necessary information about one certain Supplier
- `/products` - display all Products from db
- `products/detail/:id` - display all necessary information about one certain Product
- `/` - home page for application `Index.cshtml`
- `_Layout.cshtml` - base layout for all application pages

- *NorthwindEntitiesLib* - simple classlib which includes all entities describtion from `Nortwind.db`
- *NorthwindContextLib* - simble classlib which connect entities to DB

### NortwindApi
Simple appi with one endpoind `/api/customers` and with `swagger` documentation

## How to Run project?
- Be sure you have installed [dotnet](https://dotnet.microsoft.com/download)
- Open folder with project
- Run into you terminal `dotnet run`
  
e.q
```terminal
cd Chapter02/Exercise02
dotnet run
```

