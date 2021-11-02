using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospitalbed_withFilter
{
    public class Buzzer
    {
        private bool buzzerOn;

        public Buzzer()
        {
            buzzerOn = false;
        }

        public void buzzerActivated()
        {
            buzzerOn = true;
            Console.WriteLine("BZZZZZ!");
        }
    }
}
