using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBed
{
    class Filter
    {
        private readonly BlockingCollection<DataContainer> _dataQueue;
        public int TrueCounter { get; set; }
        public int FalseCounter { get; set; }


        public Filter(BlockingCollection<DataContainer> dataContainer)
        {
            _dataQueue = dataContainer;
            TrueCounter = 0;
            FalseCounter = 0;
        }

        public bool Filter_container(DataContainer dataContainer)
        {
            bool result = true;
            if (dataContainer.GetPatientPresent() == false)
            {
                TrueCounter = 0;
                FalseCounter = +1;
                if (FalseCounter == 3)
                {
                    FalseCounter = 0;
                    result = false;
                }
            }

            else if (dataContainer.GetPatientPresent() == true)
            {
                TrueCounter += 1;
                FalseCounter = 0;
                if (TrueCounter == 3)
                {
                    TrueCounter = 0;
                    result = true;
                }
            }

            return result;

        }

    }
}
