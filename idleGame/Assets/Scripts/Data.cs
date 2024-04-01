using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BreakInfinity;

public class Data
{
    public BigDouble cerezas;

    public List<int> clickUpgradeLevel;


    public Data()
    {
        cerezas = 0;

        clickUpgradeLevel = new int[4].ToList();
    }

}
