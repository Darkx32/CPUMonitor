using System;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace CPUMonitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string textCpu = "CPU Usage: ";
        const string textMemoryUsage = "Memory Usage: ";
        const string textMemoryRemain = "Memory Remain: ";
        const string textGpu = "GPU Usage: ";

        PerformanceCounter cpuU = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        PerformanceCounter memU = new PerformanceCounter("Memory", "% Committed Bytes In Use");
        PerformanceCounter memR = new PerformanceCounter("Memory", "Available MBytes");
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timerFunction);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void timerFunction(object? obj, EventArgs e)
        {
            cpu.Content = textCpu + valueTR(cpuU) + "%";
            mUsage.Content = textMemoryUsage + valueTR(memU) + "%";
            mRemain.Content = textMemoryRemain + memR.NextValue() + "MB";
        }

        string valueTR(PerformanceCounter pc)
        {
            return Math.Round(pc.NextValue()).ToString();
        }
    }
}
