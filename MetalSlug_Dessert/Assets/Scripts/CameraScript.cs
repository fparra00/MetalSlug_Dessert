using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public GameObject Marco;
    public float smooth;
    private Vector3 vel;
    private float ejeYcam;
    private Vector3 target;

    void Start()
    {
        ejeYcam = transform.position.y;
    }

    void Update()
    {
        if (Marco != null)
        {
            if (Marco.transform.position.x > ejeYcam)
            {
                target = new Vector3(Marco.transform.position.x, -0.49f, -10.0f);
                transform.position = Vector3.SmoothDamp(transform.position, target, ref vel, smooth);
            }
        }
    }
}
