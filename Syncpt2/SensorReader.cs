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
        private readonly DataContainer _dataContainer;
        private readonly AutoResetEvent _dataConsumedEvent;
        private readonly AutoResetEvent _dataReadyEvent;

        //private readonly BlockingCollection<DataContainer> _dataQueue;
        private readonly RandomBooleanGenerator _booleanGenerator = new RandomBooleanGenerator();

        public SensorReader(DataContainer dataContainer, AutoResetEvent dataConsumedEvent, AutoResetEvent dataReadyEvent)
        {
            _dataContainer = dataContainer;
            _dataConsumedEvent = dataConsumedEvent;
            _dataReadyEvent = dataReadyEvent;
        }

        public void Run()
        {
            
            while (true)
            {
                _dataConsumedEvent.WaitOne();
                bool rand = _booleanGenerator.booleanRandom();
                _dataContainer.SetPatientPresent(rand);
                _dataReadyEvent.Set();
                Thread.Sleep(1000);
                
   
            }
            
        }
        
}
}
