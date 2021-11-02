using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBed
{
    class DataContainer
    {
        private bool PatientPresent;

        public bool GetPatientPresent()
        {
            return PatientPresent;
        }

        public void SetPatientPresent(bool value)
        {
            PatientPresent = value;
        }
    }
}
