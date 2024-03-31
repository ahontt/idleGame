using UnityEngine;
using TMPro;

public class Controller : MonoBehaviour
{

    public Data data;

    public TMP_Text currencyText;

    public void Start()
    {
        data = new Data();
    }

    public void Update()
    {
        currencyText.text = data.cerezas + " Cerezas";
    }

    public void GenerateCerezas()
    {
        data.cerezas += 1;
    }
}
