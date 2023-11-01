namespace DDB.ComputerWorld.PL.Test
{
    [TestClass]
    public class utFileIO
    {
        [TestInitialize]
        public void Init()
        {
            string fakeFileName = AppDomain.CurrentDomain.BaseDirectory + "fakefile.txt";
            StreamWriter streamWriter = File.CreateText(fakeFileName);
            streamWriter.Close();
            streamWriter = null;
        }
        [TestCleanup]
        public void Cleanup()
        {
            string fakeFileName = AppDomain.CurrentDomain.BaseDirectory + "fakefile.txt";

            string fakeTargetFileName = AppDomain.CurrentDomain.BaseDirectory + "fakefile1.txt";

            if (File.Exists(fakeFileName))
            {
                File.Delete(fakeFileName);
            }

            if (File.Exists(fakeTargetFileName))
            {
                File.Delete(fakeTargetFileName);
            }
        }
        [TestMethod]
        public void CopyTest()
        {
            string fakeFileName = AppDomain.CurrentDomain.BaseDirectory + "fakefile.txt";
            string fakeTargetFileName = AppDomain.CurrentDomain.BaseDirectory + "fakefile1.txt";

            FileIO.Copy(fakeFileName, fakeTargetFileName);

            Assert.IsTrue(File.Exists(fakeTargetFileName));
        }

        [TestMethod]
        public void MoveTest()
        {
            string fakeFileName = AppDomain.CurrentDomain.BaseDirectory + "fakefile.txt";
            string fakeTargetFileName = AppDomain.CurrentDomain.BaseDirectory + "fakefile1.txt";

            FileIO.Move(fakeFileName, fakeTargetFileName);

            Assert.IsTrue(File.Exists(fakeTargetFileName));
        }

        [TestMethod]
        public void DeleteTest()
        {
            string fakeFileName = AppDomain.CurrentDomain.BaseDirectory + "fakefile.txt";
            string fakeTargetFileName = AppDomain.CurrentDomain.BaseDirectory + "fakefile1.txt";

            FileIO.Delete(fakeFileName);

            Assert.IsFalse(File.Exists(fakeFileName));
        }

        [TestMethod]
        public void RenameTest()
        {
            string fakeFileName = AppDomain.CurrentDomain.BaseDirectory + "fakefile.txt";
            string fakeTargetFileName = AppDomain.CurrentDomain.BaseDirectory + "fakefile1.txt";

            FileIO.Rename(fakeFileName, fakeTargetFileName);

            Assert.IsTrue(File.Exists(fakeTargetFileName));
            Assert.IsFalse(File.Exists(fakeFileName));
        }

    }
}