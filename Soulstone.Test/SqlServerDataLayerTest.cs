using Soulstone.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;

namespace Soulstone.Test
{
    
    
    /// <summary>
    ///This is a test class for SqlServerDataLayerTest and is intended
    ///to contain all SqlServerDataLayerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SqlServerDataLayerTest
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
            SqlServerDataLayer actual;
            actual = SqlServerDataLayer.Instance;
            Assert.AreNotEqual(null, actual, "SqlServerDataLayer instance cannot be empty.");
        }

        /// <summary>
        ///A test for TestConnection
        ///</summary>
        [TestMethod()]
        public void TestConnectionTest()
        {
            DataLayerBase target = DataLayerFactory.Instance.GetDataLayer(DataLayerType.SqlServer);
            bool expected = true;
            bool actual;
            actual = target.TestConnection();
            Assert.AreEqual(expected, actual, "Test connection fail.");
        }

        /// <summary>
        ///A test for Search
        ///</summary>
        [TestMethod()]
        public void SearchTest()
        {
            DataLayerBase target = DataLayerFactory.Instance.GetDataLayer(DataLayerType.SqlServer);
            DataTable actual;

            //all fields
            string album = "Greatest Hits";
            string artist = "Roxette";
            string title = "Dangerous";
            int year = 2004;
            string genre = "Rock";
            actual = target.Search(album, artist, title, year, genre);
            if (actual != null)
            {
                Assert.AreEqual(1, actual.Rows.Count, "Search all field failed.");
                Assert.AreEqual(@"c:\Music\coco.mp3", actual.Rows[0][DBConstants.Path].ToString(), "Search result path mismatch.");
            }
            else
            {
                Assert.IsTrue(true, "DataTable from search is null.");
            }
        }

        /// <summary>
        ///A test for GetTotalFileCount
        ///</summary>
        [TestMethod()]
        public void GetTotalFileCountTest()
        {
            SqlServerDataLayer_Accessor target = new SqlServerDataLayer_Accessor();
            int expected = 3;
            DataRow actual;
            actual = target.GetTotalFileCount();
            Assert.IsNotNull(actual, "Total file count cannot be null.");
            Assert.AreEqual(expected, Convert.ToInt32(actual[0]), "Total files doesn't match.");
        }

        /// <summary>
        ///A test for CreateOrUpdateMusicTrack
        ///</summary>
        [TestMethod()]
        public void CreateOrUpdateMusicTrackTest()
        {
            DataLayerBase target = DataLayerFactory.Instance.GetDataLayer(DataLayerType.SqlServer);

            string hostName = "Frostmourne";
            target.CreateHost(hostName);

            string filePath = @"c:\Music\chamame.mp3";
            string album = "Chamame";
            string artist = "Tarrago Ross";
            string title = "Curuzu Cuatia";
            int year = 1966;
            string genre = "Folklore";
            target.CreateOrUpdateMusicTrack(hostName, filePath, album, artist, title, year, genre);

            filePath = @"c:\Music\coco.mp3";
            album = "Greatest Hits";
            artist = "Roxette";
            title = "Dangerous";
            year = 2004;
            genre = "Rock";
            target.CreateOrUpdateMusicTrack(hostName, filePath, album, artist, title, year, genre);

            filePath = @"c:\Music\Arjona\pinguinos en la cama.mp3";
            album = "Arjona";
            artist = "Ricardo Arjona";
            title = "Pinguinos en la cama";
            year = 2005;
            genre = "Melódico";
            target.CreateOrUpdateMusicTrack(hostName, filePath, album, artist, title, year, genre);

            DataTable dt = target.Search(album, artist, title, year, genre);
            Assert.AreEqual(1, dt.Rows.Count, "Music Track creation fail.");
            if (dt.Rows.Count > 0)
            {
                Guid musicTrackId = new Guid(dt.Rows[0][DBConstants.MusicTrackId].ToString());
                DataRow dr = target.GetMusicTrack(musicTrackId);
                if (dr != null)
                {
                    Assert.AreEqual(artist, dr[DBConstants.Artist].ToString(), "GetMusicTrack fail.");
                }
            }
        }

        /// <summary>
        ///A test for CreateHost
        ///</summary>
        [TestMethod()]
        public void CreateHostTest()
        {
            DataLayerBase target = DataLayerFactory.Instance.GetDataLayer(DataLayerType.SqlServer);
            string hostName = "LG";
            target.CreateHost(hostName);

            string filePath = @"c:\LG\chamame.mp3";
            string album = "Chamame";
            string artist = "Tarrago Ross";
            string title = "Curuzu Cuatia";
            int year = 1966;
            string genre = "Folklore";
            target.CreateOrUpdateMusicTrack(hostName, filePath, album, artist, title, year, genre);

            int totalHostCount = 0;
            if (target.GetAllHosts() != null)
            {
                totalHostCount = target.GetAllHosts().Rows.Count;
            }

            Assert.AreEqual(2, totalHostCount, "It should be 2 Host on the database.");
        }

        /// <summary>
        ///A test for HostExists
        ///</summary>
        [TestMethod()]
        public void HostExistsTest()
        {
            DataLayerBase target = DataLayerFactory.Instance.GetDataLayer(DataLayerType.SqlServer);
            string hostName = "Frostmourne";
            bool actual;
            actual = target.HostExists(hostName);
            Assert.AreEqual(true, actual, "Host Frostmourne should exists.");
        }
    }
}
