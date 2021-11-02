using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBed
{
    class RandomBooleanGenerator
    {
        private readonly Random _random = new Random();

        public bool booleanRandom()
        {
            int random = _random.Next(0, 2);
            if (random == 1)
                return true;
            else
            {
                return false;
            }

        }
    }
}
