using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateSoldiers : MonoBehaviour
{
    //Internal Variables
    [SerializeField] private GameObject prSoldier;
    [SerializeField] private int nSoldiers;
    [SerializeField] private float timeToGenerate;

    //Auxiliar Variables
    private float timeToSpawn, aux;


    private void Start()
    {
        //Initialize Variables
        aux = 0;
    }

    private void Update()
    {
        //Recalculate
        timeToSpawn += Time.deltaTime;

        //Checks
        if(timeToSpawn > timeToGenerate && aux < nSoldiers) generateEnemies();
    }

    //Function to instatiate soldiers in fuction of the time and the number of enemies
    void generateEnemies()
    {
        Instantiate(prSoldier, this.transform.position, Quaternion.identity);
        timeToSpawn = 0;
        aux++;
    }


}
