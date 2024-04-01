using UnityEngine;
using TMPro;
using BreakInfinity;
using System.Net.NetworkInformation;

public class Controller : MonoBehaviour
{

    public static Controller instance;

    private void Awake() => instance = this;

    public Data data;

    [SerializeField] private TMP_Text currencyText;
    [SerializeField] private TMP_Text clickPowerText;

    public BigDouble clickPower() => 1 + data.clickUpgradeLevel;

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

    public void GenerateCerezas()
    {
        data.cerezas += clickPower();
    }

    public void RemoveCerezas()
    {
        data.cerezas -= 1;
    }
}
