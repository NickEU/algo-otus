﻿using System;
using System.IO;

namespace tester
{
    class Program
    {
        static void Main()
        {
            StringLength strLenTask = new StringLength();
            // the path assumes running via debugging in visual studio
            string pathToStrLenTestDir = Path.GetFullPath(Path.Combine(
                Environment.CurrentDirectory, "..", "..", "..", "..", @"tests\0-string"));
            Tester strLenTester = new Tester(strLenTask, pathToStrLenTestDir);
            strLenTester.RunTest();
            Console.WriteLine("Fin!");
        }
    }
}
