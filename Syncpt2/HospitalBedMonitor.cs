using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HospitalBed
{
    class HospitalBedMonitor
    {
        private readonly BlockingCollection<DataContainer> _dataQueue;
        private readonly Filter _filter;

        public HospitalBedMonitor(BlockingCollection<DataContainer> dataQueue, Filter filter)
        {
            _dataQueue = dataQueue;
            _filter = filter;
        }

        public void Run()
        {
            while (!_dataQueue.IsCompleted)
            {
                try
                {
                    var container = _dataQueue.Take();
                    bool present = container.GetPatientPresent();
                    bool filter = _filter.Filter_container(container);


                    System.Console.WriteLine("The patient is out of bed: {0}", present);

                }
                catch (InvalidOperationException)
                {
                    ///IOE means that Take() was called on a completed collection
                }
                Console.WriteLine("No more data expected");
            }
        }
    }
}
