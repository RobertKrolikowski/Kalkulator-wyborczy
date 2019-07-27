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
using System.Net;
using System.IO;
using System.Xml;
using System.Xml.XPath;

namespace kalkulator_wyborczy
{
    public partial class MainWindow : Form
    {
        private User user;
        
        public MainWindow()
        {          
            DateDownload data = new DateDownload();
            data.DownloadBlockedPersons();
            DateDownload data1 = new DateDownload();
            data1.DownloadCandidates();


            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            //label4.Text = user.GetFirstName() + user.GetSecondName();  
            //label4.Text = IDBox.TextLength.ToString();
            if (IDBox.TextLength == 11 && firstNameBox.TextLength != 0 && LastNameBox.TextLength != 0)
            {
                user = new User(firstNameBox.Text, LastNameBox.Text, IDBox.Text);
                //user.IsOlder18Age();
                if (user.IsPeselCorrect())              
                {
                    if(user.CanVote())
                    {
                        string s = "";
                        s = user.SendQueryOneRow("SELECT pesel FROM user WHERE pesel=\"" + user.GetPeselString() + "\"");
                        if(!s.Equals(user.GetPeselString()))
                            user.SendQueryOneRow("INSERT INTO user (firstname, lastname, pesel, logged) VALUES (\""+user.GetFirstName()+ "\",\"" + user.GetLastName() + "\",\"" + user.GetPeselString() + "\",\"1\")");

                        VoteWindow voteWindow = new VoteWindow(this, user);
                        voteWindow.Owner = this;                       
                        voteWindow.Show(this);
                        this.Hide();
                    }                   
                }
                else
                {
                    MessageBox.Show("Wrong pesel.");
                }
            }
            else if(firstNameBox.TextLength == 0)
                MessageBox.Show("Empty first name.");
            else if (LastNameBox.TextLength == 0)
                MessageBox.Show("Empty last name.");
            else
                MessageBox.Show("Pesel is too short.");
        }

        private void IDBox_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void firstNameBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void LastNameBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }


    }
}
