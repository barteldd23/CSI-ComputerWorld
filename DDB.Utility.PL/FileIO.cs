using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDB.Utility.PL
{
    public static class FileIO
    {
        public static void Copy(string source, string target, bool overwrite=false)
        {
            try
            {
                if (File.Exists(source))
                {
                    File.Copy(source, target, overwrite);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Move(string source, string target, bool overwrite=false)
        {
            try
            {
                if (File.Exists(source))
                {
                    File.Move(source, target, overwrite);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Delete(string source)
        {
            try
            {
                if (File.Exists(source))
                {
                    File.Delete(source);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Write()
        {

        }

        public static void Read()
        {

        }

        public static void Rename(string source, string target)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
