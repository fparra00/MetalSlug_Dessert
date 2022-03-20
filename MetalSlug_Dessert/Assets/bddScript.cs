using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class bddScript : MonoBehaviour
{
    public void writeInBdd()
    {
        
        String conn = "URI=file:" + Application.dataPath + "/Bdd/MSlug.db";
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();
        IDbCommand dbcmd = dbconn.CreateCommand();

        string sqlQuery = "insert into MSlug values ('POR')";
        dbcmd.CommandText = sqlQuery;
        int escrituras = dbcmd.ExecuteNonQuery();

        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }

    public void readInBdd()
    {
    }
}
