﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace BarSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Bar bar = new Bar();
            List<Thread> studentThreads = new List<Thread>();
            Random age = new Random();
            Random budget = new Random();
            for (int i = 1; i < 10; i++)
            {
                var student = new Student(i.ToString(), bar, budget.Next(200), age.Next(70));
                var thread = new Thread(student.PaintTheTownRed);
                thread.Start();
                studentThreads.Add(thread);
            }

            foreach (var t in studentThreads) t.Join();

            Console.WriteLine();
            Console.WriteLine("The party is over.");
            Console.ReadLine();
        }
    }
}
