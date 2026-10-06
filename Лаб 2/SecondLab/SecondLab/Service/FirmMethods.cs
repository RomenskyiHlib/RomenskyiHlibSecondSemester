using SecondLab.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondLab.Service
{
    internal class FirmMethods
    {
        private List<Firm> firms { get; set; }
        public void AllInformation()
        {
            var allinfo = from firm in firms
                          select firm;
            ConsoleMethods.Show("Information about all firms:", allinfo);
        }

        public void FirmWithNameFood()
        {
            var foodFirm = from firm in firms
                           where firm.name == "Food"
                           select firm;
            ConsoleMethods.Show("A firm called Food:", foodFirm);
        }

        public void MarketingFirm()
        {
            var marketFirms = from firm in firms
                              where firm.businessFocus == Focus.marketing
                              select firm;
            ConsoleMethods.Show("Marketing Firms:", marketFirms);
        }

        public void MarketingOrITFirm()
        {
            var marketOrItFirms = from firm in firms
                                  where firm.businessFocus == Focus.marketing || firm.businessFocus == Focus.it
                                  select firm;
            ConsoleMethods.Show("Marketing or IT Firms:", marketOrItFirms);
        }

        public void MoreThanOneHundEmpTFirm()
        {
            var fir = from firm in firms
                        where firm.numberOfEmployees > 100
                        select firm;
            ConsoleMethods.Show("Firms with more than a hundred employees:", fir);
        }
        public void MoreThanOneHundButLessThanTreeHundEmpFirm()
        {
            var fir = from firm in firms
                        where firm.numberOfEmployees > 100 && firm.numberOfEmployees < 300
                        select firm;
            ConsoleMethods.Show("Firms with more than 100 but fewer than 300 employees:", fir);
        }
        public void LondonFirm()
        {
            var LondonFirms = from firm in firms
                              where firm.address == "London"
                              select firm;
            ConsoleMethods.Show("London Firms:", LondonFirms);
        }

        public void DirectorWithLastnameWhiteFirm()
        {
            var fir = from firm in firms
                        where firm.director.Contains("White")
                        select firm;
            ConsoleMethods.Show("A firm whose director’s surname is White:", fir);
        }
        public void LastnameAndNameFirm()
        {
            var fir = from firm in firms
                        where firm.director.Contains("Black") && firm.name.Contains("White")
                        select firm;
            ConsoleMethods.Show("A firm whose director’s surname is Black and name with White:", fir);
        }
        public void MoreThaTwoYearsFirm()
        {
            DateOnly nowDate = DateOnly.FromDateTime(DateTime.Today);
            var fir = from firm in firms
                        where nowDate.Year - firm.date.Year >= 2
                        select firm;
            ConsoleMethods.Show("Firms that were established more than two years ago:", fir);
        }
        public void More150DaysFirm()
        {
            DateOnly nowDate = DateOnly.FromDateTime(DateTime.Today);
            var fir = from firm in firms
                        where (nowDate.DayNumber - firm.date.DayNumber) >= 150
                        select firm;
            ConsoleMethods.Show("Firms that have been in existence for more than 150 days:", fir);
        }
    }
}
