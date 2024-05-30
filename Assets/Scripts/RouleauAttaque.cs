using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouleauAttaque : MonoBehaviour
{
    public GameObject instructionAttaque; // gameobject pour cibler l'instruction dans le canvas


    void OnCollisionEnter2D(Collision2D InfoCollision)
    {

        if (InfoCollision.gameObject.name == "Hero" ) //si il une collision entre le hero
        {
            instructionAttaque.SetActive(true); //activer l'instruction
            Destroy(gameObject, 0f); //d�truire le rouleau 
            Destroy(instructionAttaque, 10f); //d�truire le l'instruction apr�s 10 secondes
        }

    }
    }
