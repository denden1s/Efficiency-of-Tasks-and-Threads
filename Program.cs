using System;

namespace tasks
{
  class Program
  {
    static void Main(string[] args)
    {
      int[] sortedNums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
      while(true)
      {
        Console.WriteLine("Введите количество повторений алгоритма:");
        int count = Convert.ToInt32(Console.ReadLine());
        Functions test = new Functions(count, sortedNums);
        test.MakeTestsAsync("Task");
        test.MakeTestsAsync("Thread");
        Console.ReadKey();
      }
    }
  }
}
