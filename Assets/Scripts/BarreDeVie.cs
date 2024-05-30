using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarreDeVie : MonoBehaviour
{
    public Slider slider;

    public void mettreVie(int vie)
    {
        slider.value = vie; //la valeur du slider est égal à la vie
    }

    public void mettreVieMax(int vie)
    {
        slider.maxValue = vie;  //la valeur du slider est égal à la vie au maximum
        slider.value = vie; //la valeur du slider est égal à la vie
    }
}
