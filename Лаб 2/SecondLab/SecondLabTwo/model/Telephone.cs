using System;
using System.Collections.Generic;
using System.Text;

namespace SecondLabTwo.model
{
    public record Telephone(string name, string manufacturer, decimal price, DateOnly data);
}
