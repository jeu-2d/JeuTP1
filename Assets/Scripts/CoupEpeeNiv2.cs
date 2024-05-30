using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoupEpeeNiv2 : MonoBehaviour
{
    public AudioClip SonMort; //son de mort
    public GameObject leBoss; //gameobject pour cibler le boss
    public GameObject pA1; //point d'attaque 1
    public GameObject pA2; //point d'attaque 2
    public GameObject pA3; //point d'attaque 3
    public AudioClip SonBlesse; //son de blesser
    public bool estMort;  //valeur boolean pour quand un ennemis est mort



    void OnCollisionEnter2D(Collision2D InfoCollision)
    {

        {

            if (InfoCollision.gameObject.name == "Goblin") //si il y a une collision entre le monstre 
            {
                if (InfoCollision.gameObject.GetComponent<mechantNiv2>().blesse == false) // si le monstre n'est pas blesser..
                {
                    InfoCollision.gameObject.GetComponent<Animator>().SetTrigger("blesser");//activer l'animation de mort
                    InfoCollision.gameObject.GetComponent<mechantNiv2>().Invoke("ArretBlesse", 0.5f);
                    GetComponent<AudioSource>().PlayOneShot(SonBlesse, 1f);//jouer le son de la mort
                    InfoCollision.gameObject.GetComponent<mechantNiv2>().blesse = true; //la valeur blesser qui est dans le script mechantNiv2 devient true
                }
                else
                {
                    estMort = true; // la valeur est mort devient true 
                    InfoCollision.gameObject.gameObject.GetComponent<Collider2D>().enabled = false;//enlever le collider
                    InfoCollision.gameObject.GetComponent<Animator>().SetTrigger("mort");//activer l'animation de mort
                    InfoCollision.gameObject.GetComponent<Animator>().SetBool("attaque1", false); //désactiver l'animation d'attaque
                    InfoCollision.gameObject.GetComponent<Animator>().SetBool("attaque2", false); //désactiver l'animation d'attaque
                    GetComponent<AudioSource>().PlayOneShot(SonMort, 1f);//jouer le son de la mort
                    Destroy(InfoCollision.gameObject, 1f); //le gameObject mechant est detruit apres l'animation
                }
            }
        }
        
        if (InfoCollision.gameObject.name == "Boss") //si il y a une collision entre le boss
         {
             InfoCollision.gameObject.GetComponent<Animator>().SetTrigger("blesser");  //activer l'animation de blesser du monstre
            leBoss.GetComponent<BossNiv2>().Invoke("ArretBlesse", 0.4f); //invoquer la fonction arret blesser qui est dans le script BossNiv1 après 0.4 secondes
            leBoss.GetComponent<VieDommageNiv2>().prendreDommage(20); //la valeur de vie qui est dans le script VieDommage perd 20 
        }

    }
}
