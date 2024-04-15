using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scriptintro : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Invoke("LancerLeJeu", 0f);
        }
    }

    void LancerLeJeu()
    {

        SceneManager.LoadScene("SceneDeJeu");
    }
}
