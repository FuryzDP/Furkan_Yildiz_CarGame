using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushScp : MonoBehaviour
{
    private Animator Crush;
    public GameObject Map;
    public GameObject Lv2;
    public GameObject DecorBuild;

    // Start is called before the first frame update
    void Start()
    {
        Crush = GetComponent<Animator>();
        DecorBuild.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Car")
        {         
            Crush.SetBool("Crush", true);
            Map.GetComponent<Animator>().SetBool("Change", true);
        }

        if(Map.GetComponent<Animator>().GetBool("Change"))
        {
            Lv2.SetActive(true);
        }
    }
}
