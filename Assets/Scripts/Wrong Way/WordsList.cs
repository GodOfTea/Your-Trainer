using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordsList : MonoBehaviour
{
    private string[] Directions =
    {
        "up",
        "down",
        "left",
        "right",
        "not up",
        "not down",
        "not left",
        "not right"
    };

    public string ChouseDirection ()
    {
        int val = Random.Range(0, Directions.Length);
        return Directions[val];
    }
	
}
