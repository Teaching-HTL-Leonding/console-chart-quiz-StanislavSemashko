using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleChartExercise
{
    class Entry
    {
        private string country;
        private string timeOfDay;
        private string animal;
        private int attacks;

        public string Country 
        {
            get { return country; }
            set { country = value; }
        }
        public string Time
        {
            get { return timeOfDay; }
            set { timeOfDay = value; }
        }
        public string Animal
        {
            get { return animal; }
            set { animal = value; }
        }
        public int Attacks
        {
            get { return attacks; }
            set { attacks = value; }
        }
    }
  
}
