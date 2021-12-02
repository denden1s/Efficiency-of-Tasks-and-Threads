using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace tasks
{
  class Functions
  {
    private List<Task> _tasks;
    private List<Thread> _threads;
    private Stopwatch timer;
    private int _numForSearch;
    private int _finaledCount;
    public int _operationCount;
    public int[] nums;

    private void BinarySearch()
    {
      Array.BinarySearch(nums, _numForSearch);
      _finaledCount++;
    }
    public Functions(int count, int[] nums)
    {
      _finaledCount = 0;
      _operationCount = count;
      this.nums = nums;
      _threads = new List<Thread>();
      _tasks = new List<Task>();
      timer = new Stopwatch();
      _numForSearch = nums[nums.Length - 1];
      for(int i = 0; i < _operationCount; i++)
      {
        Thread th = new Thread(new ThreadStart(BinarySearch));
        _threads.Add(th);
        _tasks.Add(new Task(BinarySearch));
      }
    }
    public void MakeTestsAsync(string type)
    {
      _finaledCount = 0;
      if(type == "Task")
      {
        timer.Start();
        foreach(Task t in _tasks)
          t.RunSynchronously();

        timer.Stop();
        Console.WriteLine($"Кол-во выполненных задач: {_finaledCount}");
      }
      else if(type == "Thread")
      {
        timer.Start();
        foreach(Thread th in _threads)
          th.Start();

        while(_finaledCount != _operationCount) { }
        timer.Stop();
        Console.WriteLine($"Кол-во выполненных потоков: {_finaledCount}");
      }
      Console.WriteLine($"Время выполнения {type}: {Math.Round((decimal)timer.ElapsedMilliseconds / 1000, 4)} c.");
      timer.Reset();
    }
  }
}
