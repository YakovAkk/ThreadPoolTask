namespace ConsoleApp3.TestThreadPool
{
    public class LabaThreadPool
    {
        private readonly string _url;
        public LabaThreadPool()
        {
            _url = "File.txt";
            ThreadPool.SetMinThreads(2, 2);
            ThreadPool.SetMaxThreads(10, 10);
        }

        private void WriteToFile(string text)
        {
            using (var reader = new StreamWriter(_url))
            {
                ThreadPool.QueueUserWorkItem((s) => reader.Write(text));
            }
        }

        private string ReadFromFile()
        {
            var text = "";
            using (var reader = new StreamReader(_url))
            {
                ThreadPool.QueueUserWorkItem((s) => text = read(text, reader));
            }

            return text;
        }

        private string read(string text, StreamReader reader)
        {
            string line = "";
            while ((line = reader.ReadLine()) != null)
            {
                ThreadPool.QueueUserWorkItem((s) => text += line);
            }

            return text;
        }

        public void Start()
        {
            string text = "";
            ThreadPool.QueueUserWorkItem((s) => WriteToFile("Our text"));
            ThreadPool.QueueUserWorkItem((s) => text = ReadFromFile());
            
        }
    }
}
