using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StrategyPattern;
using System.Collections.Generic;

namespace ScheduleTypeTests
{
    [TestClass]
    public class ScheduleTesting
    {
        [TestMethod]
        public void FCFS()
        {
            int[] requests = new int[]
            {
                7,15,33,47,8,29,48,90,13
            };
            int header = 50;
            OS FCFS = new OS(new FCFS(), header, requests);

            FCFS.scheduleRequest();
            List<int> result = FCFS.ScheduledRequests;

            List<int> expectedResult = new List<int>()
            {
                7,15,33,47,8,29,48,90,13
            };

            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expectedResult[i], result[i]);
            }
            int expectedSeek = 281;
            int actualSeek = FCFS.LastSeekTime;
            //Seek time check
            Assert.AreEqual(expectedSeek, actualSeek);

        }
        [TestMethod]
        public void SSTF()
        {
            int[] requests = new int[]
            {
                7,15,33,47,8,29,48,90,13
            };
            int header = 50;
            OS SSTF = new OS(new SSTF(), header, requests);

            SSTF.scheduleRequest();
            List<int> result = SSTF.ScheduledRequests;

            List<int> expectedResult = new List<int>()
            {
                48,47,33,29,15,13,8,7,90
            };

            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expectedResult[i], result[i]);
            }

            int actualSeek = SSTF.LastSeekTime;
            int expectedSeek = 126;

            Assert.AreEqual(expectedSeek, actualSeek);
            //int expectedSeek = 281;
            //int actualSeek = SSTF.LastSeekTime;
            //Seek time check
            //Assert.AreEqual(expectedSeek, actualSeek);

        }
         [TestMethod]
        public void SCAN()
        {
            int[] requests = new int[]
            {
                7,15,33,47,8,29,48,90,13
            };
            int header = 50;
            OS SCAN = new OS(new SCAN(), header, requests);

            SCAN.scheduleRequest();
            List<int> result = SCAN.ScheduledRequests;

            List<int> expectedResult = new List<int>()
            {
                48,47,33,29,15,13,8,7,90
            };

            for (int i = 0; i < result.Count; i++)
            {
               
                Assert.AreEqual(expectedResult[i], result[i]);
            }
            //int expectedSeek = 281;
            //int actualSeek = SSTF.LastSeekTime;
            //Seek time check
            //Assert.AreEqual(expectedSeek, actualSeek);
            

        }
    }
}
