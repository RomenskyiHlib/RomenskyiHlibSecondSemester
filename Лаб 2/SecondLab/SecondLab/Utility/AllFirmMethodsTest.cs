using SecondLab.model;
using SecondLab.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondLab.Utility
{
    internal class AllFirmMethodsTest
    {
        public static void FirmMethodsTest(List<Firm> Firms)
        {
            FirmMethods firmMethods = new FirmMethods();

            firmMethods.AllInformation(Firms);
            firmMethods.FirmWithNameFood();
            firmMethods.MarketingFirm();
            firmMethods.MarketingOrITFirm();
            firmMethods.MoreThanOneHundEmpTFirm();
            firmMethods.MoreThanOneHundButLessThanTreeHundEmpFirm();
            firmMethods.LondonFirm();
            firmMethods.DirectorWithLastnameWhiteFirm();
            firmMethods.MoreThaTwoYearsFirm();
            firmMethods.More150DaysFirm();
            firmMethods.LastnameAndNameFirm();
        }
    }
}
