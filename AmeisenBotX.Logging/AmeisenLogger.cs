﻿using AmeisenBotX.Logging.Enums;
using AmeisenBotX.Logging.Objects;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Timers;
using Timer = System.Timers.Timer;

namespace AmeisenBotX.Logging
{
    public class AmeisenLogger
    {
        private static readonly object padlock = new();
        private static AmeisenLogger instance;
        private int timerBusy;

        private AmeisenLogger(bool deleteOldLogs = false)
        {
            LogBuilder = new();
            StringBuilder = new();

            LogFileWriter = new(1000);
            LogFileWriter.Elapsed += LogFileWriterTick;

            Enabled = false;
            ActiveLogLevel = LogLevel.Debug;

            // default log path
            ChangeLogFolder(AppDomain.CurrentDomain.BaseDirectory + "log/", false);

            if (deleteOldLogs)
            {
                DeleteOldLogs();
            }
        }

        public static AmeisenLogger I
        {
            get
            {
                lock (padlock)
                {
                    instance ??= new(true);
                    return instance;
                }
            }
        }

        public LogLevel ActiveLogLevel { get; set; }

        public bool Enabled { get; private set; }

        public string LogFileFolder { get; private set; }

        public string LogFilePath { get; private set; }

        private ConcurrentQueue<LogEntry> LogBuilder { get; }

        private Timer LogFileWriter { get; set; }

        private StringBuilder StringBuilder { get; }

        public void ChangeLogFolder(string logFolderPath, bool createFolder = true, bool deleteOldLogs = true)
        {
            LogFileFolder = logFolderPath;

            if (createFolder && !Directory.Exists(logFolderPath))
            {
                Directory.CreateDirectory(logFolderPath);
            }

            LogFilePath = LogFileFolder + $"AmeisenBot.{DateTime.Now:dd.MM.yyyy}-{DateTime.Now:HH.mm}.txt";

            if (deleteOldLogs)
            {
                DeleteOldLogs();
            }
        }

        public void DeleteOldLogs(int daysToKeep = 1)
        {
            if (Directory.Exists(LogFileFolder))
            {
                string[] files = Directory.GetFiles(LogFileFolder);

                for (int i = 0; i < files.Length; ++i)
                {
                    string file = files[i];
                    FileInfo fileInfo = new(file);

                    if (fileInfo.LastAccessTime < DateTime.Now.AddDays(daysToKeep * -1))
                    {
                        fileInfo.Delete();
                    }
                }
            }
        }

        public void Log(string tag, string log, LogLevel logLevel = LogLevel.Debug, [CallerFilePath] string callingClass = "", [CallerMemberName] string callingFunction = "", [CallerLineNumber] int callingCodeline = 0)
        {
            if (Enabled && logLevel <= ActiveLogLevel)
            {
                LogBuilder.Enqueue(new(logLevel, $"{$"[{tag}]",-24} {log}", Path.GetFileNameWithoutExtension(callingClass), callingFunction, callingCodeline));
            }
        }

        public void Start()
        {
            if (!Enabled)
            {
                Enabled = true;
                LogFileWriter.Enabled = true;
            }
        }

        public void Stop()
        {
            if (Enabled)
            {
                Enabled = false;
                LogFileWriter.Enabled = false;
                LogFileWriterTick(null, null);
            }
        }

        private void LogFileWriterTick(object sender, ElapsedEventArgs e)
        {
            // only start one timer tick at a time
            if (Interlocked.CompareExchange(ref timerBusy, 1, 0) == 1)
            {
                return;
            }

            try
            {
                while (!LogBuilder.IsEmpty && LogBuilder.TryDequeue(out LogEntry logEntry))
                {
                    StringBuilder.AppendLine(logEntry.ToString());
                }

                File.AppendAllText(LogFilePath, StringBuilder.ToString());
                StringBuilder.Clear();
            }
            finally
            {
                timerBusy = 0;
            }
        }
    }
}