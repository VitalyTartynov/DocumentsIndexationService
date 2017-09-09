using System.Diagnostics;
using System.ServiceProcess;
using System.Timers;

namespace DocumentsIndexationService
{
    partial class IndexationService : ServiceBase
    {
        private const int Interval = 10000;

        private const string Name = "IndexationService";
        private const string SourceName = Name + "Source";
        private const string LogName = Name + "Log";

        private EventLog _eventLog;
        private Timer _timer;

        public IndexationService()
        {
            InitializeComponent();

            PrepareEventLog();
            InitializeTimer();

            _eventLog.WriteEntry($"{Name} initialized.", EventLogEntryType.Information);
        }

        private void InitializeTimer()
        {
            _timer = new Timer(Interval);
            _timer.Elapsed += DoIndexation;
        }

        private void DoIndexation(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            // write your code here
            _eventLog.WriteEntry("We can do indexation!", EventLogEntryType.Warning);
        }

        private void PrepareEventLog()
        {
            _eventLog = new EventLog();
            if (!EventLog.SourceExists(SourceName))
            {
                EventLog.CreateEventSource(SourceName, LogName);
            }
            _eventLog.Source = SourceName;
            _eventLog.Log = LogName;
        }

        protected override void OnStart(string[] args)
        {
            _timer.Start();
            _eventLog.WriteEntry($"{Name} started.", EventLogEntryType.Information);
        }

        protected override void OnStop()
        {
            _eventLog.WriteEntry($"{Name} stopped.", EventLogEntryType.Information);
        }
    }
}
