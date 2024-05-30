using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scriptintro : MonoBehaviour
{
    public GameObject touche; // gameobject pour cibler l'image des touches
    public GameObject menu; // gameobject pour cibler l'image du menu
    public bool menuJeu; //valeur boolean pour l'image du menu
    public GameObject commencer; // gameobject pour cibler le texte pour commencer

    // Start is called before the first frame update
    void Start()
    {
        menuJeu = true; //au début le menu est true
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && menuJeu == true) //si le joueur appuie sur espace 
        {
            Invoke("LancerLeJeu", 0f); // le jeu se lance
        }
         
        if (Input.GetKeyDown(KeyCode.Q))  //si le joueur appuie sur q
        {
            touche.SetActive(false); //l'image touche est désactiver
            menu.SetActive(true); //l'image menu est activer
            menuJeu = true; // la valeur est true 
            commencer.SetActive(true); //le texte est activer 
        }

        if (Input.GetKeyDown(KeyCode.E)) //si le joueur appuie sur e 
        {
            touche.SetActive(true); //l'image touche est activer
            menu.SetActive(false);  //l'image menu est désactiver
            menuJeu = false; // la valeur est false
            commencer.SetActive(false); //le texte est désactiver 

        }
    }

    void LancerLeJeu() //fonction pour lancer le premier niveau
    {

        SceneManager.LoadScene("Niveau1");
    }
}
