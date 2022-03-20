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
    public String iniciales;
    public void writeInBdd()
    {
        iniciales = GameObject.Find("InputFieldUsu").GetComponent<InputField>().text;
        String conn = "URI=file:" + Application.dataPath + "/Bdd/Mslug.db";
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "insert into MSlug(Initials) values ('"+iniciales+"')";
        dbcmd.CommandText = sqlQuery;
        int escrituras = dbcmd.ExecuteNonQuery();

        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }

    public void readInBdd()
    {
        string sqlQuery = "SELECT Initials FROM MSlug WHERE ID = (SELECT MAX(ID) FROM MSlug)";
        String conn = "URI=file:" + Application.dataPath + "/Bdd/Mslug.db";
        String initials="";
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();

        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();

        while (reader.Read())
        {
        initials = reader.GetString(1);
        }
        Debug.Log(initials);


        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;

    }
}
