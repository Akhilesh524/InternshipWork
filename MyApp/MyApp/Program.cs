using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

public class Program
{
   public static int add(int a, int b)
    {
        return a + b;
    }

   public static int sub(int a, int b)
    {
        return a - b;
    }

    public static int mul(int a, int b)
    {
        return a * b;
    }

    public static int div(int a, int b)
    {
        return b / a;
    }
    static void Main(string[] args)
    {
        int a = 4;
        int b = 3;

        Console.WriteLine("Addition"+add(a, b));

        Console.WriteLine("subtraction" + sub(a, b));

        Console.WriteLine("mul" + mul(a, b));

        Console.WriteLine("div" + div(a, b));

   
    }

   
}
