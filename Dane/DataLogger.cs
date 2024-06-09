using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Data
{
    internal class DataLogger
    {
        private static readonly Lazy<DataLogger> _instance = new Lazy<DataLogger>(() => new DataLogger("logFile.json"));
        private ConcurrentQueue<BallLogEntry> _logQueue; //Bufor
        private string _logFilePath;
        private Thread _logThread;
        private bool _isRunning;
        private AutoResetEvent _logEvent;
        private const int MaxSize = 10000;
        private object _lock;

        private DataLogger(string logFileName)
        {
            _lock = new object();
            _logEvent = new AutoResetEvent(false);
            _logFilePath = logFileName;
            _logQueue = new ConcurrentQueue<BallLogEntry>();
            Debug.WriteLine($"Powstał obiekt loggera i będzie pisał do {_logFilePath}");
            _isRunning = true;
            _logThread = new Thread(ProcessQueue);
            _logThread.Start();
        }

        private void ProcessQueue()
        {
            while (_isRunning)
            {
                _logEvent.WaitOne();
                while (_logQueue.TryDequeue(out var logEntry))
                {
                    string jsonString = JsonSerializer.Serialize(logEntry);
                    //Debug.WriteLine($"Logger: zapisałem do pliku {_logFilePath} treść : {jsonString}");
                    File.AppendAllText(_logFilePath, jsonString + Environment.NewLine, Encoding.UTF8);
                }
            }
        }

        public static DataLogger Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        public void Log(PositionOfBall position, SpeedOfBall speed, int radius, System.DateTime time, Guid Id)
        {
            lock (_lock)
            {
                if (_logQueue.Count < MaxSize)
                {
                    BallLogEntry logEntry = new BallLogEntry(position, speed, radius, time, Id);
                    _logQueue.Enqueue(logEntry);
                    _logEvent.Set();
                }
                else
                {
                    //Jeżeli bufor jest pusty to odrzucamy zdarzenie
                    Debug.WriteLine("Kolejka jest pełna");
                }
            }
        }
        public void Stop()
        {
            _isRunning = false;
            _logEvent.Set();
            _logThread.Join();
        }


        internal class BallLogEntry
        {
            public PositionOfBall Position { get; }
            public SpeedOfBall Speed { get; }
            public int Radius { get; }
            public System.DateTime Time { get; }
            public Guid Id { get; }
            internal BallLogEntry(PositionOfBall position, SpeedOfBall speed, int radius, System.DateTime time, Guid id)
            {
                Position = position;
                Speed = speed;
                Radius = radius;
                Time = time;
                Id = id;
            }
        }
    }
}
