using System;
using System.Diagnostics;
using System.Threading;
using System.IO;
using Newtonsoft.Json;

public class Configuration
{
    public int CpuUsageThreshold { get; set; }
}


public class SystemMonitor
{
    private PerformanceCounter cpuCounter;
    private PerformanceCounter ramCounter;

    public SystemMonitor()
    {
        cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        ramCounter = new PerformanceCounter("Memory", "Available MBytes");
    }

    public float GetCpuUsage()
    {
        return cpuCounter.NextValue();
    }

    public float GetAvailableMemory()
    {
        return ramCounter.NextValue();
    }

    public Configuration GetConfiguration()
    {
        string json = File.ReadAllText("appsettings.json");
        return JsonConvert.DeserializeObject<Configuration>(json);
    }

    public void CheckPerformance(float cpuUsage, Configuration value)
    {
        if (cpuUsage > value.CpuUsageThreshold)
        {
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "Application";
                eventLog.WriteEntry("High CPU usage detected: " + cpuUsage, EventLogEntryType.Warning);
            }
        }
    }

    public void MonitorSystem()
    {
        while (true)
        {
            float cpuUsage = GetCpuUsage();
            float availableMemory = GetAvailableMemory();
            Console.WriteLine($"CPU Usage: {cpuUsage}%");
            Console.WriteLine($"Available Memory: {availableMemory}MB");
            CheckPerformance(cpuUsage, GetConfiguration());
            Thread.Sleep(1000); 
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        SystemMonitor monitor = new SystemMonitor();
        monitor.MonitorSystem();
    }
}
