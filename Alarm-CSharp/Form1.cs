using System.Reflection;
using System.IO;
using System.Resources;
using System.Media;
using System.Diagnostics;
using Timer = System.Windows.Forms.Timer;

namespace Alarm_CSharp
{
   
    public partial class Form1 : Form
    {
        private CheckBox[] _days;
        private int[] _daysSelected;
        private Timer timer;
        private int counter = 0;
        private Assembly assembly;
        private SoundPlayer sp;

        public Form1(){
            InitializeComponent();
            checkBox1.CheckedChanged += (sender, e) => changeSelectedCheckbox(sender, e ,0);
            checkBox2.CheckedChanged += (sender, e) => changeSelectedCheckbox(sender, e ,1);
            checkBox3.CheckedChanged += (sender, e) => changeSelectedCheckbox(sender, e ,2);
            checkBox4.CheckedChanged += (sender, e) => changeSelectedCheckbox(sender, e, 3);
            checkBox5.CheckedChanged += (sender, e) => changeSelectedCheckbox(sender, e, 4);
            checkBox6.CheckedChanged += (sender, e) => changeSelectedCheckbox(sender, e, 5);
            checkBox7.CheckedChanged += (sender, e) => changeSelectedCheckbox(sender, e, 6);
            
            _days = new CheckBox[] { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7 };
            _daysSelected = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
            timer = new Timer
            {
                Interval = 1000
            };
            timer.Enabled = false;
            timer.Tick += new System.EventHandler(OnTimerEvent);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            assembly = Assembly.GetExecutingAssembly();
            sp = new SoundPlayer(assembly.GetManifestResourceStream
                ("Alarm_CSharp.Sound.Alarm.wav"));
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
        }
        private void clearBtn_Click(object sender, EventArgs e){
            for (int i = 0; i < _days.Length; i++){
                _days[i].Checked = false; 
            }

            if (timer.Enabled)
            {
                timer.Stop(); 
            }


        }
        private void OnTimerEvent(object o, EventArgs e)
        {
            counter--;
            if (counter == 0){
                //timer.Stop();
                //sp.Play();
            }
        }
        private void submitBtn_Click(object sender, EventArgs e)
        {
            int temp = 0; 
            for (int i = 0; i < _daysSelected.Length; i++){
                if (_daysSelected[i] == 0){
                    temp++;
                }
                if (temp == 7){
                    MessageBox.Show("Ingresa alguna fecha"); 
                    
                    return; 
                }
            }
            int d = (int)System.DateTime.Now.DayOfWeek;
            if (_daysSelected[d] == 1){
                int picker = timePicker1.Value.Hour * 24 + timePicker1.Value.Minute * 60 + timePicker1.Value.Second;
                int pickernow = DateTime.Now.Hour * 24 + DateTime.Now.Minute * 60 + DateTime.Now.Second;
                counter = picker - pickernow;
                programmedLbl.Text = "La hora fue programado para sonar a las "+timePicker1.Value.ToString("hhmmss");
            }
            else{
                programmedLbl.Text = "No es hoy";
            }
            timer.Enabled = true; 
            for(int i = 0; i < _days.Length; i++)
                _days[i].Enabled = false;
        }
    }
}