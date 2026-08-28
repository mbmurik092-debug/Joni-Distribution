using System;
using System.IO;
using System.Text;
using System.Threading;

namespace Joni.RuntimeGate
{
    internal static class Program
    {
        private const string Version = "0.0.1";

        private static int Main(string[] args)
        {
            try
            {
                if (args.Length == 1 && args[0] == "--health")
                {
                    Console.WriteLine("JONI_RUNTIME_HEALTH_OK version=" + Version);
                    return 0;
                }

                if (args.Length == 1 && args[0] == "--version")
                {
                    Console.WriteLine(Version);
                    return 0;
                }

                if (args.Length == 3 && args[0] == "--run" && args[1] == "--heartbeat")
                {
                    return RunHeartbeat(args[2]);
                }

                Console.Error.WriteLine("Usage: --health | --version | --run --heartbeat <path>");
                return 64;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("JONI_RUNTIME_ERROR " + ex.GetType().Name + ": " + ex.Message);
                return 70;
            }
        }

        private static int RunHeartbeat(string heartbeatPath)
        {
            string directory = Path.GetDirectoryName(heartbeatPath);
            if (!string.IsNullOrEmpty(directory))
            {
                Directory.CreateDirectory(directory);
            }

            int pid = System.Diagnostics.Process.GetCurrentProcess().Id;
            var utf8NoBom = new UTF8Encoding(false);

            while (true)
            {
                string json =
                    "{\"status\":\"ok\",\"runtime\":\"joni-runtime-gate\",\"version\":\"" + Version +
                    "\",\"pid\":" + pid.ToString() +
                    ",\"utc\":\"" + DateTime.UtcNow.ToString("o") + "\"}";

                File.WriteAllText(heartbeatPath, json, utf8NoBom);
                Thread.Sleep(500);
            }
        }
    }
}
