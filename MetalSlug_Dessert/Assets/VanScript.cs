using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanScript : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * (Time.deltaTime * 2f));

    }
}
