namespace Alarm_CSharp
{
    public partial class Form1 : Form
    {
        private CheckBox[] _days;
        private int[] _daysSelected; 

        public Form1()
        {
           
            InitializeComponent();
            _days = new CheckBox[] { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7 };
            _daysSelected = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
           
                

        }
        private void changeSelectedCheckbox(object o, EventArgs args, int e)
        {
            if (_daysSelected != null)
                if (((CheckBox)o).Checked == true){
                    if (_daysSelected[e] == 0){
                        _daysSelected[e] = 1;
                    }
                }else {
                    if (_daysSelected[e] == 1)
                        _daysSelected[e] = 0;
                }
            programmedLbl.Text = String.Join(" ", _daysSelected); 
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