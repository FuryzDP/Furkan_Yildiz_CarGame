using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LvControl : MonoBehaviour
{
    public GameObject CarSpawner, timer;
    // Start is called before the first frame update
    void Start()
    {
        CarSpawner.SetActive(false);
        timer.SetActive(false);
        var healthbar = GameObject.Find("HealthBar");
        healthbar.GetComponent<Slider>().value = 100;
        var driftbar = GameObject.Find("DriftBar");
        driftbar.GetComponent<Slider>().value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            CarSpawner.SetActive(true);
            timer.SetActive(true);
        }
    }
}
