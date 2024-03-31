using UnityEngine;
using TMPro;
using System.IO.Enumeration;

public class Controller : MonoBehaviour
{

    public Data data;

    [SerializeField] private TMP_Text currencyText;

    private void Start()
    {
        data = new Data();
    }

    private void Update()
    {
        currencyText.text = data.cerezas + " Cerezas";
    }

    public void GenerateCerezas()
    {
        data.cerezas += 1;
    }

    public void RemoveCerezas()
    {
        data.cerezas -= 1;
    }
}
