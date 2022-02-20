namespace Alarm_CSharp
{
    public partial class Form1 : Form
    {
        private CheckBox[] _days;

        public Form1()
        {
           
            InitializeComponent();
            _days = new CheckBox[] { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7 };
           

        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            
            for (int i = 0; i < _days.Length; i++)
            {
                _days[i].Checked = false; 
            }
        }
    }
}