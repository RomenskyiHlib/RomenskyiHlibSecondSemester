using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondLab.model
{
    public record Firm(string name, DateOnly date, Focus businessFocus, string director, int numberOfEmployees, string address);
}
