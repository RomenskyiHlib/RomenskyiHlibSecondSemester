using SecondLab.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondLab.Utility
{
    internal class ProgramRun
    {
        public static void Run() 
        { 
            List<Firm> Firms = ListFiller.Filler();
            AllFirmMethodsTest.FirmMethodsTest(Firms);
        
        }
      
    }
}
