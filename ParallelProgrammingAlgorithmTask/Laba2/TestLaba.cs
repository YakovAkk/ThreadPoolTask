//1
using System.Threading;

namespace ParallelProgrammingAlgorithmTask.Laba2
{
    //2
    public class Program
    {
        //3
        public static int number = 10;
        public int[,] mas = new int[number, number];
        public Random rnd = new Random();

        //4
        public void Start()
        {
            int workerThreads, portThreads;
            //5
            FillMatrix();
            Console.WriteLine("\nProcessor=" + Environment.ProcessorCount);
            ThreadPool.GetMaxThreads(out workerThreads, out portThreads);
            Console.WriteLine($"\nMaximum worker threads: \t{workerThreads} \nMaximum completion port threads: {portThreads}");
            int MaxworkThreadsCount = 2 * Environment.ProcessorCount, MaxportThreadsCount = 2 * Environment.ProcessorCount;
            ThreadPool.SetMaxThreads(MaxworkThreadsCount, MaxportThreadsCount);
            ThreadPool.SetMinThreads(MaxworkThreadsCount, MaxportThreadsCount);
            ThreadPool.GetMaxThreads(out workerThreads, out portThreads);
            Console.WriteLine($"\nMaximum worker threads: \t{workerThreads} \nMaximum completion port threads: {portThreads}");
            // Створимо пул потоків
            Console.WriteLine("\nstart time=" + DateTime.Now.Millisecond);
            //6
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                ThreadPool.QueueUserWorkItem((s) => Function(i));
            }
            Console.WriteLine("\nend time=" + DateTime.Now.Millisecond);
            Console.ReadLine();
        }

        //5
        private void FillMatrix()
        {
            int i, j;

            for (i = 0; i < number; i++)
                for (j = 0; j < number; j++)
                    mas[i, j] = rnd.Next(-10, 10);
            for (i = 0; i < number; i++)
                for (j = 0; j < number; j++)
                    Console.WriteLine("i=" + i + " j=" + j + " mas=" + mas[i, j]);
        }

        //7
        public void Function(int instance)
        {
            int line = (int)instance, sum = 0, i;
            for (i = 0; i < number; i++)
                sum += mas[line, i];
            Thread.Sleep(500);
            Console.WriteLine("i=" + line + " sum=" + sum);
        }

    }
}
