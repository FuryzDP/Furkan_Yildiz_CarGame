using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanSceen : MonoBehaviour
{
    public GameObject BeforeLv;
    public GameObject teeth, teeth2;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Clean());
    }

    IEnumerator Clean()
    {
        yield return new WaitForSeconds(1.5f);
        GameObject[] cars = GameObject.FindGameObjectsWithTag("DeadCar");
        GameObject[] cars2 = GameObject.FindGameObjectsWithTag("Car");
        teeth.SetActive(false);
        teeth2.SetActive(false);

        foreach (GameObject car in cars)
            GameObject.Destroy(car);

        foreach (GameObject car2 in cars2)
            GameObject.Destroy(car2);

        yield return new WaitForSeconds(2.3f);
        BeforeLv.SetActive(false);
    }
}
