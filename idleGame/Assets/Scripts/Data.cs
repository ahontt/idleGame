using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BreakInfinity;

public class Data
{
    public BigDouble cerezas;

    public List<BigDouble> clickUpgradeLevel;


    public Data()
    {
        cerezas = 0;

        clickUpgradeLevel = Methods.CreateList<BigDouble>(capacity: 3);
    }

}
