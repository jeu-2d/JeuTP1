using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mechantNiv2 : MonoBehaviour
{
   public bool blesse; //valeur boolean pour quand un ennemis est blesser
   public bool attaque; //valeur boolean pour quand un ennemis attaque
   public GameObject perso; // gameobject pour cibler le personnage
   public float distance; // valeur pour trouver la distance entre l'ennemis et le personnage
   public GameObject epee; // gameobject pour cibler l'epee


    // Update is called once per frame
    void Update()
    {
        distance = Mathf.Abs(transform.position.x - perso.transform.position.x); // valeur pour trouver la distance entre l'ennemis et le personnage
        if (distance < 3f || distance < -3f) //si la distance entre l'ennemis et le personnage est plus petit que trois 
        {
            attaquer(); //appeler la fonction attaquer
        }

        if (perso.transform.position.x > transform.position.x && epee.GetComponent<CoupEpeeNiv2>().estMort == false) //si le personnage dépasse l'ennemis et la valeur estMort qui est dans le script est false
        {
            GetComponent<SpriteRenderer>().flipX = false; //flipper l'ennemis
        } else
        {
            GetComponent<SpriteRenderer>().flipX = true; 
        }

    
    }

    void attaquer() //fonction pour appeler la fonction d'attaque
    {
        if (!attaque) //si attaque est false 
        {
            attaque = true; //attaque est false
            GetComponent<Animator>().SetTrigger("attaque1"); //activer l'animation d'attaque 1
            Invoke("ArretAttaque", 0.7f); //arrêter l'animation de l'attaque après 0.7 secondes
        }
    }

    void ArretAttaque() // fonction pour arreter l'attaque
    {
        attaque = false; //attaque devient false
        GetComponent<Animator>().SetBool("attaque1", false);
    }

    void ArretBlesse() // fonction pour arreter de blesse
    {
        GetComponent<Animator>().SetBool("blesser", false);
    }


}
