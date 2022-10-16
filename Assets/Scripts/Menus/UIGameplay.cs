using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIGameplay : MonoBehaviour
{
    public TextMeshProUGUI fireExtinguishAmount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fireExtinguishAmount.text = GameManager.instance.firesPutOut.ToString();
    }
}
