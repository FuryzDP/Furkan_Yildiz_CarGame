using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class AnimationRecorder : MonoBehaviour
{
    public AnimationClip clip;

    private GameObjectRecorder m_Recorder;
    private GameObjectRecorder emptyRecorder;
    public GameObject empty_Object;

    void Start()
    {

        m_Recorder = new GameObjectRecorder(gameObject); //kayıtçı oluşturuyoruz

        m_Recorder.BindComponentsOfType<Transform>(gameObject, true);//hareketlerini kaydedeceğimiz objeyi çocukları ile birlikte alıyoruz

        emptyRecorder = new GameObjectRecorder(empty_Object);//aynısını oyun sonlandığında takipçi aracımızın sahne dışında görünmesi için boş bir nesne için yapıyoruz
        emptyRecorder.BindComponentsOfType<Transform>(empty_Object, true);

    }

    void LateUpdate()
    {
        if (clip == null)
            return;

        m_Recorder.TakeSnapshot(Time.deltaTime); //her frameyi kayıt altına alıyoruz

        emptyRecorder.TakeSnapshot(Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "finish")
        {
            if (clip == null)
                return;

            if (m_Recorder.isRecording)
            {
                m_Recorder.SaveToClip(clip); //tüm frameleri kayıt ediyoruz
             
            }

        }
    }

    void OnDisable()
    {
        if (clip == null)
            return;

        if (emptyRecorder.isRecording)
        {
            emptyRecorder.SaveToClip(clip); //oyun sonlandığında aracı sahne dışına alıyoruz
        }
    }
}
