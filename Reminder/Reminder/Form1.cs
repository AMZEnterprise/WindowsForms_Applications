using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Reminder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            lBoxReminderItems.Items.Clear();

            if (String.IsNullOrEmpty(txtReminderTitle.Text))
            {
                errorProvider1.SetError(txtReminderTitle, "Enter the new to do item title");
            }
            else if (String.IsNullOrEmpty(txtReminderDescription.Text))
            {
                errorProvider1.SetError(txtReminderDescription, "Enter the new to do item description");
            }
            else
            {
                try
                {
                    
                    StreamWriter sw = new StreamWriter("ReminderData.txt", true);
                    sw.WriteLine(txtReminderTitle.Text + "|" + txtReminderDescription.Text +  "|" + "\t" + dateTimePicker1.Value.ToString());
                    sw.Close();

                    StreamReader sr = new StreamReader("ReminderData.txt");
                    string currentLine = sr.ReadLine();
                    while (currentLine != null)
                    {
                        string[] temp = currentLine.Split('|');
                        lBoxReminderItems.Items.Add($"{temp[0]}|{temp[1]}|{temp[2]}");
                        currentLine = sr.ReadLine();
                    }
                    sr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                txtReminderDescription.Clear();
                txtReminderTitle.Clear();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (lBoxReminderItems.Items.Count != 0 )
                {
                    File.Delete("ReminderData.txt");

                    lBoxReminderItems.Items.RemoveAt(lBoxReminderItems.SelectedIndex);

                    StreamWriter sw = new StreamWriter("ReminderData.txt", true);
                    foreach (var item in lBoxReminderItems.Items)
                    {
                        sw.WriteLine(item);
                    }
                    sw.Close();
                }
                else
                {
                    MessageBox.Show("There is no activity to delete.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists("ReminderData.txt"))
            {
                StreamWriter sw = new StreamWriter("ReminderData.txt",true);
                sw.Close();
            }
            StreamReader sr = new StreamReader("ReminderData.txt");
            string currentLine = sr.ReadLine();
            while (currentLine != null)
            {
                string[] temp = currentLine.Split('|');
                lBoxReminderItems.Items.Add($"{temp[0]}|{temp[1]}|{temp[2]}");
                currentLine = sr.ReadLine();
            }
            sr.Close();

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd,hh:mm:ss tt";
        }

        private void lBoxReminderItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                tooltipStatus.BackColor = Color.Transparent;

                string[] currentItem = lBoxReminderItems.SelectedItem.ToString().Split('|');
                string selectedItemTime = "";

                StreamReader sr = new StreamReader("ReminderData.txt");
                string currentLine = sr.ReadLine();
                while (currentLine != null)
                {
                    string[] temp = currentLine.Split('|');
                    if (temp[0] == currentItem[0] && temp[1] == currentItem[1])
                    {
                        selectedItemTime = temp[2].Trim();
                        break;
                    }
                    currentLine = sr.ReadLine();
                }
                sr.Close();

                DateTime today = DateTime.Now;
                DateTime thatday = DateTime.Parse(selectedItemTime);



                if (DateTime.Compare(thatday, today) > -1)
                {
                    tooltipStatus.Text = "Not done yet";
                    int days = today.Day - thatday.Day > 0 ? today.Day - thatday.Day : thatday.Day - today.Day;

                    //today = DateTime.Now;

                    //int hours = today.Hour - thatday.Hour > 0 ? today.Hour - thatday.Hour : thatday.Hour - today.Hour;
                    //int mins = today.Minute - thatday.Minute > 0 ? today.Minute - thatday.Minute : thatday.Minute - today.Minute;
                    //int secs = today.Second - thatday.Second > 0 ? today.Second - thatday.Second : thatday.Second - today.Second;

                    Console.WriteLine("help");

                    //tooltipRemainDays.Text = $"{hours}:{mins}:{secs}";
                    tooltipRemainDays.Text = $"{days} days";
                }
                else
                {
                    tooltipStatus.Text = "oops , you forgot this!";
                    tooltipStatus.BackColor = Color.IndianRed;
                    tooltipRemainDays.Text = "0 days";
                }
            }
            catch { }
        }
    }
}
