using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timer_Test
{
    class Program
    {
        static Stopwatch s = new Stopwatch();

        static void Main(string[] args)
        {
            System.Timers.Timer t = new System.Timers.Timer(5000);
            t.Elapsed += new ElapsedEventHandler(OnElapsed);

            Parallel.Invoke(() => t.Start(), () => s.Start());

            while (t.Enabled)
            {
                string arrow = "";
                double percent = ((s.ElapsedMilliseconds / t.Interval) * 100);

                for (int i = 0; i < 40; i++)
                {
                    if (i < (int)(percent / 2.5) - 1)
                    {
                        arrow += "=";
                    }
                    else if (i == (int)(percent / 2.5) - 1)
                    {
                        arrow += ">";
                    }
                    else
                    {
                        arrow += " ";
                    }
                }

                Console.Write("\r>{0}|{1}%", arrow, (int)percent);
            }
            Console.ReadKey();
        }

        static void OnElapsed(object sender, ElapsedEventArgs args)
        {
            ((System.Timers.Timer)sender).Stop();
            s.Stop();
            Console.WriteLine("\nDone!");
        }
    }
}
