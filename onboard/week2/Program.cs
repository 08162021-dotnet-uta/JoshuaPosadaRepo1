using System;
using System.Text;

namespace week2
{
  class Program
  {
    static void Main(string[] args)
    {



      Console.WriteLine(ReverseCase("Happy Birthday"));


      Console.WriteLine(ReverseCase("MANY THANKS"));


      Console.WriteLine(ReverseCase("sPoNtAnEoUs"));
    }
    public static string ReverseCase(string inputstring)
    {
      StringBuilder sb = new StringBuilder();
      foreach (char x in inputstring)
      {
        if (Char.IsUpper(x))
        {

          sb.Append(Char.ToLower(x));
        }
        else
        {
          sb.Append(Char.ToUpper(x));
        }

      }

      return sb.ToString();

    }
  }
}
