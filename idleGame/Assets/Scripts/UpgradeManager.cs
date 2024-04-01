using System.Collections;
using System.Collections.Generic;
using BreakInfinity;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{

    public static UpgradeManager instance;

    private void Awake() => instance = this;

    public Data data;

    public List<Upgrades> clickUpgrades;
    public Upgrades clickUpgradePrefab;

    public ScrollRect clickUpgradesScroll;
    public GameObject clickUpgradesPanel;

    public string[] clickUpgradeNames;

    public BigDouble[] clickUpgradeBase;
    public BigDouble[] clickUpgradeMult;
    public BigDouble[] clickUpgradeBasePower;

    public void StartUpgradeManager()
    {
        clickUpgradeNames = new []{"Click Power +1", "Click Power +5", "Click Power +10"};
        clickUpgradeBase = new BigDouble[]{10, 50, 100};
        clickUpgradeBasePower = new BigDouble[]{1.25, 1.35, 1.55};
        clickUpgradeBasePower = new BigDouble[]{1, 5, 10};

        for (int i = 0; i < Controller.instance.data.clickUpgradeLevel.Count;)
        {
            Upgrades upgrade = Instantiate(clickUpgradePrefab, clickUpgradesPanel.transform);
            upgrade.UpgradeID = i;
            clickUpgrades.Add(upgrade);
        }
        clickUpgradesScroll.normalizedPosition = new Vector2(0,0);
        UpdateClickUpgradeUI();
    }

    public void UpdateClickUpgradeUI(int UpgradeID = -1)
    {
        if (UpgradeID == -1)
            for (int i = 0; i < clickUpgrades.Count; i++) UpdateUI(i);
        else UpdateUI(UpgradeID);

        void UpdateUI(int ID)
        {
                clickUpgrades[ID].LevelText.text = Controller.instance.data.clickUpgradeLevel[ID].ToString();
                clickUpgrades[ID].CostText.text = $"Cost {ClickUpgradeCost(ID).ToString(format:"F2")} Cerezas";
                clickUpgrades[ID].NameText.text = "+1 " + clickUpgradeNames[ID];
        }
    }

    public BigDouble ClickUpgradeCost(int UpgradeID) => clickUpgradeBase[UpgradeID] * BigDouble.Pow(clickUpgradeMult[UpgradeID], Controller.instance.data.clickUpgradeLevel[UpgradeID]);

    public void BuyUpgrade(int UpgradeID)
    {
        if (Controller.instance.data.cerezas >= ClickUpgradeCost(UpgradeID))
        {
            Controller.instance.data.cerezas -= ClickUpgradeCost(UpgradeID);
            Controller.instance.data.clickUpgradeLevel[UpgradeID] += 1;
        }

        UpdateClickUpgradeUI(UpgradeID);
    }
}
