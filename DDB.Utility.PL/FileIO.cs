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
            catch (FileNotFoundException)
            {
                // Do other cool stuff. Write a flat file.
                throw;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                // Do this at the end always.

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
            catch (FileNotFoundException)
            {
                // Do other cool stuff. Write a flat file.
                throw;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                // Do this at the end always.

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
            catch (FileNotFoundException)
            {
                // Do other cool stuff. Write a flat file.
                throw;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                // Do this at the end always.

            }
        }

        public static bool Write(string filePath, string data)
        {
            try
            {
                StreamWriter streamWriter = File.AppendText(filePath);
                streamWriter.WriteLine(data);
                streamWriter.Close();
                streamWriter = null;
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Read()
        {

        }

        public static void Rename(string source, string target)
        {
            try
            {
                if(File.Exists(source))
                {
                    File.Move(source, target);
                    File.Delete(source);
                }
                else
                {
                    throw new FileNotFoundException("File Not Found.", source);
                }
            }
            catch (FileNotFoundException)
            {
                // Do other cool stuff. Write a flat file.
                throw;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                // Do this at the end always.

            }
        }
    }
}
