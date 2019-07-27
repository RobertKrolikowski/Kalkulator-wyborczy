using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kalkulator_wyborczy
{
    public class Person
    {
        string firstName;
        string lastName;

        public Person(string firstName, string lastName)
        {    
            if(!firstName.Equals(""))       
                this.firstName = firstName[0].ToString().ToUpper() + firstName.Substring(1);
            if(!lastName.Equals(""))
                this.lastName = lastName[0].ToString().ToUpper() + lastName.Substring(1);
        }

        public Person()
        {
            firstName = "";
            lastName = "";
        }

        public string GetFirstName()
        {
            return firstName;
        }

        public string GetLastName()
        {
            return lastName;
        }

        public void SetFirstName(string firstName)
        {
            this.firstName = firstName;
        }

        public void SetLastName(string lastName)
        {
            this.lastName = lastName;
        }

        public string SendQueryOneRow(string query)
        {
            MySqlConnection dbConection = new MySqlConnection("server=localhost;user=root;database=calculatordb;SslMode=none;charset=utf8");           
            string s = "";
            try
            {
                dbConection.Open();
                //query = "INSERT INTO user (firstname, lastname, pesel) VALUES ('acb', 'def','12345678901')";
                //query = "SELECT voted, logged FROM user WHERE pesel = \"" + peselString + "\"";
                MySqlCommand command;
                MySqlDataReader reader;
                command = new MySqlCommand(query, dbConection);
                reader = command.ExecuteReader();
                while (reader.HasRows)
                {
                    reader.Read();
                    for (int i = 0; i < reader.FieldCount; i++)
                        s += reader[i].ToString();
                    reader.Close();
                }

            }
            catch (Exception ex)
            {
                string error = string.Format("Error database connection:\n{0}", ex.Message);
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConection.Close();
            }
            return s;
        }

        public string[] SendQueryAllRows(string query)
        {
            MySqlConnection dbConection = new MySqlConnection("server=localhost;user=root;database=calculatordb;SslMode=none;charset=utf8");
            string[] resoult = new string [0];
            try
            {
                dbConection.Open();
                //query = "INSERT INTO user (firstname, lastname, pesel) VALUES ('acb', 'def','12345678901')";
                //query = "SELECT voted, logged FROM user WHERE pesel = \"" + peselString + "\"";
                MySqlCommand command;
                MySqlDataReader reader;
                command = new MySqlCommand(query, dbConection);
                reader = command.ExecuteReader();
                while (reader.HasRows)
                {
                    for(int i = 0; reader.Read(); i++)
                    {
                        Array.Resize<string>(ref resoult, resoult.Length + 1);
                        for (int k = 0; k < reader.FieldCount; k++)
                        {
                            resoult[i] += reader[k].ToString();
                            if (k != reader.FieldCount - 1)
                                resoult[i] += "|";
                        }
                    }

                    reader.Close();
                }
                

            }
            catch (Exception ex)
            {
                string error = string.Format("Error database connection:\n{0}", ex.Message);
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConection.Close();
            }
            return resoult;
        }
    }
}
