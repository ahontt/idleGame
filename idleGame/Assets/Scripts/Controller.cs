using UnityEngine;
using TMPro;
using System.IO.Enumeration;
using BreakInfinity;

public class Controller : MonoBehaviour
{

    public Data data;
    public UpgradeManager upgradeManager;

    [SerializeField] private TMP_Text currencyText;
    [SerializeField] private TMP_Text clickPowerText;

    public BigDouble clickPower() => 1 + data.clickUpgradeLevel;

    public void Start()
    {
        data = new Data();
        upgradeManager.StartUpgradeManager();
    }

    public void Update()
    {
        currencyText.text = data.cerezas + " Cerezas";
        clickPowerText.text = "+" + clickPower() + " Cerezas";
    }

    public void GenerateCerezas()
    {
        data.cerezas += clickPower();
    }

    public void RemoveCerezas()
    {
        data.cerezas -= 1;
    }
}
