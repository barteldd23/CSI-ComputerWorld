using DDB.ComputerWorld.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDB.ComputerWorld.BL
{
    public static class ApplicationManager
    {
        public static List<Application> Populate(int computerId)
        {
            List<Application> list = new List<Application>();

            switch (computerId)
            {
                case 1:
                    list.Add(new Application { Id = 1, Name = "Google Chrome", Size = 100 });
                    list.Add(new Application { Id = 2, Name = "Visual Studio", Size = 150.25 });
                    list.Add(new Application { Id = 3, Name = "Steam", Size = 275 });
                    break;
                case 2:
                    list.Add(new Application { Id = 4, Name = "Microsoft Word", Size = 100.6 });
                    list.Add(new Application { Id = 5, Name = "Visual Studio Code", Size = 50 });
                    break;

            }

            return list;
        }
    }
}
