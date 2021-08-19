using System;
using System.Collections;

namespace HelloCsharp
{
  class Program
  {
    //Build a simple calculator using 6 methods: add, Multiply, Subtract, Divide, Print

    static double Add(double x, double y)
    {
      return x + y;
    }

    static double Multiply(double x, double y)
    {
      return x * y;
    }
    static double Subtract(double x, double y)
    {
      return x - y;
    }
    static double Divide(double x, double y)
    {
      return x / y;
    }
    static void Calculator(String s)
    {
      char[] charArr = s.ToCharArray();
      int size = charArr.Length;
      Stack stack = new Stack(size);
      double first_number;
      double second_number;
      double result = 0;
      double char_to_double = 0;
      bool continue_operation = true;

      for (int i = 0; i < size; ++i)
      {
        //Transforms the characters into doubles bigger than 9 and adds the result to the stack
        if (Char.IsDigit(charArr[i]))
        {
          while (Char.IsDigit(charArr[i]))
          {
            char_to_double += ((double)charArr[i] - 48);
            char_to_double = char_to_double * 10;
            i++;
            if (i >= size)
              break;
          }
          result = char_to_double / 10;
          i--;//if the number is less than 9 this allows for the code to work
          if (char_to_double != 0) //this catches number greater than 9
          {
            stack.Push(char_to_double / 10);
          }

          char_to_double = 0;
        }
        //Adds the operators of Plus and Minus to the stack
        else if (charArr[i] == '+' || charArr[i] == '-')
        {
          stack.Push(charArr[i]);
        }
        //Does the arithmetic of Multiply and Divide and adds the result to the stack
        else if (charArr[i] == '*' || charArr[i] == '/')
        {
          first_number = (double)stack.Pop();
          if (Char.IsDigit(charArr[i + 1]))
            second_number = (double)charArr[++i] - 48;
          else
            second_number = 0;
          switch (charArr[i - 1])
          {
            case '*':
              result = Multiply(first_number, second_number);
              stack.Push(result);
              break;
            case '/':
              if (second_number == 0)
              {
                Console.WriteLine("Divide by Zero Error");
                break;
              }
              result = Divide(first_number, second_number);
              stack.Push(result);
              break;
            default:
              Console.WriteLine("Error in the switch case statement: " + charArr[i - 1]);
              continue_operation = false;
              break;
          }
        }
        else
        {
          Console.WriteLine("Error in the switch case statement: The operator or character is not supported: " + charArr[i]);
          continue_operation = false;
        }

      }
      if (continue_operation)
        while (stack.Count > 0)
        {
          first_number = (double)stack.Pop();
          if (stack.Count > 0)
          {
            // Console.WriteLine(stack.Peek());
            switch ((char)stack.Pop())
            {
              case '+':
                // if ((double)stack.Peek() == 0) //not 100% sure why this is happening. The logic is in the first isDigit section
                //   stack.Pop();
                result = Add(first_number, (double)stack.Pop());
                stack.Push(result);

                break;
              case '-':
                // if ((double)stack.Peek() == 0) //not 100% sure why this is happening. The logic is in the first isDigit section
                //   stack.Pop();
                result = Subtract((double)stack.Pop(), first_number);
                stack.Push(result);
                break;
              default:
                Console.WriteLine(first_number);
                break;
            }

          }
        }
      if (continue_operation)
        Print(result);
    }

    static void Main(string[] args)
    {
      Console.WriteLine("Write arithmetic operation:");
      string s = Console.ReadLine();
      Calculator(s);
    }
    static void Print(double result)
    {
      Console.WriteLine("Ans: " + result);
    }
  }
}
