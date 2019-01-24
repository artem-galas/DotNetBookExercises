using System;

namespace Exercise02
{
    class Program
    {
        static void Main(string[] args)
        {
            for (var i = 0; i <= 40; i++)
            {
                Console.Write("- ");
            }

            Console.Write("\n");

            Console.WriteLine(
                "{0, -10} {1, -5} {2, 18} {3, 30}",
                "Type", "Byte(s) of Memory", "Min", "Max"
            );

            for (var i = 0; i <= 40; i++)
            {
                Console.Write("- ");
            }

            Console.Write("\n");

            const int BytesColumnPadding = -5;
            const int MinColumnPadding = 30;
            const int MaxCollumnPadding = 30;

            Console.WriteLine($"{"sbyte",-10} {sizeof(sbyte),BytesColumnPadding} {sbyte.MinValue,MinColumnPadding} {sbyte.MaxValue,MaxCollumnPadding}");
            Console.WriteLine($"{"byte",-10} {sizeof(byte),BytesColumnPadding} {byte.MinValue,MinColumnPadding} {byte.MaxValue,MaxCollumnPadding}");

            Console.WriteLine($"{"short",-10} {sizeof(short),BytesColumnPadding} {short.MinValue,MinColumnPadding} {short.MaxValue,MaxCollumnPadding}");
            Console.WriteLine($"{"ushort",-10} {sizeof(ushort),BytesColumnPadding} {ushort.MinValue,MinColumnPadding} {ushort.MaxValue,MaxCollumnPadding}");

            Console.WriteLine($"{"int",-10} {sizeof(int),BytesColumnPadding} {int.MinValue,MinColumnPadding} {int.MaxValue,MaxCollumnPadding}");
            Console.WriteLine($"{"uint",-10} {sizeof(uint),BytesColumnPadding} {uint.MinValue,MinColumnPadding} {uint.MaxValue,MaxCollumnPadding}");

            Console.WriteLine($"{"long",-10} {sizeof(long),BytesColumnPadding} {long.MinValue,MinColumnPadding} {long.MaxValue,MaxCollumnPadding}");
            Console.WriteLine($"{"ulong",-10} {sizeof(ulong),BytesColumnPadding} {ulong.MinValue,MinColumnPadding} {ulong.MaxValue,MaxCollumnPadding}");

            Console.WriteLine($"{"float",-10} {sizeof(float),BytesColumnPadding} {float.MinValue,MinColumnPadding} {float.MaxValue,MaxCollumnPadding}");
            Console.WriteLine($"{"double",-10} {sizeof(double),BytesColumnPadding} {double.MinValue,MinColumnPadding} {double.MaxValue,MaxCollumnPadding}");
            Console.WriteLine($"{"decimal",-10} {sizeof(decimal),BytesColumnPadding} {decimal.MinValue,MinColumnPadding} {decimal.MaxValue,MaxCollumnPadding}");

            for (var i = 0; i <= 40; i++)
            {
                Console.Write("- ");
            }

            Console.Write("\n");
        }
    }
}
