namespace ParallelProgrammingAlgorithmTask.FillerOfData
{
    public class Filler
    {
        public Dictionary<string, string> FillerDictionaryWihAlgotithmLaba2Script() 
        { 
            var dict = new Dictionary<string, string>();

            dict.Add("1) We've created _lenghtOfArray to contain the lenght of array", "private int _lenghtOfArray = 500;\r\n");
            dict.Add("2) We've created _random to fill the array randomly", "private static Random _random = new Random();\r\n");
            dict.Add("3) We've created _array to contain the array", "private int[,] _array;\r\n");
            dict.Add("4) We've created the constructor to fill array", "public Laba2Script()\r\n" + "{\r\n _array = new int[_lenghtOfArray," +
                " _lenghtOfArray];\r\n RandomArray();\r\n}\r\n");
            dict.Add("5) We've created function RandomArray to fill array randomly", "private void RandomArray()\r\n"
                + "{\r\nfor (int i = 0; i < _lenghtOfArray; i++)\r\n" +
                " {\r\n for (int j = 0; j < _lenghtOfArray; j++)\r\n{\r\n_array[i, j] = _random.Next(_lenghtOfArray);\r\n }\r\n }\r\n }\r\n");
            dict.Add("6) We've created function Initialization to read users input without mistakes", "private int Initialization(string Message = \"\")\r\n"
                + "{\r\n int valueUser;\r\n while (true)\r\n{\r\n  Console.Write(Message);\r\n " +
                "try\r\n {\r\n valueUser = int.Parse(Console.ReadLine());\r\n" +
                "if(valueUser < 0 || valueUser > _lenghtOfArray)\r\n {\r\n throw new Exception(\"You enter INCORRECT data, try again\");\r\n}\r\n break;\r\n" +
                "}\r\n catch (Exception)\r\n {\r\n  Console.WriteLine(\"You enter INCORRECT data, try again\");" +
                " }\r\n  }\r\n return valueUser;\r\n}\r\n");
            dict.Add("7) We've created function Start to get a result of the programm", "public void Start() \r\n{\r\n var userNumber = Initialization($\"Which of arrays rows do you prefer?(0 - { _lenghtOfArray})\");\r\n" +
                "var sum = 0;\r\n for (int i = 0; i < _lenghtOfArray; i++)\r\n{\r\nThreadPool.QueueUserWorkItem((state) => sum += SumRow(_array, i));\r\n}\r\nConsole.WriteLine($\"result is { sum / _lenghtOfArray }\");\r\n}\r\n");
            dict.Add("8) We've created the function to get a sum of certain row", "private int SumRow(int[,] _array, int rowIndx)\r\n{\r\nvar sum = 0;\r\nfor (int i = 0; i < _lenghtOfArray; i++)\r\n{\r\nsum += _array[rowIndx, i];\r\n}\r\nreturn sum;\r\n}\r\n");

            return dict;
        }
        public Dictionary<string, string> FillerDictionaryWihAlgotithmLabaThreadPool()
        {
            var dict = new Dictionary<string, string>();

            dict.Add("Створюємо змінну для збурігання url адресу у программі", "private readonly string _url;\r\n\r\n");
            dict.Add("У конструкторі встановлюємо максимальну та мінімальну кількість потоків обробки данних", "public LabaThreadPool()\r\n{\r\n" +
                "_url = \"File.txt\";\r\n" +
                "ThreadPool.SetMinThreads(2, 2);\r\n" +
                "ThreadPool.SetMaxThreads(10, 10);\r\n}\r\n\r\n");
            dict.Add("Пишемо до файлу вокремому потоці та використовуємо using для хендлення помилок", "private void WriteToFile(string text)\r\n{\r\n" +
                "using (var reader = new StreamWriter(_url))\r\n{\r\n" +
                "ThreadPool.QueueUserWorkItem((s) => reader.Write(text));\r\n" +
                "}\r\n" +
                "}\r\n\r\n");
            dict.Add("Читання з файлу виносимо в окремий потік та створюємо для цього функцію read", "private string ReadFromFile()\r\n{\r\nvar text = \"\";\r\n" +
                "using (var reader = new StreamReader(_url))\r\n" +
                "{\r\nThreadPool.QueueUserWorkItem((s) => text = read(text, reader));\r\n}\r\nreturn text;\r\n}\r\n\r\n");
            dict.Add("Читаємо з файлу по строках та кожну строку читаюмо у окремому потоці", "private string read(string text, StreamReader reader)\r\n{\r\nstring line = \"\";\r\n" +
                "while ((line = reader.ReadLine()) != null)\r\n" +
                "{\r\nThreadPool.QueueUserWorkItem((s) => text += line);\r\n return text;\r\n}\r\n" +
                "}\r\n\r\n");
            dict.Add("Функція запускає наш додаток та в окремомих потоках винонує дії запису та читання", "public void Start()\r\n{\r\nstring text = \"\";\r\n" +
                "ThreadPool.QueueUserWorkItem((s) => WriteToFile(\"Our text\"));\r\n" +
                "ThreadPool.QueueUserWorkItem((s) => text = ReadFromFile());\r\n}\r\n\r\n");
            return dict;
        }
    }
}
