using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Hospitalbed_withFilter;

namespace HospitalBed
{
    class HospitalBedMonitor
    {
        private readonly DataContainer _dataContainer;
        private readonly AutoResetEvent _sensorDataReadyEvent;
        private readonly AutoResetEvent _sensorDataConsumedEvent;

        private readonly Filter _filter;
        private readonly Buzzer _buzzer;

        public HospitalBedMonitor(DataContainer dataContainer, AutoResetEvent sensorDataReadyEvent, AutoResetEvent sensorDataConsumedEvent)
        {
            _sensorDataConsumedEvent = sensorDataConsumedEvent;
            _sensorDataReadyEvent = sensorDataReadyEvent;
            _dataContainer = dataContainer;
        }

        public void Run()
        {
            while (true)
            {
                _sensorDataReadyEvent.WaitOne();
                bool rand = _dataContainer.GetPatientPresent();
                
                _sensorDataConsumedEvent.Set();
                
                if (_filter.Filter_container())

            }
        }
    }
}
