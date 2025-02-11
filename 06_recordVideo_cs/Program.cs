using System;
using System.Drawing;

namespace ConsoleApp1
{
    class Program
    {
        static int keepRunning = 1;
        static void Main(string[] args)
        {
            if (args.Length != 6)
            {
                throw new ArgumentException("Invalid number of cli arguments");
            }

            Console.WriteLine("Example 06 video");

            Console.WriteLine("loading user settings...");
            cuvis_net.General.Init(args[0]);

            Console.WriteLine("Loading calibration...");
            var calib = new cuvis_net.Calibration(args[1]);

            Console.WriteLine("Loading acquisition context...");
            var acquistionContext = new cuvis_net.AcquistionContext(calib);

            Console.WriteLine("Prepare saving of measurements...");
            var general_settings = cuvis_net.GeneralExportSettings.Default;
            general_settings.PanSharpeningAlgorithmType = cuvis_net.PanSharpeningAlgorithm.Noop;
            general_settings.BlendOpacity = 1.0;
            general_settings.ExportDir = args[2];

            var sa = cuvis_net.SaveArgs.Default;
            sa.AllowDrop = true;
            sa.AllowOverride = true;
            sa.AllowSessionFile = true;

            Console.WriteLine("Writing files to:");


            var cubeExporter = new cuvis_net.CubeExporter(general_settings, sa);

            Console.WriteLine("Waiting for camera to become online");
            while (!acquistionContext.Ready)
            {
                System.Threading.Thread.Sleep(1000);
                Console.Write(".");
            }

            Console.WriteLine("components:");
            foreach (var component in acquistionContext.Components)
            {
                cuvis_net.ComponentInfo info = component.Info;

                Console.WriteLine(" {0} is {1}", info.DisplayName, (component.Online ? "online" : "offline"));
            }

            Console.WriteLine("initializing hardware...");
            acquistionContext.SessionData = new cuvis_net.SessionData("video", 0, 0);
            acquistionContext.FPS = int.Parse(args[5]);
            acquistionContext.IntegrationTime = int.Parse(args[3]); //in ms
            acquistionContext.OperationMode = cuvis_net.OperationMode.Internal;
            acquistionContext.AutoExposure = int.Parse(args[4]) == 0;
            acquistionContext.Continuous = true;


            while (keepRunning != 0)
            {
                do
                {
                    if (acquistionContext.HasNextMeasurement)
                    {
                        break;

                    }
                    System.Threading.Thread.Sleep(1);
                } while (keepRunning != 0);

                cuvis_net.Measurement mesu = acquistionContext.GetNextMeasurement(1);

                if (mesu != null)
                {
                    cubeExporter.Apply(mesu);
                    mesu.Dispose();
                }
            }

            cuvis_net.General.Shutdown();
            Console.WriteLine("finished.");
        }
    }
}
