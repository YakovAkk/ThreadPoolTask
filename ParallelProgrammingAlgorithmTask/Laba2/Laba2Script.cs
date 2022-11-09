namespace ParallelProgrammingAlgorithmTask.Laba2;

public class Laba2Script // variant - 40
{
    private int _lenghtOfArray = 500;
    private static Random _random = new Random();
    private int[,] _array;
    public Laba2Script()
    {
        _array = new int[_lenghtOfArray, _lenghtOfArray];
        RandomArray();
    }
    private void RandomArray()
    {
        for (int i = 0; i < _lenghtOfArray; i++)
        {
            for (int j = 0; j < _lenghtOfArray; j++)
            {
                _array[i, j] = _random.Next(_lenghtOfArray);
            }
        }
    }
    private int Initialization(string Message = "")
    {
        int valueUser;
        while (true)
        {
            Console.Write(Message);
            try
            {
                valueUser = int.Parse(Console.ReadLine());
                if (valueUser < 0 || valueUser > _lenghtOfArray)
                {
                    throw new Exception("You enter INCORRECT data, try again");
                }
                break;
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You enter INCORRECT data, try again");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        return valueUser;
    }
    public void Start()
    {
        var userNumber = Initialization($"Which of arrays rows do you prefer?(0 - {_lenghtOfArray})");
        var sum = 0;
        ThreadPool.SetMinThreads(2, 2);
        ThreadPool.SetMaxThreads(10, 10);
        for (int i = 0; i < _lenghtOfArray; i++)
        {
            ThreadPool.QueueUserWorkItem((state) => sum += SumRow(_array, i));
        }

        Console.WriteLine($"result is {sum / _lenghtOfArray}");
    }
    private int SumRow(int[,] _array, int rowIndx)
    {
        var sum = 0;
        for (int i = 0; i < _lenghtOfArray; i++)
        {
            sum += _array[rowIndx, i];
        }

        return sum;
    }
}

