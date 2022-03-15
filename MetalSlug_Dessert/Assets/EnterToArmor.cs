using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterToArmor : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private Armor1 armor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.gameObject;
            controlArmor();
        }
    }

    private void controlArmor()
    {
        armor.enabled = true;
        Invoke("DisablePlayer", 0.17f);
    }

    private void DisablePlayer()
    {
        player.SetActive(false);
    }
}
