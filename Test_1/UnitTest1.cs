using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lab1_Knapsack;


namespace Test_1
{
    [TestClass]
    public class UnitTest1
    {
        

        [TestMethod]
        public void test1()
        {
            for (int i = 10; i <= 100; i += 10)
            {
                for (int j = 0; j < 10; j++)
                {

                    Knapsack knapsack = new Knapsack(i, j);
                    Backpack backpack = new Backpack(i * 3);
                    Assert.AreEqual(i, knapsack.GetCount());
                }
            }

        }

        [TestMethod]
        public void test2()
        {
            for (int i = 10; i <= 100; i += 10)
            {
                for (int j = 0; j < 10; j++)
                {

                    Knapsack knapsack = new Knapsack(i, j);
                    Backpack backpack = new Backpack(i*3);
                    knapsack.steal(backpack);
                    Assert.AreEqual(i, knapsack.GetCount());
                    Assert.IsTrue(backpack.max_weight >= backpack.act_weight);
                }
            }

        }

        [TestMethod]
        public void test3()
        {
            Knapsack knapsack1 = new Knapsack(0, 0);
            knapsack1.AddItem(1, 2);
            knapsack1.AddItem(3, 4);
            knapsack1.AddItem(5, 6);
            Backpack backpack1 = new Backpack(8);
            knapsack1.steal(backpack1);

            Knapsack knapsack2 = new Knapsack(0, 0);
            knapsack2.AddItem(5, 6);
            knapsack2.AddItem(3, 4);
            knapsack2.AddItem(1, 2);
            Backpack backpack2 = new Backpack(8);
            knapsack2.steal(backpack2);

            Assert.IsTrue(backpack1.GetValue() == backpack2.GetValue());
            Assert.IsTrue(backpack1.GetRatio() == backpack2.GetRatio());


        }


    }
}
