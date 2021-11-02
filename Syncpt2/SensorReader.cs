using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HospitalBed
{
    class SensorReader
    {
        private readonly BlockingCollection<DataContainer> _dataQueue;
        private readonly RandomBooleanGenerator _booleanGenerator = new RandomBooleanGenerator();

        public SensorReader(BlockingCollection<DataContainer> dataQueue)
        {
            _dataQueue = dataQueue;
        }

        public void Run()
        {
            int cnt = 50;
            while (cnt > 0)
            {
                bool present = _booleanGenerator.booleanRandom();
                DataContainer reading = new DataContainer();
                reading.SetPatientPresent(present);
                _dataQueue.Add(reading);
                Thread.Sleep(10);
                cnt--;
            }
            _dataQueue.CompleteAdding();
        }
        
}
}
