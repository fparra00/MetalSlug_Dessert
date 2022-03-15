using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bloodScr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("destroyBlood", 0.8f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void destroyBlood()
    {
        Destroy(gameObject);
    }
}
