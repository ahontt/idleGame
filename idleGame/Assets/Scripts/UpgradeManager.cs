using System.Collections;
using System.Collections.Generic;
using BreakInfinity;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public Controller controller;
    public Data data;

    public Upgrades clickUpgrade;

    public string clickUpgradeName;

    public BigDouble clickUpgradeBase;
    public BigDouble clickUpgradeMult;

    public void StartUpgradeManager()
    {
        data = controller.data;

        clickUpgradeName = "Cerezas Por Click";

        clickUpgradeBase = 10;
        clickUpgradeMult = 1.5;
        UpdateClickUpgradeUI();
    }

    public void UpdateClickUpgradeUI()
    {
        clickUpgrade.LevelText.text = controller.data.clickUpgradeLevel.ToString();
        clickUpgrade.CostText.text = "Cost " +  Cost().ToString(format:"F2") + " Cerezas";
        clickUpgrade.NameText.text = "+1 " + clickUpgradeName;
    }

    public BigDouble Cost()
    {
        return clickUpgradeBase * BigDouble.Pow(clickUpgradeMult, data.clickUpgradeLevel);
    }

    public void BuyUpgrade()
    {
        if (controller.data.cerezas >= Cost())
        {
            controller.data.cerezas -= Cost();
            controller.data.clickUpgradeLevel += 1;
        }

        UpdateClickUpgradeUI();
    }
}
