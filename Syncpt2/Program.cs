using System;
using System.Collections.Concurrent;
using System.Threading;

namespace HospitalBed
{
    class Program
    {
        static void Main(string[] args)
        {
            BlockingCollection<DataContainer> dataQueue = new BlockingCollection<DataContainer>();


            HospitalBedMonitor hospitalBedMonitor = new HospitalBedMonitor(dataQueue);
            SensorReader sensorReader = new SensorReader(dataQueue);

            Thread hospitalBedMonitorThread = new Thread(hospitalBedMonitor.Run);
            Thread sensorReaderThread = new Thread(sensorReader.Run);

            hospitalBedMonitorThread.Start();
            sensorReaderThread.Start();

        }

    }
}

        

    

