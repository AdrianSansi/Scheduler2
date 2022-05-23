using Scheduler2;
namespace WinScheduler2
{
    public partial class Form1 : Form
    {
        int cYear;
        int cMonth;
        int cDay;
        int cHour;
        int cMinute;
        int cSecond;
        int period;
        Schedule schedule;
        int numPeriod;
        DateTime endDate;


        public Form1()
        {
            schedule = new Schedule(); schedule.timeDate = DateTime.MinValue;
            cYear = 0; cMonth = 0; cDay = 0; period = 1; numPeriod = 0;
            cHour = 0; cMinute = 0; cSecond = 0;
            endDate = DateTime.MinValue;
            InitializeComponent();
        }

        private void InputBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                schedule.currentDate = DateTime.Parse(InputBox.Text);
                OnceRadioButton.Enabled = true;
                RecurringRadioButton.Enabled = true;
                
            }
            catch (Exception FormatException)
            {
                OnceRadioButton.Checked = false;
                RecurringRadioButton.Checked = false;
                OnceRadioButton.Enabled = false;
                RecurringRadioButton.Enabled = false;
            }

        }

        private void RecurringRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (RecurringRadioButton.Checked == true)
            {
                OnceRadioButton.Checked = false;
                DailyRadioButton.Enabled = true;
                WeeklyRadioButton.Enabled = true;
            }
            else
            {
                DailyRadioButton.Enabled = false;
                WeeklyRadioButton.Enabled = false;
            }
        }

        private void OnceRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (OnceRadioButton.Checked == true)
            {
                RecurringRadioButton.Checked = false;
                OnceTextBox.Enabled = true;
            }
            else
            {
                OnceTextBox.Enabled = false;
            }
        }

        private void DailyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (DailyRadioButton.Checked == true)
            {
                WeeklyRadioButton.Checked = false;

            }
            else
            {

            }
        }

        private void WeeklyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (WeeklyRadioButton.Checked == true)
            {
                DailyRadioButton.Checked = false;

            }
            else
            {

            }
        }

        private void OnceTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                schedule.timeDate = DateTime.Parse(OnceTextBox.Text);
                NextButton.Enabled = true;
            }
            catch (Exception FormatException)
            {
                NextButton.Enabled = false;
            }

        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            OutputBox.Text = schedule.timeDate.ToString();
        }
    }

}