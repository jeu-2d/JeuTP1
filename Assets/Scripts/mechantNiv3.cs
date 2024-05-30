using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mechantNiv3 : MonoBehaviour
{
    public bool blesse; //valeur boolean pour quand un ennemis est blesser
    public bool attaque; //valeur boolean pour quand un ennemis attaque
    public bool estMort; // //valeur boolean pour quand un ennemis est mort
    public GameObject perso;  // gameobject pour cibler le personnage
    public GameObject epee;  // gameobject pour cibler l'epee
    public float distance; // valeur pour trouver la distance entre l'ennemis et le personnage



    // Update is called once per frame
    void Update()
    {
        distance = Mathf.Abs(transform.position.x - perso.transform.position.x); // valeur pour trouver la distance entre l'ennemis et le personnage
        if (distance < 3f || distance < -3f) //si la distance entre l'ennemis et le personnage est plus petit que trois 
        {
            attaquer(); //appeler la fonction attaquer
        }

        if (perso.transform.position.x > transform.position.x && epee.GetComponent<CoupEpeeNiv3>().estMort == false) //si le personnage dépasse l'ennemis et la valeur estMort qui est dans le script est false
        {
            GetComponent<SpriteRenderer>().flipX = false; //flipper l'ennemis
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

    }

    void attaquer() //fonction pour appeler la fonction d'attaque
    {
        if (!attaque) //si attaque est false 
        {
            attaque = true; //attaque est false
            GetComponent<Animator>().SetTrigger("attaque"); //activer l'animation d'attaque 
            Invoke("ArretAttaque", 0.8f); //arrêter l'animation de l'attaque après 0.8 secondes
        }
    }

    void ArretAttaque() // fonction pour arreter l'attaque
    {
        attaque = false; //attaque devient false
        GetComponent<Animator>().SetBool("attaque", false);
    }

    void ArretBlesse() // fonction pour arreter de blesse
    {
        GetComponent<Animator>().SetBool("blesser", false);
    }


}
