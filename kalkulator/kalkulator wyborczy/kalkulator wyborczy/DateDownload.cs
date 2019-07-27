using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace kalkulator_wyborczy
{
    class DateDownload
    {
        WebClient wc;
        string linkBlockedPersons;
        string linkCandidates;
       
        public DateDownload()
        {
            wc = new WebClient();
            wc.Headers.Add("Accept", "application/xml");
            linkBlockedPersons = "http://webtask.future-processing.com:8069/blocked";
            linkCandidates = "http://webtask.future-processing.com:8069/candidates";
        }
        public void  DownloadBlockedPersons()
        {
            try
            {
                byte[] data = wc.DownloadData(linkBlockedPersons);             
                MemoryStream ms = new MemoryStream(data);
                XmlDocument xmldoc = new XmlDocument();
                string s = "";
                XmlTextReader reader = new XmlTextReader(ms);
                while (reader.Read())
                {
                    User user;

                    if (reader.Name == "pesel")
                    {
                        reader.Read();
                        // s += reader.Value + " ";
                        user = new User(reader.Value);
                        s = user.SendQueryOneRow("SELECT pesel FROM user WHERE pesel = \""+user.GetPeselString()+"\"");
                        if (!s.Equals(user.GetPeselString()))
                        {
                            user.SendQueryOneRow("INSERT INTO user (pesel, voted) VALUES (\"" + user.GetPeselString() + "\",\"1\")");
                        }
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                string error = string.Format("Error link:\n{0}", ex.Message);
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void DownloadCandidates()
        {
            try
            {
                byte[] data1 = wc.DownloadData(linkCandidates);
                MemoryStream ms = new MemoryStream(data1);
                XmlDocument xmldoc = new XmlDocument();                
                string s = "";
                string name = "";
                XmlTextReader reader = new XmlTextReader(ms);              
                while (reader.Read())
                {
                    if (reader.Name == "name")
                    {
                        reader.Read();
                        name += reader.Value;
                        reader.Read();
                    }
                    if (reader.Name == "party")
                    {
                        reader.Read();
                        //s += reader.Value + " ";
                        Candidate candidate = new Candidate(name, "", reader.Value);
                        s = candidate.SendQueryOneRow("SELECT name FROM candidates WHERE name = \"" + candidate.GetFirstName() + "\"");
                        if (!s.Equals(candidate.GetFirstName()))
                        {
                            candidate.SendQueryOneRow("INSERT INTO candidates (name, party) VALUES (\"" + candidate.GetFirstName() + "\",\"" + candidate.GetPoliticalParty() + "\")");
                        }
                        name = "";
                        reader.Read();
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                string error = string.Format("Error link:\n{0}", ex.Message);
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            /*
             * <candidate>
                <name>Mieszko I</name>
                <party>Piastowie</party>
               </candidate>
            */
        }


    }
}
