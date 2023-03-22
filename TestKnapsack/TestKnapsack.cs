using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using lab1;

namespace TestKnapsack
{
    [TestClass]
    public class TestKnapsack
    {
        [TestMethod]
        public void TestOnlyOneItemFillKnapsack()
        {
            Knapsack test_knapsack = new Knapsack();
            test_knapsack.AddItem(new Item(100, 1, 1));            
            test_knapsack.AddItem(new Item(1, 100, 2));            
            test_knapsack.AddItem(new Item(1, 100, 3));            
            test_knapsack.AddItem(new Item(1, 100, 4));
            KnapsackResult result = test_knapsack.run(20);
            Assert.AreEqual(100, result.GetSumValues());
            Assert.AreEqual(1, result.GetSumWeights());
        }


        [TestMethod]
        public void TestNoItemsFillKnapsack()
        {
            Knapsack test_knapsack = new Knapsack();
            test_knapsack.AddItem(new Item(10, 10, 1));
            test_knapsack.AddItem(new Item(20, 20, 2));
            test_knapsack.AddItem(new Item(30, 30, 3));
            test_knapsack.AddItem(new Item(40, 40, 4));
            test_knapsack.AddItem(new Item(50, 50, 5));
            KnapsackResult result = test_knapsack.run(5);
            Assert.AreEqual(0, result.GetSumValues());
            Assert.AreEqual(0, result.GetSumWeights());
        }

        [TestMethod]
        public void TestItemsOrder()
        {
            Knapsack test_knapsack = new Knapsack();
            test_knapsack.AddItem(new Item(10, 10, 1));
            test_knapsack.AddItem(new Item(20, 20, 2));
            test_knapsack.AddItem(new Item(30, 30, 3));
            test_knapsack.AddItem(new Item(40, 40, 4));
            test_knapsack.AddItem(new Item(50, 50, 5));
            KnapsackResult result = test_knapsack.run(150);
            Assert.AreEqual(150, result.GetSumValues());
            Assert.AreEqual(150, result.GetSumWeights());

            Knapsack test_knapsack2 = new Knapsack();
            test_knapsack2.AddItem(new Item(50, 50, 5));
            test_knapsack2.AddItem(new Item(10, 10, 1));
            test_knapsack2.AddItem(new Item(30, 30, 3));
            test_knapsack2.AddItem(new Item(40, 40, 4));
            test_knapsack2.AddItem(new Item(20, 20, 2));
            KnapsackResult result2 = test_knapsack2.run(150);
            Assert.AreEqual(150, result2.GetSumValues());
            Assert.AreEqual(150, result2.GetSumWeights());
        }

        [TestMethod]
        public void TestResultWithSeedEqualOne()
        {
            Knapsack test_knapsack = new Knapsack(10, 1);
            KnapsackResult result = test_knapsack.run(20);
            Assert.AreEqual(23, result.GetSumValues());
            Assert.AreEqual(18, result.GetSumWeights());
        }

        [TestMethod]
        public void TestResultWithSeedEqualTwo()
        {
            Knapsack test_knapsack = new Knapsack(10, 2);
            KnapsackResult result = test_knapsack.run(20);
            Assert.AreEqual(43, result.GetSumValues());
            Assert.AreEqual(18, result.GetSumWeights());
        }
    }
}
