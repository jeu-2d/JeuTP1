using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoupEpee : MonoBehaviour
{
    public AudioClip SonMort; //son de mort
    public GameObject leBoss; //gameobject pour cibler le boss



    void OnCollisionEnter2D(Collision2D Collision)
    {
        if (Collision.gameObject.name == "MonstreVolant") //si il y une collision entre l'epee et le monstre...

        {
            Collision.gameObject.GetComponent<Animator>().SetTrigger("contact"); //activer l'animation de mort du monstre
            GetComponent<AudioSource>().PlayOneShot(SonMort, 1f);//jouer le son de la mort
            Collision.gameObject.GetComponent<Collider2D>().enabled = false; //desactiver le collider
            Destroy(Collision.gameObject, 1f); //le gameObject mechant est detruit apres l'animation
        }

        if (Collision.gameObject.name == "MonstreVolantDeplacement")  //si il y une collision entre l'epee et l'animation du monstre...

        {
            Collision.gameObject.GetComponent<Animator>().enabled = false; //desactiver l'animation gauche droite du monstre
            Collision.gameObject.GetComponent<Collider2D>().enabled = false; // desactiver le collider du monstre
        }

        if (Collision.gameObject.name == "Boss" ) //si il y a une collision entre le boss
        {
            Collision.gameObject.GetComponent<Animator>().SetBool("blesser",true); //activer l'animation de blesser du monstre
            leBoss.GetComponent<BossNiv1>().Invoke("ArretBlesse", 0.4f); //invoquer la fonction arret blesser qui est dans le script BossNiv1 après 0.4 secondes
            leBoss.GetComponent<VieDommage>().prendreDommage(20); //la valeur de vie qui est dans le script VieDommage perd 20 
        }

    }


}
