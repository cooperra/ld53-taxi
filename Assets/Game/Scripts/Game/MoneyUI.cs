using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyUI : MonoBehaviour
{
    public TMP_Text TextComponent;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.MoneyChanged += (money) => { TextComponent.text = "$" + money.ToString(); };
        TextComponent.text = "$" + GameManager.instance.Money.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
