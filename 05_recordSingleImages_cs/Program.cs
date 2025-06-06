using System;
using System.Drawing;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 5)
            {
                throw new ArgumentException("Invalid number of cli arguments");
            }

            Console.WriteLine("Example 05 record single images");

            Console.WriteLine("loading user settings...");
            cuvis_net.General.Init(args[0]);

            Console.WriteLine("loading Calibration and processing context...");
            var calibration = new cuvis_net.Calibration(args[1]);
            var processingContext = new cuvis_net.ProcessingContext(calibration);
            var acquistionContext = new cuvis_net.AcquistionContext(calibration);

            var general_settings = cuvis_net.GeneralExportSettings.Default;
            general_settings.ExportDir = args[2];
            
            var sa = cuvis_net.SaveArgs.Default;
            sa.AllowDrop= true;
            sa.AllowOverride = true;
            sa.AllowSessionFile = true;

            var cubeExporter = new cuvis_net.CubeExporter(general_settings, sa);

            Console.WriteLine("Waiting for camera to become online");
            while (!acquistionContext.Ready)
            {
                System.Threading.Thread.Sleep(1000);
                Console.Write(".");
            }

            acquistionContext.IntegrationTime = int.Parse(args[3]); //in ms
            acquistionContext.OperationMode = cuvis_net.OperationMode.Software;

            Console.WriteLine("Start recording now");

            for (int i = 0; i < int.Parse(args[4]); i++)
            {
                Console.WriteLine("Record image # {0}/" + args[4] + " (async)", i + 1);
                cuvis_net.AsyncMesu am = acquistionContext.Capture();
                var res = am.Get(TimeSpan.FromSeconds(5));
                if (res.Item2 != null)
                {
                    cuvis_net.Measurement mesu = res.Item2;

                    processingContext.Apply(mesu);

                    cubeExporter.Apply(mesu);
                    Console.WriteLine("done");

                    mesu.Dispose();
                }
                else 
                {
                    Console.WriteLine("failed");
                }
            }

            cuvis_net.General.Shutdown();
            Console.WriteLine("finished.");
        }
    }
}
