using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public float TargetTime;
    // Start is called before the first frame update
    void Start()
    {
        TargetTime = 10;
    }

    // Update is called once per frame
    void Update()
    {
        TargetTime -= Time.deltaTime;
        GetComponent<Text>().text = "Kalan Süre: "  + TargetTime.ToString("0");

        if(TargetTime < 3)
        {
            GetComponent<Text>().color = Color.red;
        }

        else
            GetComponent<Text>().color = Color.cyan;
    }
}
