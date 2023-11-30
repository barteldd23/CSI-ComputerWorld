using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDB.Utility.Interfaces
{
    public interface IComputer
    {
        // Anything implementing this interface will be required to have
        // the following properties and methods

        int Id { get; set; }
        int HardDriveSize { get; set; }
        string Manufacturer { get; set; }
        bool Write();
        int DoIt(string userId);
    }
}
