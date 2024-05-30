using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VieDommageNiv2 : MonoBehaviour
{ 
    public int vieMax = 200; // valeur pour la vie maximum
    public int vieActuelle;  //valeur pour la vie actuelle
    public BarreDeVie barreDeVie; //cible le script barre de vie 
    public AudioClip SonMort; //son pour la mort
    public GameObject Rouleau; // gameobject pour cibler le rouleau
    public bool estMort; //valeur pour cibler la mort

    // Start is called before the first frame update
    void Start()
    {
        vieActuelle = vieMax;  //au début la vie actuelle est égal à la vie maximum
        barreDeVie.mettreVieMax(vieMax); //au début la valeur du slider est égal à la vie au maximum
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space)) //mort instantaner si besoin
        {
            prendreDommage(100);
        }*/

        if (vieActuelle <= 0) // si la vie actuelle est égal à zéro
        {
            vieActuelle = 0; //vie actuelle est égal à zéro
            estMort = true; //mort est true
            gameObject.GetComponent<Collider2D>().enabled = false;//enlever le collider
            GetComponent<Animator>().SetTrigger("mort");//activer l'animation de mort
            GetComponent<Animator>().SetBool("attaque1", false); //l'animation d'attaque 1 est false
            GetComponent<Animator>().SetBool("attaque2", false);  //l'animation d'attaque 2 est false
            /*GetComponent<AudioSource>().PlayOneShot(SonMort);//jouer le son de la mort*/
            Destroy(gameObject, 0.8f); //le gameObject mechant est detruit apres l'animation
            Invoke("rouleauApparition", 0.7f); //appeler la fonction pour faire apparaitre le rouleau
        }

    }

    public void prendreDommage(int Dommage) //fonction pour prendre les dommages
    {
        vieActuelle -= Dommage; // la vie actuelle moins les dommages
        barreDeVie.mettreVie(vieActuelle); //la valeur du slider est égal à la vie actuelle
    }


    void rouleauApparition() //fonction pour faire apparaitre le rouleau
    {
        Rouleau.SetActive(true);
    }

  
}
