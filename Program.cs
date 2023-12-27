using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

public class PriorityQueueDemo
{
    private static readonly int range = 10000000;

     public static void Main(string[] args)
    {
        var testOut = new StringBuilder();
        var simplePrio = new PriorityQueue<int,int>();
        Console.WriteLine("Priority Enqueued 1:1,2:1,3:1,4:5,5:9");
        simplePrio.Enqueue(1, -1);
        simplePrio.Enqueue(2, -1);
        simplePrio.Enqueue(3, -1);
        simplePrio.Enqueue(4, -5);
        simplePrio.Enqueue(5, -9);
        while (simplePrio.Count > 0)
        {
            testOut.Append(" ").Append(simplePrio.Dequeue());
        }
        Console.WriteLine("Simple Priority Queue Dequeued: " + testOut);
        var pairs = new List<(int,int)>();
        var random = new Random();
        for (var i = 0; i < range; i++)
        {
            pairs.Add((0-random.Next(1, 10), random.Next(range)));
        }
        var stopwatch = Stopwatch.StartNew();
        foreach (var pair in pairs)
        {
            simplePrio.Enqueue(pair.Item1,pair.Item2);
        }
        stopwatch.Stop();
        Console.WriteLine("Simple Priority queue enqueue time: " + stopwatch.Elapsed);
        var count = 0;
        stopwatch.Restart();
        while (simplePrio.Count > 0)
        {
            simplePrio.Dequeue();
            count++;
        }
        stopwatch.Stop();
        Console.WriteLine("Simple priority queue dequeued items: " + count);
        Console.WriteLine("Simple priority queue dequeue time: " + stopwatch.Elapsed);
        Console.WriteLine("-----");
    }
}