using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossNiv1 : MonoBehaviour
{
    public bool attaque1; //valeur boolean pour attaque1
    public bool attaque2; //valeur boolean pour attaque2
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ChoixAttaque", 0f, 3f); //répéter la fonction d'attaque après 0 secondes et 3 secondes d'interval
    }

    // la fonction pour que le boss attaque
    void ChoixAttaque()  
    {
        int etatBoss = Random.Range(1, 5); //numéros aléatoire pour l'état du boss
        print(etatBoss);

        if (etatBoss == 2 || etatBoss == 3 && attaque1==false && GetComponent<VieDommage>().estMort==false) //si étatBos est == à 2 ou à 3 et qu'il n'est pas mort...
        {
            attaque1 = true; //valeur boolean d'attaque1 est vrai
            GetComponent<Animator>().SetBool("attaque1", true); //activer l'animation d'attaque 1
            Invoke("ArretAttaque1", 4f); //invoquer l'arret de l'attaque apres 4 secondes
            GetComponent<Animator>().SetBool("blesser", false); //désactiver l'animation blesser
        }

        else if (etatBoss == 4 && attaque2==false && GetComponent<VieDommage>().estMort == false) //si étatBos est == à 4 et qu'il n'est pas mort...
        {
            attaque2 = true;    //valeur boolean d'attaque1 est vrai
            GetComponent<Animator>().SetBool("attaque2", true); //activer l'animation d'attaque 2
            Invoke("ArretAttaque2", 1.4f);//invoquer l'arret de l'attaque apres 1.4 scondes
            GetComponent<Animator>().SetBool("blesser", false); //désactiver l'animation blesser
        }
    }

    void ArretAttaque1() // fonction pour arreter l'attaque
    {
        attaque1 = false; //attaque devient false
        GetComponent<Animator>().SetBool("attaque1", false); //désactiver l'animation d'attaque 1
    }

    void ArretAttaque2() // fonction pour arreter l'attaque
    {
        attaque2 = false; //attaque devient false
        GetComponent<Animator>().SetBool("attaque2", false); //désactiver l'animation d'attaque 1
    }

    void ArretBlesse() // fonction pour arreter de blesse
    {
        GetComponent<Animator>().SetBool("blesser", false); //désactiver l'animation blesser
    }
}
