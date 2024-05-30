using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoupEpeeNiv3 : MonoBehaviour
{
    public AudioClip SonMort; //son de mort
    public GameObject leBoss; //gameobject pour cibler le boss
    public GameObject pA1; //point d'attaque 1
    public GameObject pA2; //point d'attaque 2
    public GameObject pA3; //point d'attaque 3
    public int nombreAttaque; //valeur pour calculer le nombre d'attaque
    public bool superAttaquePret; //valeur pour savoir que la super attaque est pret
    public AudioClip SonBlesse; //son de blesser
    public GameObject Perso; // gameobject pour cibler le personnage
    public bool estMort; //valeur boolean pour quand un ennemis est mort


    void OnCollisionEnter2D(Collision2D InfoCollision)
    {
        if (InfoCollision.gameObject.tag == "mechantNiv3") //si il y une collision entre l'epee et le monstre...
        {
            nombreAttaque++; //le nombre d'attaque augmente
            if (nombreAttaque == 1) //si le nombre d'attaque est égal à 1
            {
                pA1.SetActive(true);  //point d'attaque 1 est activer
            }
            else if (nombreAttaque == 2) //si le nombre d'attaque est égal à 2
            {
                pA2.SetActive(true); //point d'attaque 2 est activer
            }
            else if (nombreAttaque == 3) //point d'attaque 3 est activer
            {
                pA3.SetActive(true);  //point d'attaque 3 est activer
                superAttaquePret = true;// la super attaque devient prêt à être utilisé
            }

        }

        {

            if (InfoCollision.gameObject.name == "Squelette") //si il y a une collision entre le monstre et attaque est false 
            {
                if (InfoCollision.gameObject.GetComponent<mechantNiv3>().blesse == false) // si le monstre n'est pas blesser..
                {
                    InfoCollision.gameObject.GetComponent<Animator>().SetTrigger("blesser");//activer l'animation de mort
                    InfoCollision.gameObject.GetComponent<mechantNiv3>().Invoke("ArretBlesse", 0.5f);
                    GetComponent<AudioSource>().PlayOneShot(SonBlesse, 1f);//jouer le son de la mort
                    InfoCollision.gameObject.GetComponent<mechantNiv3>().blesse = true;
                }
                else
                {
                    estMort = true;
                    InfoCollision.gameObject.GetComponent<Collider2D>().enabled = false;//enlever le collider
                    InfoCollision.gameObject.GetComponent<Animator>().SetTrigger("mort");//activer l'animation de mort
                    InfoCollision.gameObject.GetComponent<Animator>().SetBool("attaque", false);
                    GetComponent<AudioSource>().PlayOneShot(SonMort, 1f);//jouer le son de la mort
                    Destroy(InfoCollision.gameObject, 1f); //le gameObject mechant est detruit apres l'animation
                }

                if (InfoCollision.gameObject.name == "Squelette" && Perso.GetComponent<ControlerPersonnageNiv3>().superAttaque == true)
                {
                   /* InfoCollision.gameObject.GetComponent<Rigidbody2D>().velocityX = -20f;*/
                    InfoCollision.gameObject.gameObject.GetComponent<Collider2D>().enabled = false;//enlever le collider
                    InfoCollision.gameObject.GetComponent<Animator>().SetTrigger("mort");//activer l'animation de mort
                    InfoCollision.gameObject.GetComponent<Animator>().SetBool("attaque", false);
                    GetComponent<AudioSource>().PlayOneShot(SonMort, 1f);//jouer le son de la mort
                    Destroy(InfoCollision.gameObject, 1f); //le gameObject mechant est detruit apres l'animation
                }
            }
        }


        /*
                {
                    Collision.gameObject.GetComponent<Animator>().SetTrigger("blesse"); //activer l'animation de mort du monstre
                    GetComponent<AudioSource>().PlayOneShot(SonMort, 1f);//jouer le son de la mort
                    Collision.gameObject.GetComponent<Collider2D>().enabled = false; //desactiver le collider
                    Destroy(Collision.gameObject, 1f); //le gameObject mechant est detruit apres l'animation
                }

        */
        if (InfoCollision.gameObject.name == "Boss" /*&&leBoss.GetComponent<BossNiv3>().attaque1 == false && leBoss.GetComponent<BossNiv3>().attaque2 == false*/) //si il y a une collision entre le monstre et attaque est false
        {
            InfoCollision.gameObject.GetComponent<Animator>().SetTrigger("blesser");  //activer l'animation de blesser du monstre
            leBoss.GetComponent<BossNiv3>().Invoke("ArretBlesse", 0.4f); //invoquer la fonction arret blesser qui est dans le script BossNiv1 après 0.4 secondes
            leBoss.GetComponent<VieDommageNiv3>().prendreDommage(20); //la valeur de vie qui est dans le script VieDommage perd 60
        }

        if (InfoCollision.gameObject.name == "Boss" && Perso.GetComponent<ControlerPersonnageNiv3>().superAttaque == true) //si il y a une collision entre le monstre et super attaque est activer
        {
            InfoCollision.gameObject.GetComponent<Animator>().SetTrigger("blesser");
            leBoss.GetComponent<BossNiv3>().Invoke("ArretBlesse", 0.4f); //invoquer la fonction arret blesser qui est dans le script BossNiv1 après 0.4 secondes
            leBoss.GetComponent<VieDommageNiv3>().prendreDommage(60); //la valeur de vie qui est dans le script VieDommage perd 60
        }

    }
}
