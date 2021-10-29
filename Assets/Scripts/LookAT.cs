using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAT : MonoBehaviour
{
       public Transform target;

    void Update()
    {
        var objects = GameObject.FindGameObjectsWithTag("Player");
        if (objects.Length == 0)
            return;
        foreach (GameObject obj in objects)
        {
            if (obj.GetComponent<Control>().view.IsMine)
            {
                target = obj.transform;
                transform.LookAt(target);
                transform.Rotate(0, 180, 0);
            }
        }
    }

}
