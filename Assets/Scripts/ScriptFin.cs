using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptFin : MonoBehaviour
{
    public float yMax; // valeur maximum de y du texte


    // Update is called once per frame
    void Update()
    {
        

        if (transform.position.y > yMax) //si le y du texte est plus grand que le y maximum l'intro se lance
        {
            Invoke("RetourMenu",5f);
        }
    }

    void RetourMenu()
    {
        SceneManager.LoadScene("IntroDeJeu");
    }
}
