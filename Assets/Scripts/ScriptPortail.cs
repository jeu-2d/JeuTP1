using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPortail : MonoBehaviour
{
    public GameObject Portail; // gameobject pour cibler le portail


    private void OnTriggerEnter2D(Collider2D InfoCollision)
    {
        if (InfoCollision.gameObject.name == "Hero") //si le hero rentre dans la zone le portail s'active
        {
            Portail.SetActive(true); 
        }
    }
}
