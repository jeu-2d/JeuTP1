using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoupEpee : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D Collision)
    {
        if (Collision.gameObject.name == "MonstreVolant") //si il y une collision entre l'epee et le monstre...

        {
            Collision.gameObject.GetComponent<Animator>().SetTrigger("contact"); //activer l'animation de mort du monstre
            Collision.gameObject.GetComponent<Collider2D>().enabled = false; //desactiver le collider
            Destroy(Collision.gameObject, 1f); //le gameObject mechant est detruit apres l'animation
        }

        if (Collision.gameObject.name == "MonstreVolantDeplacement")

        {
            Collision.gameObject.GetComponent<Animator>().enabled = false; //desactiver l'animation gauche droite
            Collision.gameObject.GetComponent<Collider2D>().enabled = false; // desactiver le collider
        }
    }

}
