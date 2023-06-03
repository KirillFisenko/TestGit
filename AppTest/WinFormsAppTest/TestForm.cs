namespace WinFormsAppTest
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void TestForm_Load(object sender, EventArgs e)
        {

        }

        private void button_Click(object sender, EventArgs e)
        {
            var inputLine = inputTextBox.Text;

            char[] array = { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '+', '-', '*', '/', '.', ',', ';', ':', ' ', };
            var transformLine = inputLine
                                .ToLower()
                                .Split(array, StringSplitOptions.RemoveEmptyEntries)
                                .OrderByDescending(x => x.Length)
                                .ThenBy(x => x);

            var outputResult = transformLine;
            foreach (var item in transformLine)
            {
                outputTextBox.Text += item + '\r' + '\n';
            }
        }
    }
}