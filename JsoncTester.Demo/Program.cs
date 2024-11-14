using Global;
using System;
using Xunit;
namespace Main;

static class Program
{
    [STAThread]
    static void Main(string[] originalArgs)
    {
        var t1 = JsoncTester.FromObject(
            new { x = 123, y = 456 });
        var t2 = JsoncTester.FromObject(
            new { y = 456, x = 123 });
        var t3 = JsoncTester.FromObject(
            new { x = 123, y = 4567 });
        Console.WriteLine(JsoncTester.DeepEquals(t1, t2));
        Console.WriteLine(JsoncTester.DeepEquals(t1, t3));
        Console.WriteLine(JsoncTester.JsonEquals(JsoncTester.ToJson(t1), JsoncTester.ToJson(t2)));
        Console.WriteLine(JsoncTester.JsonEquals(JsoncTester.ToJson(t1), JsoncTester.ToJson(t3)));
    }
}