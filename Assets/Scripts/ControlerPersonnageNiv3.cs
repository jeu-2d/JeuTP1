using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class ControlerPersonnageNiv3 : MonoBehaviour
{

    //les variables public
    float vitesseX;      //vitesse horizontale actuelle
    public float vitesseXMax;   //vitesse horizontale Maximale d�sir�e
    float vitesseY;      //vitesse verticale 
    public bool attaque;  // valeur pour utiliser quand le h�ro attaque
    public bool roulade;  // valeur pour utiliser quand le h�ro fait une roulade
    public bool estMort;      // valeur pour utiliser quand le hero Meurt
    public bool superAttaque;
    public TextMeshProUGUI PointDeVie; //variables pour le texte point de vie
    public int pv = 100;// variable pour les points de vies
    public AudioClip SonRoulade; // son pour la roulade
    public AudioClip SonAttaque; // son pour l'attaque
    public AudioClip SonMort; // son pour la mort
    public AudioClip SonBlesse; // son pour quand il est blesser
    public GameObject Perso; // gameobject pour cibler le personnage
    public GameObject leBoss; // gameobject pour cibler le boss
    public GameObject texteMort; // gameobject pour cibler le texte quand il est mort



    // Update is called once per frame
    void Update()
    {

        // si le hero n'est pas mort...
        if (!estMort)
        {


            if (pv <= 0)//si les pv du hero sont plus ou egal a zero mort devient true
            {
                estMort = true; //est mort devient true
                vitesseX = 0;
                gameObject.GetComponent<Collider2D>().enabled = false;//enlever le collider
                //GetComponent<Rigidbody2D>().gravityScale = 0;
                pv = 0;
                PointDeVie.text = pv.ToString();
                texteMort.SetActive(true);
                GetComponent<Animator>().SetTrigger("mort");//activer l'animation de mort
                GetComponent<AudioSource>().PlayOneShot(SonMort, 1f);//jouer le son de la mort
                Invoke("RelancerLeNiv3", 5f); //relancer la scene de jeu apr�s 5 secondes
            }


            // d�placement vers la gauche
            if (Input.GetKey("a"))
            {
                vitesseX = -vitesseXMax;
                transform.localScale = new Vector3(-1, 1, 1); //d�placement le collider bout

            }
            else if (Input.GetKey("d"))   //d�placement vers la droite
            {
                vitesseX = vitesseXMax;
                transform.localScale = new Vector3(1, 1, 1);//d�placement le collider bout


            }
            else
            {
                vitesseX = GetComponent<Rigidbody2D>().velocity.x;  //m�morise vitesse actuelle en X
            }

            if (Input.GetKeyDown(KeyCode.J) && !attaque) //si le joueur appuie sur j
            {
                attaque = true; //la valeur d'attaque devient true
                Invoke("ArretAttaque", 0.4f); //arr�ter l'animation de l'attaque apr�s 0.4 secondes
                GetComponent<AudioSource>().PlayOneShot(SonAttaque, 1f);//jouer le son de la mort
                GetComponent<Animator>().SetTrigger("attaque"); //activer l'animation d'attaque
                GetComponent<Animator>().SetBool("roulade", false); //l'animation de saut est faux
            }

            if (Input.GetKeyDown(KeyCode.Space) && !roulade) //si le joueur appuie sur espace
            {
                roulade = true; //la valeur d'attaque devient true
                GetComponent<Rigidbody2D>().gravityScale = 0;
                Invoke("ArretRoulade", 0.4f); //arr�ter l'animation de l'attaque apr�s 0.4 secondes
                GetComponent<AudioSource>().PlayOneShot(SonRoulade, 1f);//jouer le son de la mort
                GetComponent<Collider2D>().enabled = false;
                GetComponent<Animator>().SetBool("roulade", true); //activer l'animation de roulade
            }
            if (roulade && Mathf.Abs(vitesseX) <= vitesseXMax) //pour ne pas d�passer une certaine limites de vitesse
            {
                vitesseX *= 4f; //augmenter la vitesse
            }

 

            if (Input.GetKeyDown(KeyCode.K) && !attaque && Perso.GetComponent<CoupEpeeNiv3>().superAttaquePret == true)  //si le joueur appuie sur j et que la super attaque est pret � etre utilis�
            {
                GetComponent<Animator>().SetTrigger("superAttaque"); //activer l'animation d'attaque
                Invoke("ArretSuperAttaque", 0.8f); //arr�ter l'animation de la super attaque apr�s 0.8 secondes
                GetComponent<AudioSource>().PlayOneShot(SonAttaque, 1f);//jouer le son de la mort
                GetComponent<Animator>().SetBool("roulade", false); //l'animation de saut est faux
                superAttaque = true; //superAttaque est true 

            }


            //Applique les vitesses en X et Y
            GetComponent<Rigidbody2D>().velocity = new Vector2(vitesseX, vitesseY);

            if (vitesseX > 0.01f || vitesseX < -0.1f)
            {
                GetComponent<Animator>().SetBool("cours", true);//activer l'animation de course

            }
            else
            {
                GetComponent<Animator>().SetBool("cours", false); //d�sactiver l'animation de course

            }
        }

    }

    void OnCollisionEnter2D(Collision2D InfoCollision)
    {


        if (InfoCollision.gameObject.name == "Squelette" && !attaque && InfoCollision.gameObject.GetComponent<mechantNiv3>().attaque == true) //si il y a une collision entre le monstre et attaque est false
        {
            GetComponent<Rigidbody2D>().velocityX = -20f;//le personnage recule
            GetComponent<Animator>().SetTrigger("blesse");//activer l'animation de mort
            GetComponent<AudioSource>().PlayOneShot(SonBlesse, 1f);//jouer le son de la mort
            pv -= 20; // le hero perd 15 points de vie
            PointDeVie.text = pv.ToString();
        }



        if (InfoCollision.gameObject.name == "Boss" && leBoss.GetComponent<BossNiv3>().attaque1 == true) //si il y a une collision entre le monstre et attaque est false
        {

            GetComponent<Animator>().SetTrigger("blesse");//activer l'animation de mort
            GetComponent<AudioSource>().PlayOneShot(SonBlesse, 1f);//jouer le son de la mort
            pv -= 20; // le hero perd 15 points de vie
            PointDeVie.text = pv.ToString();

        }

        if (InfoCollision.gameObject.name == "Boss" && leBoss.GetComponent<BossNiv3>().attaque2 == true) //si il y a une collision entre le monstre et attaque est false
        {

            GetComponent<Animator>().SetTrigger("blesse");//activer l'animation de mort
            GetComponent<AudioSource>().PlayOneShot(SonBlesse, 1f);//jouer le son de la mort
            pv -= 40; // le hero perd 15 points de vie
            PointDeVie.text = pv.ToString();

        }

  


        if (InfoCollision.gameObject.name == "Portail") //si le personnage touche le portail le niveau 3 se lance 
        {
            Invoke("LancerFin", 0f);
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
        GetComponent<Animator>().SetBool("roulade", false); //d�sactiver l'animation de roulade
    }

    void RelancerLeNiv3()
    {
        SceneManager.LoadScene("Niveau3"); //fonction pour relancer le niveau
    }

    void LancerFin()
    {
        SceneManager.LoadScene("Fin");  //si le personnage touche le portail la scene de fin se lance
    }

    void ArretSuperAttaque() //fonction pour arreter la super attaque
    {
        Perso.GetComponent<CoupEpeeNiv3>().superAttaquePret = false; //la super attaque n'est plus pr�te � �tre utilis�
        Perso.GetComponent<CoupEpeeNiv3>().nombreAttaque = 0; //le nombre d'attaque revient � 0
        superAttaque = false; //super attaque redivient false
        Perso.GetComponent<CoupEpeeNiv3>().pA1.SetActive(false); //le premier point d'attaque est d�sactiver
        Perso.GetComponent<CoupEpeeNiv3>().pA2.SetActive(false); //le deuxi�me point d'attaque est d�sactiver
        Perso.GetComponent<CoupEpeeNiv3>().pA3.SetActive(false); //le troisi�me point d'attaque est d�sactiver

    }
}
