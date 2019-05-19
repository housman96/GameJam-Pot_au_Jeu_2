using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ShowDialog : MonoBehaviour
{
    public TextMeshProUGUI Bubble;

    void Start()
    {
        Bubble.text = "Hello, {$Nom1} have a {$Taille} house.{$Nom2}have a {$Porte}door.There is a {$Objet}around {$Nom3}'s house.";
    }

    void Update()
    {
        
    }

    public void SetText(string nom1, string nom2, string nom3, string taille, string porte, string objet)
    {
        Bubble.text = "Hello, "+ nom1 +" have a " + taille +" house. " + nom2 +" have a " + porte + " door. There is a " + objet + " around " + nom3 +"'s house.";

    }
}
