#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading; 
#endregion
/*
 *  Written by Michele Cattafesta - http://www.mesta-automation.com
 *  This code is free, i'm not responsible on anything regarding it.
 *  You are free to do what you want with this code.
 */

/**
 *  Example of using global variables for a plc communication.
 *  Setting static variables permit the access to this variables 
 *  in all application.
 *  
 */ 
namespace HmiExample.PlcDriver
{
    public static class Plc
    {
        public static int MyPlcVariable { get; private set; } //this is read-only because it is a global variable that gets refreshed at every scan.
                                                        
        public static bool StopCommunication { get; set; } //this can be set also from outside the thread (in particular when closing the application)

        static Thread t;
		
		static Plc()
		{
			// this is an example of static constructor, that i don't need in this example and i leave it empty.
		}

        public static void StartCommunication()
        {
            t = new Thread(new ThreadStart(CommunicationThread));
            t.Name = "PlcCommunication";
            t.Start();
        }

        static readonly object _locker = new object();
        private static void CommunicationThread()
        {
            while (!StopCommunication)
            {
                lock (_locker)
                {
                    MyPlcVariable = ReadFromPlc();
                }
            }
        }

        /// <summary>
        /// simulate a read method
        /// </summary>
        private static int ReadFromPlc()
        {
            Thread.Sleep(1000); //long wait till reply
            return MyPlcVariable+1;
        }
    }
}
