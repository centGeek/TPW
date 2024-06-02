using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal class DataLogger
    {
        private static readonly Lazy<DataLogger> _instance = new Lazy<DataLogger>(() => new DataLogger("logFile.json"));
        private ConcurrentQueue<BallLogEntry> _logQueue;
        private string _logFilePath;
        private Thread _logThread;
        private bool _isRunning;
        private DataLogger(string logFileName)
        {

        }

        public static DataLogger Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        public void Log(PositionOfBall position, SpeedOfBall speed, int radius)
        {
            var logEntry = new BallLogEntry(position, speed, radius);
            _logQueue.Enqueue(logEntry);
        }
    }


    internal class BallLogEntry
    {
        internal PositionOfBall Position { get; set; }
        internal SpeedOfBall Speed { get; set; }
        internal int Radius { get; set; }
        internal BallLogEntry(PositionOfBall position, SpeedOfBall speed, int radius)
        {
            Position = position;
            Speed = speed;
            Radius = radius;
        }
    }
}
