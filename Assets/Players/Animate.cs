using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Animate : MonoBehaviour
{
    public Animator anim;
    public AudioSource audioData;
    private Vector3 position;
    private Vector3 precposition = new Vector3(0f, 0f, 0f);
    private float t;
    private float t2;
    private float h;
    bool stop = false;
    void Update()
    {

        position = transform.position;
        t2 = Time.time;
        if (t2 - t > 0.1)
        {
            h = (precposition.x - position.x) * (precposition.x - position.x) + (precposition.z - position.z) * (precposition.z - position.z);
            precposition = position;
            t = Time.time;
        }

        if (h == 0)
        {
            audioData.Stop();
            anim.SetFloat("vertical", 0);
            stop = true;
        }
        if (stop && h != 0)
        {
            audioData.Play();
            anim.SetFloat("vertical", 1);
            stop = false;
        }
    }
}