using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateSol : MonoBehaviour
{

    [SerializeField] private GameObject sol1;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("e");
            sol1.SetActive(true);
        }
    }

    
}
