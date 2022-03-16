using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAtack : MonoBehaviour
{
    [SerializeField] private Transform positionKnife;
    [SerializeField] private float radiusKnife;
    [SerializeField] private float damage;


    void Update()
    {
        if (LogicalMarco.isRazing) attack();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(positionKnife.position, radiusKnife);
    }
    private void attack()
    {
        Collider2D[] collisions = Physics2D.OverlapCircleAll(positionKnife.position, radiusKnife);

        foreach (Collider2D collision in collisions)
        {
            if (collision.CompareTag("Soldier"))
            {
                collision.gameObject.GetComponent<SoldiersGeneral>().hitWithKnife = true;

            }
        }
    }
}
