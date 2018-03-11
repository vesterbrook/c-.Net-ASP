using System;
using System.Collections.Generic;

namespace human
{
    class Program
    {
        static void Main(string[] args)
        {
            Human terry = new Human("Terry");
            Human larry = new Human("Larry");
            terry.attack(larry);
        }
    }
}
