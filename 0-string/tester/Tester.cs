using System;
using System.IO;

namespace tester
{
    class Tester
    {
        readonly ITask task;
        readonly string path;

        public Tester(ITask task, string path)
        {
            this.task = task;
            this.path = path;
        }

        public void RunTest()
        {
            int testNumber = 0;
            while (true)
            {
                string inputFile = $"{path}\\test.{testNumber}.in";
                string outputFile = $"{path}\\test.{testNumber}.out";
                if (!File.Exists(inputFile) || !File.Exists(outputFile))
                {
                    break;
                }           
                Console.WriteLine($"Test #{testNumber} = {RunTest(inputFile, outputFile)}");
                testNumber++;
            }
        }

        bool RunTest(string inputFile, string outputFile)
        {
            try
            {
                string[] data = File.ReadAllLines(inputFile);
                string actualResult = task.Run(data);
                string expectedResult = File.ReadAllText(outputFile);
                Console.WriteLine($"Input:\n{String.Join(Environment.NewLine, data)}\n" +
                    $"Expected Result:\n{expectedResult}\n" +
                    $"Actual Result:\n{actualResult}");
                return actualResult == expectedResult;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
