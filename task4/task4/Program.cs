//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="Creativity Team">
// (c)reativity inc.
// </copyright>
//-----------------------------------------------------------------------
using System;

namespace task4
{
    /// <summary>
    /// Contains entry point for application
    /// </summary>
    class Program
    {
        /// <summary>
        /// Defines the entry point for application
        /// </summary>
        /// <param name="args">A list of command line arguments</param>
        static void Main(string[] args)
        {
            Task t = new Task();
            t.ExecuteTasks();
            Console.Read();
        }
    }
}
