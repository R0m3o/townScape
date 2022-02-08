using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TownScape
{
    class Sawmill
    {
        public int woodPoints = 0;
        static readonly object lockObject = new object(); //used to lock shared data

        //booleans used to control looping of thread
        bool sawmillActive = true;
        bool level1 = true;

        public int WoodPoints
        {
            get { return woodPoints; }
            set { woodPoints = value; }
        }
        
        public void TheSawmill()
        {
            Thread sawmillThread = new Thread(RunSawmill);
            sawmillThread.IsBackground = true;

            sawmillThread.Start();
        }

        public void RunSawmill()
        {
            lock(lockObject)
            {
                while (level1 == true && sawmillActive == true)
                {
                    //1000 = 1 sec, 5000 = 5 sec, 30000 = 30 sec
                    Thread.Sleep(1000);

                    woodPoints += 25;
                }
            }
        }
    }
}
