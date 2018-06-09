using System;
using System.Data;
using Soulstone.Mp3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Soulstone.Test
{
    
    
    /// <summary>
    ///This is a test class for MusicTrackManagerTest and is intended
    ///to contain all MusicTrackManagerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MusicTrackManagerTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for Instance
        ///</summary>
        [TestMethod()]
        public void InstanceTest()
        {
            MusicTrackManager actual;
            actual = MusicTrackManager.Instance;
            Assert.AreNotEqual(null, actual, "MusicTrackManager instance cannot be null.");
        }

        /// <summary>
        ///A test for StartupCheck
        ///</summary>
        [TestMethod()]
        public void StartupCheckTest()
        {
            MusicTrackManager target = MusicTrackManager.Instance;
            bool actual;
            actual = target.StartupCheck();
            Assert.AreEqual(true, actual, "Test DB connection failed.");
        }

        /// <summary>
        ///A test for Search
        ///</summary>
        [TestMethod()]
        public void SearchTest()
        {
            MusicTrackManager target = MusicTrackManager.Instance;
            string album = "Chamame";
            string artist = "Tarrago";
            string title = string.Empty;
            int year = 0;
            string genre = string.Empty;
            DataTable actual;
            actual = target.Search(album, artist, title, year, genre);
            Assert.AreEqual(2, actual.Rows.Count, "This search return no results.");
        }

        /// <summary>
        ///A test for GetTotalFileCount
        ///</summary>
        [TestMethod()]
        public void GetTotalFileCountTest()
        {
            MusicTrackManager target = MusicTrackManager.Instance;
            DataRow actual;
            actual = target.GetTotalFileCount();
            Assert.IsNotNull(actual, "File count result cannot be null");
            Assert.AreEqual(3, Convert.ToInt32(actual[0]), "Total file count mismatch");
        }
    }
}
