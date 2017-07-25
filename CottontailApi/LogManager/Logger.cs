using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CottontailApi.LogManager
{
    public enum LogOutput
    {
        File,
        Console
    }

    public class Logger
    {
        private log4net.ILog logFile;
        private log4net.ILog logConsole;
        private static string ConfigFile { get; set; }

        private static Logger _instance;

        // Lock synchronization object
        private static object syncLock = new object();

        public static Logger GetInstance()
        {
            // Support multithreaded applications through
            // 'Double checked locking' pattern which (once
            // the instance exists) avoids locking each
            // time the method is invoked
            if (_instance == null)
            {
                lock (syncLock)
                {
                    if (_instance == null)
                    {
                        ConfigFile = "Log4NetCottontailApi.config";
                        _instance = new Logger(ConfigFile);
                    }
                }
            }
            return _instance;
        }

        private Logger(string fileConfig) 
        {
            var path = AppDomain.CurrentDomain.BaseDirectory + fileConfig;
            var fileInfo = new FileInfo(path);
            log4net.Config.XmlConfigurator.Configure(fileInfo);

            logFile = log4net.LogManager.GetLogger("RiotApiClient-File");
            logConsole = log4net.LogManager.GetLogger("RiotApiClient-Console");
        }

        public static void Configure(string fileConfig)
        {
            ConfigFile = fileConfig;
        }

        public void Info(string message, LogOutput output)
        {
            GetLogger(output).Info(message);
        }

        public void Warm(string message, LogOutput output)
        {
            GetLogger(output).Warn(message);
        }

        public void Error(string message, LogOutput output)
        {
            GetLogger(output).Error(message);
        }

        public void Debug(string message, LogOutput output)
        {
            GetLogger(output).Debug(message);
        }

        public void Fatal(string message, LogOutput output)
        {
            GetLogger(output).Fatal(message);
        }

        private log4net.ILog GetLogger(LogOutput output)
        {
            switch (output)
            {
                case LogOutput.File:
                    return logFile;
                case LogOutput.Console:
                    return logConsole;
                default:
                    throw new InvalidEnumArgumentException(output.ToString());
            }

            return null;
        }
    }
}
