using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public static bool Exists(string source)
        {
            return File.Exists(source);
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
            catch (FileNotFoundException)
            {
                throw;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static string Read(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    FileStream fileStream = new FileStream(filePath, 
                                                           FileMode.Open, 
                                                           FileAccess.Read, 
                                                           FileShare.ReadWrite);

                    StreamReader streamReader = new StreamReader(fileStream);

                    string data = streamReader.ReadToEnd();

                    fileStream.Close();
                    streamReader.Close();
                    streamReader = null;

                    return data;
                }
                else
                {
                    throw new FileNotFoundException("File Not Found.", filePath);
                }
            }
            catch (FileNotFoundException)
            {
                throw;
            }
            catch (Exception)
            {

                throw;
            }
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
