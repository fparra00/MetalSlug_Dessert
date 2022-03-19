using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformScripts : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private bool isRigidbodyEnabled;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        //isRigidbodyEnabled = (rigidbody.) ? true : false;
        Debug.Log(rigidbody.isKinematic);
    }

    static void enableRigidbody()
    {

    }
}
