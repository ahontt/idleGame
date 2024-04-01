using System.Collections;
using System.Collections.Generic;
using BreakInfinity;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{

    public static UpgradeManager instance;

    private void Awake() => instance = this;

    public Data data;

    public Upgrades clickUpgrade;

    public string clickUpgradeName;

    public BigDouble clickUpgradeBase;
    public BigDouble clickUpgradeMult;

    public void StartUpgradeManager()
    {

        clickUpgradeName = "Cerezas Por Click";

        clickUpgradeBase = 10;
        clickUpgradeMult = 1.5;
        UpdateClickUpgradeUI();
    }

    public void UpdateClickUpgradeUI()
    {
        clickUpgrade.LevelText.text = Controller.instance.data.clickUpgradeLevel.ToString();
        clickUpgrade.CostText.text = "Cost " +  Cost().ToString(format:"F2") + " Cerezas";
        clickUpgrade.NameText.text = "+1 " + clickUpgradeName;
    }

    public BigDouble Cost()
    {
        return clickUpgradeBase * BigDouble.Pow(clickUpgradeMult, Controller.instance.data.clickUpgradeLevel);
    }

    public void BuyUpgrade()
    {
        if (Controller.instance.data.cerezas >= Cost())
        {
            Controller.instance.data.cerezas -= Cost();
            Controller.instance.data.clickUpgradeLevel += 1;
        }

        UpdateClickUpgradeUI();
    }
}
