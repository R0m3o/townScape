using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TownScape
{
    class Field
    {
        public int foodPoints = 0;
        static readonly object lockObject = new object(); //used to lock shared data

        //booleans used to control looping of thread
        bool fieldActive = true;
        bool level1 = true;

        public int FoodPoints
        {
            get { return foodPoints; }
            set { foodPoints = value; }
        }

        public void TheField()
        {
            Thread fieldThread = new Thread(RunField);
            fieldThread.IsBackground = true;

            fieldThread.Start();
        }

        public void RunField()
        {

            while (level1 == true && fieldActive == true) 
            {
                lock (lockObject)
                {
                    //1000 = 1 sec, 5000 = 5 sec, 30000 = 30 sec
                    Thread.Sleep(20000);

                    foodPoints += 25;
                }

            }
        }
    }
}
