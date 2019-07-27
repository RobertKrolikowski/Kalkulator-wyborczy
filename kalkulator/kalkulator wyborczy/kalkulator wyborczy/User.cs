using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kalkulator_wyborczy
{
    public class User : Person
    {
        string peselString;

        public User(string firstName, string lastName, string pesel) : base(firstName, lastName)
        {
          
            peselString = pesel;
        }

        public User(string pesel)
        {
            peselString = pesel;
        }

        public bool IsOlder18Age()
        {
            DateTime localDate = DateTime.Now;
            string date = localDate.ToString();
            int year = int.Parse(date.Substring(0,4));
            int month = int.Parse(date.Substring(5, 2));
            int day = int.Parse(date.Substring(8, 2));

            int yearUser;
            int monthUser = 0;
            int dayUser = int.Parse(peselString.Substring(4, 2));
            string yearUserbuff = "";
            for (int i = 0, j = 19; i < 100; i += 20, j++)
            {
                if (int.Parse(peselString.Substring(2, 2)) >= i)
                {
                    if (j != 23)
                    {
                        yearUserbuff = j.ToString();
                        monthUser = int.Parse(peselString.Substring(2, 2)) - i;
                    }
                    else
                    {
                        yearUserbuff = "18";
                        monthUser = int.Parse(peselString.Substring(2, 2)) - i;
                    }
                }
            }
            yearUserbuff += peselString.Substring(0, 2);
            yearUser = int.Parse(yearUserbuff);

            if (yearUser + 18 < year)
            {
                return true;
            }
            else if (yearUser + 18 == year)
            {
                if (monthUser < month)
                {
                    return true;
                }
                else if (monthUser == month)
                {
                    if (dayUser <= day)
                    {
                        return true;
                    }
                }
            }
            MessageBox.Show("You are too young", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        public bool IsPeselCorrect()
        {
            int[] multipliers = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
            bool isIdCorrect = false;
            int sum = 0;
            for (int i = 0; i < multipliers.Length; i++)
            {
                sum += multipliers[i] * int.Parse(peselString[i].ToString());
            }

            int rest = sum % 10;
            //rest == 0 ? rest.ToString() : (10 - rest).ToString();
            //rest = rest == 0 ? rest : (10 - rest);
            if (rest == 0)
                isIdCorrect = true;
            else
            {
                rest = 10 - rest;
                if (rest.ToString() == peselString[10].ToString())
                    isIdCorrect = true;                   
            }
            return isIdCorrect;
        }

        public bool CanVote()
        {
            if (IsOlder18Age())
            {
                
                string s = "";
                string query = "SELECT  logged,voted FROM user WHERE pesel = \"" + peselString + "\"";
                s = SendQueryOneRow(query);

                if (s == "")
                {                  
                    return true;
                }
                else if (s[0].Equals('1') || s[1].Equals('1'))
                {
                    MessageBox.Show("You cant loggin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    query = "UPDATE user SET logged = \"1\" WHERE pesel = \"" + peselString + "\" ";
                    SendQueryOneRow(query);
                    return true;
                }
            }
            return false;
        }

        public string GetPeselString()
        {
            return peselString;
        }
    }
}
