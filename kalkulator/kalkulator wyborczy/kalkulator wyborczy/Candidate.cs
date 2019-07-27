using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kalkulator_wyborczy
{
    class Candidate : Person
    {
        string politicalParty;

        int voteNumber;

        public Candidate(string firstName, string lastName, string politicalParty) : base(firstName, lastName)
        {
            this.politicalParty = politicalParty;
        }

        public Candidate()
        {

        }

        public string GetPoliticalParty()
        {
            return politicalParty;
        }

        public void SetPoliticalParty(string politicalParty)
        {
            this.politicalParty = politicalParty;
        }

        public void SetItemsByString(string nameAndParty)
        {
            string[] buff = nameAndParty.Split('|');
            SetFirstName(buff[0]); 
            politicalParty = buff[1];
        }
    }
}
