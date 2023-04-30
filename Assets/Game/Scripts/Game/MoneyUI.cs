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
        float money = 10;

        GameManager.instance.MoneyChanged += (money) => { TextComponent.text = "$" + money.ToString(); };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
