using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCar : MonoBehaviour
{
    public GameObject[] Cars = new GameObject[3];
    int i = 0;
    public GameObject timerr;

    // Start is called before the first frame update
    void Start()
    {
        Cars[i].SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {

        var hold = GameObject.FindWithTag("PassiveCar"); 

        if (hold) //Eğer ortamda yeni bir pasif tagına sahip araç varsa bir sonraki araç spawnı aktif et
        {
            timerr.GetComponent<timer>().TargetTime = 10;
            i = i + 1;
            Cars[i].SetActive(true);
            hold.tag = "DeadCar";
        }
    }
}
