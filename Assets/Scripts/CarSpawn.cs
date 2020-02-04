using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawn : MonoBehaviour
{
    public GameObject car;
    private Vector3 pos;
    bool control;
    // Start is called before the first frame update
    void Start()
    {
        control = false;
        //Born();
    }

    private void Update()
    {
        var ey = GameObject.Find("AudiRR8");
        if(ey == false && control == false) //eğer ortamda hiçbir araç yoksa bu yeni bir Levelin Başlangıcı demektir
        {
            Born();
            control = true;
        }
    }

    void Born()
    {
        pos = transform.position;
        Instantiate(car, new Vector3(transform.position.x, transform.position.y, transform.position.z),
            Quaternion.Euler(transform.localRotation.x, transform.localEulerAngles.y, transform.localRotation.z));
    }
}
