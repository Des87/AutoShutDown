using AutoShutDown;
using System.Diagnostics;

Counter c = new Counter();
c.ShutDownProcess();


Process.Start("shutdown", "/s /t 0");
