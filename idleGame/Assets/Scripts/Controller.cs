using UnityEngine;
using TMPro;
using System.IO.Enumeration;
using BreakInfinity;
using System.Net.NetworkInformation;

public class Controller : MonoBehaviour
{

    public static Controller instance;

    private void Awake() => instance = this;

    public Data data;

    [SerializeField] private TMP_Text currencyText;
    [SerializeField] private TMP_Text clickPowerText;

    public BigDouble clickPower()
    {
        BigDouble total = 0;
        for (int i = 0; i < data.clickUpgradeLevel.Count; i++)
        {
            total += UpgradeManager.instance.clickUpgradeBasePower[i] * data.clickUpgradeLevel[i];
        }
        
        return total;
    } 

    public void Start()
    {
        data = new Data();
        UpgradeManager.instance.StartUpgradeManager();
    }

    public void Update()
    {
        currencyText.text = data.cerezas + " Cerezas";
        clickPowerText.text = "+" + clickPower() + " Cerezas";
    }

    public void GenerateCerezas() => data.cerezas += clickPower();
}
