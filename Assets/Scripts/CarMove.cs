using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarMove : MonoBehaviour
{
    private float hiz;
    private Vector3 thisPos;
    private Quaternion thisRot;
    public GameObject PatinageLeft, PatinageRight;
    private float driftTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        var refTime = GameObject.Find("TimeTex");
        thisPos = this.gameObject.transform.position;
        thisRot = this.gameObject.transform.rotation;
       
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        hiz = 70f;
        var driftbar = GameObject.Find("DriftBar");
        var healthbar = GameObject.Find("HealthBar");
        var isTimeOver = GameObject.Find("TimeText");

        if (isTimeOver.GetComponent<timer>().TargetTime <= 1)
        {
            Ronesans();
            isTimeOver.GetComponent<timer>().TargetTime = 10;        
        }

        if (this.gameObject.tag == "DeadCar" || this.gameObject.tag == "PassiveCar")
        {
            hiz = 0;
            this.gameObject.GetComponentInChildren<Animator>().enabled = false;
        }
        else
        {
            RunRabbitRun();

            if (Input.GetMouseButton(1))
            {
                PatinageRight.SetActive(true);
                transform.Rotate(Vector3.up * Time.deltaTime * 200);
                driftTime = driftTime + Time.deltaTime;

                if (driftTime > 0.4f)
                {
                    var ey = driftbar.GetComponent<Slider>().value;
                    ey += driftTime * Time.deltaTime * 100;
                    driftbar.GetComponent<Slider>().value = ey;
                }
            }

            if (Input.GetMouseButton(0))
            {
                PatinageLeft.SetActive(true);
                transform.Rotate(Vector3.down * Time.deltaTime * 200);
                driftTime = driftTime + Time.deltaTime;

                if (driftTime > 0.4f)
                {
                    var ey = driftbar.GetComponent<Slider>().value;
                    ey += driftTime * Time.deltaTime * 100;
                    driftbar.GetComponent<Slider>().value = ey;

                }
            }

            if (driftbar.GetComponent<Slider>().value == 100)
            {
                healthbar = GameObject.Find("HealthBar");

                var eyy = healthbar.GetComponent<Slider>().value;
                eyy += 50f;
                healthbar.GetComponent<Slider>().value = eyy;

                driftbar.GetComponent<Slider>().value = 0;

            }

            if(healthbar.GetComponent<Slider>().value == 0)
            {
                Application.LoadLevel(Application.loadedLevel);
            }

            if (Input.GetMouseButtonUp(1) || Input.GetMouseButtonUp(0))
            {

                PatinageRight.SetActive(false);
                PatinageLeft.SetActive(false);
                driftTime = 0;
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "finish")
        {
            TargetClean(other.gameObject);

            var healthbar = GameObject.Find("HealthBar");

            var eyy = healthbar.GetComponent<Slider>().value;
            eyy += 25f;
            healthbar.GetComponent<Slider>().value = eyy;


        }

        if(other.tag == "enemy")
        {
            Ups();
            Ronesans();
        }

        if (other.tag == "thx")
        {
            var text = GameObject.Find("Thx");
            var changeA = text.GetComponent<Text>();
            changeA.color = new Color(0.1960784f, 0.1960784f, 0.1960784f, 1f);
            TargetClean(other.gameObject);
          
        }
    }

    private void RunRabbitRun()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * hiz);
    }

    private void Ups()
    {
        var healthbar = GameObject.Find("HealthBar");

        var ey = healthbar.GetComponent<Slider>().value;
        ey -= 8f;
        healthbar.GetComponent<Slider>().value = ey;

        var driftbar = GameObject.Find("DriftBar");
        var eyy = driftbar.GetComponent<Slider>().value;
        eyy -= 8f;
        driftbar.GetComponent<Slider>().value = eyy;
    }

    private void Ronesans()
    {
        this.gameObject.transform.position = thisPos;
        this.gameObject.transform.rotation = thisRot;
    }

    void TargetClean(GameObject other)
    {
        this.gameObject.tag = "PassiveCar";
        other.GetComponent<BoxCollider>().enabled = false;
        this.GetComponent<BoxCollider>().enabled = false;
        var TargetPlane = GameObject.Find("Plane1");
        var Light = GameObject.Find("Point Light (2)");
        Light.SetActive(false);
        TargetPlane.SetActive(false);
        GetComponent<CarMove>().enabled = false;
        GetComponentInChildren<TurnBehaviour>().enabled = false;
    }
}
