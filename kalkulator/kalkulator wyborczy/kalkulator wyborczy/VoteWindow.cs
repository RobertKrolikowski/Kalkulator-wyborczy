using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace kalkulator_wyborczy
{
    public partial class VoteWindow : Form
    {
        User user;
        MainWindow loginForm;
        int candidatNumbers;
        int partyCounter;
        public VoteWindow(MainWindow loginForm, User a)
        {
            this.loginForm = loginForm;
            user = a;
            Candidate candidate = new Candidate();

            //UPDATE candidates SET numbersofvotes = numbersofvotes + 1  WHERE name = "votes invalid" zwiększeinie
            candidatNumbers = int.Parse( candidate.SendQueryOneRow("SELECT COUNT(*) FROM candidates WHERE name!=\"votes invalid\""));
            var resoult = candidate.SendQueryAllRows("SELECT name, party FROM candidates WHERE name!=\"votes invalid\"");
            
            for (int i = 0, j = 0; i < candidatNumbers; i++)
            {
                if (i % 15 == 14)
                    j++;
                CheckBox ch = new CheckBox();
                ch.Location = new System.Drawing.Point(12+200 * j, 10 + 26 * (i - j *10));
                ch.Size = new System.Drawing.Size(100, 20);
                ch.Name = "ch" + i.ToString();
                ch.Text = resoult[i];
                ch.AutoSize = true;
                Controls.Add(ch);               
            }
            partyCounter = int.Parse(candidate.SendQueryOneRow("SELECT COUNT(DISTINCT(party)) FROM candidates"));
            InitializeComponent();
                   
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VoteWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            user.SendQueryOneRow("UPDATE user SET logged = \"0\" WHERE pesel = \"" + user.GetPeselString() + "\" ");
            this.Owner.Show();
        }

        private void VoteButton_Click(object sender, EventArgs e)
        {
            string message = "Confirm your vote.";
            if (MessageBox.Show(message, "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
            {
                try
                {
                    Candidate candidate = new Candidate();
                    //TextBox ptextbox = (TextBox)this.Controls.Find("d_box_" + nr_kontrolki, false).First();
                    int numbersChecked = 0;
                    int checkBoxNumber = -1;
                    for (int i = 0; i < candidatNumbers; i++)
                    {
                        CheckBox checkbox = (CheckBox)this.Controls.Find("ch" + i.ToString(), false).First();
                        checkbox.Visible = false;
                        if (checkbox.Checked && numbersChecked == 0)
                        {
                            numbersChecked++;
                            checkBoxNumber = i;
                        }
                        else if (checkbox.Checked && numbersChecked == 1)
                        {
                            numbersChecked = -1;
                            break;
                        }

                    }

                    if (numbersChecked == -1)
                    {
                        candidate.SendQueryOneRow("UPDATE candidates SET numbersofvotes = numbersofvotes + 1  WHERE name = \"votes invalid\"");
                        user.SendQueryOneRow("UPDATE user SET voted = \"1\" WHERE pesel=\"" + user.GetPeselString() + "\"");
                        VoteButton.Visible = false;
                    }
                    else if (numbersChecked == 1)
                    {
                        user.SendQueryOneRow("UPDATE user SET voted = \"1\" WHERE pesel=\"" + user.GetPeselString() + "\"");
                        CheckBox checkbox = (CheckBox)this.Controls.Find("ch" + checkBoxNumber.ToString(), false).First();
                        candidate.SetItemsByString(checkbox.Text);
                        candidate.SendQueryOneRow("UPDATE candidates SET numbersofvotes = numbersofvotes + 1 WHERE name = \"" + candidate.GetFirstName() + "\" AND party = \"" + candidate.GetPoliticalParty() + "\"");
                        VoteButton.Visible = false;
                    }
                    else if (numbersChecked == 0)
                    {
                        VoteButton.Visible = false;
                    }
                    CreateVoteScores();
                    chartButton.Visible = true;
                }
                catch (Exception ex)
                {
                    string error = string.Format("{0}", ex.Message);
                    MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void CreateVoteScores()
        {
            try
            {
                Candidate candidate = new Candidate();
                var resoult = candidate.SendQueryAllRows("SELECT name, numbersofvotes FROM candidates");

                for (int i = 0; i <= candidatNumbers; i++)
                {

                    Label label = new Label();
                    label.Location = new System.Drawing.Point(12, 10 + 26 * i);
                    label.Size = new System.Drawing.Size(100, 20);
                    label.Name = "labelCandidate" + i.ToString();
                    label.Text = resoult[i];
                    label.AutoSize = true;
                    Controls.Add(label);
                }
               

                string[] partyVotes = candidate.SendQueryAllRows("SELECT party, SUM(numbersofvotes) FROM `candidates` GROUP BY party");              
                for (int i = 0; i < partyCounter; i++)
                {

                    Label label = new Label();
                    label.Location = new System.Drawing.Point(200, 10 + 26 * i);
                    label.Size = new System.Drawing.Size(100, 20);
                    label.Name = "labelParty" + i.ToString();
                    label.Text = partyVotes[i];
                    label.AutoSize = true;
                    Controls.Add(label);
                }
            }
            catch (Exception ex)
            {
                string error = string.Format("{0}", ex.Message);
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chartButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (chart1.Visible)
                    chart1.Visible = false;
                else
                    chart1.Visible = true;
                ChangeVisableVoteScores();
                chart1.Series["Candidate"].Points.Clear();
                Candidate candidate = new Candidate();
                var resoult = candidate.SendQueryAllRows("SELECT name, numbersofvotes FROM candidates");
                for (int i = 0; i < candidatNumbers; i++)
                {
                    string[] buff = resoult[i].Split('|');
                    chart1.Series["Candidate"].Points.AddXY(buff[0], int.Parse(buff[1]));
                }
                /*
                string[] partyVotes = candidate.SendQueryAllRows("SELECT party, SUM(numbersofvotes) FROM `candidates` GROUP BY party");
                int partyNumber = int.Parse(candidate.SendQueryOneRow("SELECT COUNT(DISTINCT(party)) FROM candidates"));

                for (int i = 0; i < 1; i++)
                {
                    chart1.Series["Party"].Points.AddXY("party", 1);
                }*/
            }
            catch (Exception ex)
            {
                string error = string.Format("{0}", ex.Message);
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChangeVisableVoteScores()
        {
            for (int i = 0; i <= candidatNumbers; i++)
            {
                Label Label = (Label)this.Controls.Find("labelCandidate" + i.ToString(), false).First();
                if(Label.Visible)
                    Label.Visible = false;
                else
                    Label.Visible = true;
            }

            for (int i = 0; i < partyCounter; i++)
            {
                Label Label = (Label)this.Controls.Find("labelParty" + i.ToString(), false).First();
                if (Label.Visible)
                    Label.Visible = false;
                else
                    Label.Visible = true;
            }
        }
    }
}
