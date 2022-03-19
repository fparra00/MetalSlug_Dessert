using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePlataforms : MonoBehaviour
{

    private GameObject Plataform;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Plataform"))
        {
            Plataform = collision.gameObject;
            //Plataform.transform.rig
        }
    }
}
