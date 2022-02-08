using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TownScape
{
    class Mine
    {
        public int goldPoints = 0;
        static readonly object lockObject = new object(); //used to lock shared data

        //booleans used to control looping of thread
        bool mineActive = true;
        bool level1 = true;

        public int GoldPoints
        {
            get { return goldPoints; }
            set { goldPoints = value; }
        }

        public void TheMine()
        {
            Thread mineThread = new Thread(RunMine);
            mineThread.IsBackground = true;

            mineThread.Start();
        }

        public void RunMine()
        {
            lock (lockObject)
            {
                while (level1 == true && mineActive == true)
                {
                    //1000 = 1 sec, 5000 = 5 sec, 30000 = 30 sec
                    Thread.Sleep(2000);

                    goldPoints += 25;
                }
                    
            }
        }
    }
}
