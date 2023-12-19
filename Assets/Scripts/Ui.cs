using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ui : MonoBehaviour
{
    public float moneyValue;
    public TextMeshProUGUI moneyCounter;
    // Start is called before the first frame update
    void Start()
    {
    moneyCounter.text = moneyValue.ToString();      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
