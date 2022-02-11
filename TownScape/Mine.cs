using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TownScape
{
    delegate void UpgradeMineHandler(Mine mine);
    class Mine
    {
        Sawmill sawmill = new Sawmill();
        Field field = new Field();

        public event UpgradeMineHandler UpgradeMine;
        public int goldPoints = 0;
        static readonly object lockObject = new object(); //used to lock shared data

        //booleans used to control looping of thread
        bool mineActive = true;
        public int level = 1;

        string minelvl = "lvl 1";
        string goldHarvest = "25 gold pr. 5 seconds";
        string buildTime = "20 sec";
        string upgradeGoldHarvest = "harvest 50 gold pr. 8 seconds";
        string woodCost = "wood: 100";
        string goldCost = "gold: 100";
        string foodCost = "food: 50";

        public int GoldPoints
        {
            get { return goldPoints; }
            set { goldPoints = value; }
        }

        public string Minelvl
        {
            get { return minelvl; }
            set { minelvl = value; }
        }

        public string GoldHarvest
        {
            get { return goldHarvest; }
            set { goldHarvest = value; }
        }

        public string BuildTime
        {
            get { return buildTime; }
            set { buildTime = value; }
        } 

        public string UpgradeGoldHarvest
        {
            get { return upgradeGoldHarvest; }
            set { upgradeGoldHarvest = value; }
        }

        public string WoodCost
        {
            get { return woodCost; }
            set { woodCost = value; }
        }

        public string GoldCost
        {
            get { return goldCost; }
            set { goldCost = value; }
        }

        public string FoodCost
        {
            get { return foodCost; }
            set { foodCost = value; }
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
                while (level == 1 && mineActive == true)
                {
                    //1000 = 1 sec, 5000 = 5 sec, 30000 = 30 sec
                    Thread.Sleep(5000);

                    goldPoints += 25;
                }
                minelvl = "lvl 2";
                goldHarvest = "50 gold pr. 8 seconds";
                buildTime = "40 sec";
                upgradeGoldHarvest = "harvest 100 gold pr. 15 seconds";
                woodCost = "wood: 150";
                GoldCost = "gold: 200";
                foodCost = "food: 125";

                //building the upgrade
                Thread.Sleep(20000);

                while (level == 2 && mineActive == true)
                {
                    Thread.Sleep(8000);

                    goldPoints += 50;
                }
                minelvl = "lvl 3";
                goldHarvest = "100 gold pr. 15 seconds";
                buildTime = "";
                upgradeGoldHarvest = "";
                woodCost = "";
                GoldCost = "";
                foodCost = "";

                //building the upgrade
                Thread.Sleep(40000);

                while (level == 3 && mineActive == true)
                {
                    Thread.Sleep(15000);

                    goldPoints += 100;
                }

            }
        }

        protected virtual void OnUpgradeMineEvent()
        {
            if (level == 1)
            {
                if (GoldPoints >= 100 && sawmill.WoodPoints >= 100 && field.FoodPoints >= 50)
                {
                    GoldPoints -= 100;
                    sawmill.WoodPoints -= 100;
                    field.FoodPoints -= 50;
                    level++;
                }
            }
            else if (level == 2)
            {
                if (GoldPoints >= 200 && sawmill.WoodPoints >= 150 && field.FoodPoints >= 125)
                {
                    GoldPoints -= 200;
                    sawmill.WoodPoints -= 150;
                    field.FoodPoints -= 125;
                    level++;
                }
            }
        }
    }
}
