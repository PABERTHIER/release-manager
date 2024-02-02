using Microsoft.AspNetCore.SpaServices;
using System.Diagnostics;
using System.Net.NetworkInformation;

namespace NuxtIntegration.Helpers
{
    public static class NuxtHelper
    {
        // default port number of 'npm run dev'
        private static readonly int Port = 3000;
        private static readonly Uri NuxtServerUrl = new ($"http://localhost:{Port}");

        public static void UseNuxtDevelopmentServer(this ISpaBuilder spa)
        {
            string argument = "dev";
            string workingDirectory = "Nuxt";
            string nuxtCommand = $"cd {workingDirectory} && yarn {argument}";

            if (IsRunning())
            {
                spa.UseProxyToSpaDevelopmentServer(NuxtServerUrl);
                return;
            }

            ProcessStartInfo processStartInfo = new ()
            {
                FileName = "cmd.exe",
                Arguments = $"/C {nuxtCommand}",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            };

            Process process = new ()
            {
                StartInfo = processStartInfo,
            };

            process.OutputDataReceived += (sender, args) =>
            {
                if (!string.IsNullOrEmpty(args.Data))
                {
                    Console.WriteLine(args.Data);
                }
            };

            process.EnableRaisingEvents = true;
            process.Exited += (sender, args) =>
            {
                Console.WriteLine("Nuxt development server process has exited.");
            };

            process.Start();
            process.BeginOutputReadLine();

            // Ensure that the process is stopped when the ASP.NET Core app is stopped
            AppDomain.CurrentDomain.ProcessExit += (sender, args) =>
            {
                if (!process.HasExited)
                {
                    Console.WriteLine("Stopping Nuxt development server process...");
                    process.Kill();
                }
            };

            spa.UseProxyToSpaDevelopmentServer(NuxtServerUrl);
        }

        private static bool IsRunning() => IPGlobalProperties.GetIPGlobalProperties()
            .GetActiveTcpListeners()
            .Select(x => x.Port)
            .Contains(Port);
    }
}
