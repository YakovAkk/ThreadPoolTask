using ParallelProgrammingAlgorithmTask.FillerOfData;

namespace ParallelProgrammingAlgorithmTask
{
    public partial class Form1 : Form
    {
        private readonly Dictionary<string, string> algorithmDictionary;
        private readonly TextBox textBox;
        private List<CheckBox> checkBoxes;
        private CheckedListBox checkListBox;
        public string InitializeText()
        {
            var str = "";
            foreach (var item in algorithmDictionary)
            {
                str += item.Value;
            }
            return str;
        }
        public Form1()
        {
            InitializeComponent();
            algorithmDictionary =
                new Filler().FillerDictionaryWihAlgotithmLabaThreadPool();
            textBox = new TextBox();

            test();
            //Initialize();
        }

        private void test()
        {
            checkListBox = new CheckedListBox();
            var coordinatesXcheckBox = 200;
            var coordinatesYcheckBox = 100;
            checkListBox.Width = 200;
            checkListBox.Location = new Point(coordinatesXcheckBox, coordinatesYcheckBox + 200);

            checkListBox.Items.Add("AAA");
            checkListBox.Items.Add("AAA");
            Controls.Add(checkListBox);
            checkListBox.Visible = false;

            var checkBox = new CheckBox();
            checkBox.Name = "AA";
            checkBox.ForeColor = Color.White;
            checkBox.Width = 900;
            checkBox.Text = "123333333333";
            checkBox.Location = new Point(coordinatesXcheckBox, coordinatesYcheckBox);
            coordinatesYcheckBox += 100;
            checkBox.Click += CheckBox_Click1; ;
            
            Controls.Add(checkBox);
        }

        private void CheckBox_Click1(object? sender, EventArgs e)
        {
            checkListBox.Visible = !checkListBox.Visible;
        }

        private void Initialize()
        {
            checkBoxes = new List<CheckBox>();
            this.BackColor = Color.Gray;
            
            this.Height = 1080;
            this.Width = 1920;
            AddTitle();
            
            AddTextBox(textBox);
            AddCheckBoxes();
        }
        private void AddCheckBoxes()
        {
            var coordinatesXcheckBox = 200;
            var coordinatesYcheckBox = 100;

            foreach (var item in algorithmDictionary.Keys)
            {
                var checkBox = new CheckBox();
                checkBox.Name = item;
                checkBox.ForeColor = Color.Black;
                checkBox.Width = 900;
                checkBox.Text = item;
                checkBox.Location = new Point(coordinatesXcheckBox, coordinatesYcheckBox);
                coordinatesYcheckBox += 100;
                checkBox.Click += CheckBox_Click;
                checkBoxes.Add(checkBox);
                Controls.Add(checkBox);
            }
        }
        private void CheckBox_Click(object? sender, EventArgs e)
        {
            textBox.Text = $"public class Laba\r\n{{ \r\n{GetText()}}}";
        }
        public string GetText()
        {
            var str = "";
            foreach (var item in checkBoxes)
            {
                if (!item.Checked)
                {
                    var isCanGetValue = algorithmDictionary.TryGetValue(item.Name, out var value);

                    if (isCanGetValue)
                    {
                        str += value.ToString();
                    }
                }
            }
            return str;
        }
        private void AddTextBox(TextBox textBox)
        {
            var coordinatesXtextBlock = 1000;
            var coordinatesYtextBlock = 100;

            textBox.ReadOnly = true;
            textBox.Text += $"public class Laba\r\n{{ \r\n{InitializeText()}}}";
            textBox.Multiline = true;
            textBox.Height = 900;
            textBox.Width = 600;
            textBox.Location = new Point(coordinatesXtextBlock, coordinatesYtextBlock);
            textBox.ScrollBars = ScrollBars.Vertical;
            Controls.Add(textBox);
        }
        private void AddTitle()
        {
            var title = new Label();
            title.ForeColor = Color.Black;
            title.Font = new Font("Arial Black", 19.8F, FontStyle.Bold, GraphicsUnit.Point);
            title.Text = "ThreadPool";
            title.Height = 50;
            title.Width = 250;
            title.Location = new Point(this.Height - Convert.ToInt32(this.Height * 0.3), 30);
            Controls.Add(title);
        }
    }
}