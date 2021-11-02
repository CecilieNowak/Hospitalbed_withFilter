using System;
using System.Collections.Concurrent;
using System.Threading;

namespace HospitalBed
{
    class Program
    {
        static void Main(string[] args)
        {
            AutoResetEvent dataConsumedEvent = new AutoResetEvent(true);
            AutoResetEvent dataReadyEvent = new AutoResetEvent(false);

            DataContainer dataContainer = new DataContainer();
            
            //Consumer
            HospitalBedMonitor hospitalBedMonitor = new HospitalBedMonitor(dataContainer, dataConsumedEvent, dataReadyEvent);

            //Producer
            SensorReader sensorReader = new SensorReader(dataContainer, dataReadyEvent, dataConsumedEvent);

            Thread hospitalBedMonitorThread = new Thread(hospitalBedMonitor.Run);
            Thread sensorReaderThread = new Thread(sensorReader.Run);

            hospitalBedMonitorThread.Start();
            sensorReaderThread.Start();

        }

    }
}

        

    

