using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class ControlerPersonnage : MonoBehaviour
{
    //Yohan Jacques 10 Avril 2024

    //les variables public
    float vitesseX;      //vitesse horizontale actuelle
    public float vitesseXMax;   //vitesse horizontale Maximale désirée
    float vitesseY;      //vitesse verticale 
    public bool attaque;  // valeur pour utiliser quand le héro attaque
    public bool roulade;  // valeur pour utiliser quand le héro fait une roulade
    public bool estMort;      // valeur pour utiliser quand le hero Meurt
    public TextMeshProUGUI PointDeVie; //variables pour le texte point de vie
    public int pv = 100;// variable pour les points de vies

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // si le hero n'est pas mort...
        if (!estMort)
        {

        
        if (pv <= 0)//si les pv du hero sont plus ou egal a zero mort devient true
        {
            estMort = true; //est mort devient true
        }


        // déplacement vers la gauche
        if (Input.GetKey("a"))
        {
            vitesseX = -vitesseXMax;
            transform.localScale = new Vector3(-1, 1, 1); //déplacement le collider bout

        }
        else if (Input.GetKey("d"))   //déplacement vers la droite
        {
            vitesseX = vitesseXMax;
            transform.localScale = new Vector3(1, 1, 1);//déplacement le collider bout


            }
        else
        {
            vitesseX = GetComponent<Rigidbody2D>().velocity.x;  //mémorise vitesse actuelle en X
        }

        if (Input.GetKeyDown(KeyCode.J) && !attaque) //si le joueur appuie sur espace
        {
            attaque = true; //la valeur d'attaque devient true
            Invoke("ArretAttaque", 0.4f); //arrêter l'animation de l'attaque après 0.4 secondes
            GetComponent<Animator>().SetTrigger("attaque"); //activer l'animation d'attaque
            GetComponent<Animator>().SetBool("roulade", false); //l'animation de saut est faux
        }

        if (Input.GetKeyDown(KeyCode.Space) && !roulade) //si le joueur appuie sur espace
        {
            roulade = true; //la valeur d'attaque devient true
            Invoke("ArretRoulade", 0.4f); //arrêter l'animation de l'attaque après 0.4 secondes
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Animator>().SetBool("roulade", true); //activer l'animation de roulade
        }
        if (roulade && Mathf.Abs(vitesseX) <= vitesseXMax) //pour ne pas dépasser une certaine limites de vitesse
        {
            vitesseX *= 4f; //augmenter la vitesse
        }

        //Applique les vitesses en X et Y
        GetComponent<Rigidbody2D>().velocity = new Vector2(vitesseX, vitesseY);

        if (vitesseX > 0.01f || vitesseX < -0.1f)
        {
            GetComponent<Animator>().SetBool("cours", true);//activer l'animation de course
           
        }
        else
        {
            GetComponent<Animator>().SetBool("cours", false); //désactiver l'animation de course
           
        }
    }

    }

    void OnCollisionEnter2D(Collision2D Collision)
    {

        if (Collision.gameObject.name == "MonstreVolant" && !attaque) //si il y a une collision entre le monstre et attaque est false
        {

            GetComponent<Animator>().SetTrigger("blesse");//activer l'animation de mort
            pv -= 15; // le hero perd 15 points de vie
            PointDeVie.text = pv.ToString();

        }

        if (Collision.gameObject.name == "MonstreVolant" && estMort) // si il y une collision entre le monstre et est mort est true
        {
            gameObject.GetComponent<Collider2D>().enabled = false;//enlever le collider
            pv = 0;
            GetComponent<Animator>().SetTrigger("mort");//activer l'animation de mort
            Invoke("RelancerJeu", 5f); //relancer la scene de jeu après 5 secondes
        }

        if (Collision.gameObject.name == "Finjeu") //si il y a une collision avec le game object fin de jeu on relance le jeu immediatement
        {
            Invoke("RelancerJeu", 0f);
        }
    }

void ArretAttaque() // fonction pour arreter l'attaque
    {
        attaque = false; //attaque devient false
    }

   void ArretRoulade() //fonction pour arreter la roulade
    {
        roulade = false; //roulade devient false 
        GetComponent<Collider2D>().enabled = true; // reactiver le collider
        GetComponent<Animator>().SetBool("roulade", false); //désactiver l'animation de roulade
    }

    void RelancerJeu() //fonction pour relancer la scene
    {
        SceneManager.LoadScene("SceneDeJeu");
    }
}
