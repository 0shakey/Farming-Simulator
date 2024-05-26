using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCode : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Oncollisionenter");
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Ontriggerenter");
    }
}
