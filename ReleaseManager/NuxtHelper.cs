using Microsoft.AspNetCore.SpaServices;
using System.Diagnostics;
using System.Net.NetworkInformation;

namespace ReleaseManager
{
    public static class NuxtHelper
    {
        // default port number of 'npm run dev'
        private const int Port = 3000;
        private static readonly Uri NuxtServerUrl = new ($"http://localhost:{Port}");

        public static void UseNuxtDevelopmentServer(this ISpaBuilder spa)
        {
            const string argument = "dev";
            const string workingDirectory = "Nuxt";
            const string nuxtCommand = $"cd {workingDirectory} && yarn {argument}";

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

            process.OutputDataReceived += (_, args) =>
            {
                if (!string.IsNullOrEmpty(args.Data))
                {
                    Console.WriteLine(args.Data);
                }
            };

            process.EnableRaisingEvents = true;
            process.Exited += (_, _) =>
            {
                Console.WriteLine("Nuxt development server process has exited.");
            };

            process.Start();
            process.BeginOutputReadLine();

            // Ensure that the process is stopped when the ASP.NET Core app is stopped
            AppDomain.CurrentDomain.ProcessExit += (_, _) =>
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
