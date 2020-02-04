using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBehaviour : MonoBehaviour
{
    private Animator Turn;
    float timeCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        Turn = GetComponent<Animator>();
        //Turn.SetBool("Tüttür", false);
        timeCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Turn.SetBool("Right", true);
            //basma = true;
        }

        if (Input.GetMouseButtonUp(1))
        {
            Turn.SetBool("Right", false);
            //basma = true;
        }

        //if (basma)
        //{
        //    süre += Time.deltaTime;
        //    Debug.Log(süre);

        //    if (süre >= 10.0f)
        //    {
        //        girdi = true;
        //        sürtünme.SetBool("Tüttür", true);
        //        Debug.Log("Yanıyo Fuat ağğbi");
        //        //StartCoroutine(OyuncuyaGeç());

        //    }
        //}

        if (Input.GetMouseButtonDown(0))
        {
            Turn.SetBool("Left", true);
            //basma = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Turn.SetBool("Left", false);
            //basma = true;
        }

    }
}
