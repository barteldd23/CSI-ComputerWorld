namespace DDB.ComputerWorld.PL.Test
{
    [TestClass]
    public class utFileIO
    {
        string fakeFileName = AppDomain.CurrentDomain.BaseDirectory + "fakefile.txt";
        string fakeTargetFileName = AppDomain.CurrentDomain.BaseDirectory + "fakefile1.txt";

        [TestInitialize]
        public void Init()
        {
            StreamWriter streamWriter = File.CreateText(fakeFileName);
            streamWriter.Close();
            streamWriter = null;
        }
        [TestCleanup]
        public void Cleanup()
        {
            
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
            
            FileIO.Copy(fakeFileName, fakeTargetFileName);

            Assert.IsTrue(File.Exists(fakeTargetFileName));
        }

        [TestMethod]
        public void MoveTest()
        {
           
            FileIO.Move(fakeFileName, fakeTargetFileName);

            Assert.IsTrue(File.Exists(fakeTargetFileName));
        }

        [TestMethod]
        public void DeleteTest()
        {
            
            FileIO.Delete(fakeFileName);

            Assert.IsFalse(File.Exists(fakeFileName));
        }

        [TestMethod]
        public void RenameTest()
        {
            
            FileIO.Rename(fakeFileName, fakeTargetFileName);

            Assert.IsTrue(File.Exists(fakeTargetFileName));
            Assert.IsFalse(File.Exists(fakeFileName));
        }

        [TestMethod]
        public void WriteTest()
        {
            bool result = FileIO.Write(fakeFileName, "Hello From Oshkosh");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ReadTest()
        {
            FileIO.Write(fakeFileName, "Hello From Oshkosh");
            string data = FileIO.Read(fakeFileName);
            Assert.IsTrue(data.Length > 0);
        }

    }
}