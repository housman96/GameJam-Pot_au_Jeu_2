using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TalkOnCollider : MonoBehaviour
{
    public GameObject PanelP1;
    public GameObject PanelP2;

	public TextMeshProUGUI TextP1;
	public TextMeshProUGUI TextP2;


	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.E))
        {
            Villager current = gameObject.GetComponent<Villager>();

            string Nom1 = current.villagerToTalk1.villagerName;
            string Nom2 = current.villagerToTalk2.villagerName;
            string Nom3 = current.villagerToTalk3.villagerName;

            string Taille;
            if (current.villagerToTalk1.house.size == Size.Large) { Taille = "large"; }
            else if (current.villagerToTalk1.house.size == Size.Medium) { Taille = "medium"; }
            else { Taille = "small"; }

            string Porte;
            if (current.villagerToTalk1.house.door == Door.Brown) { Porte = "brown"; }
            else if (current.villagerToTalk1.house.door == Door.Blue) { Porte = "blue"; }
            else { Porte = "green"; }

            string Objet;
            if (current.villagerToTalk1.house.deco == Deco.Barrel) { Objet = "barrel"; }
            else if (current.villagerToTalk1.house.deco == Deco.Seat) { Objet = "seat"; }
            else { Objet = "ladder"; }

			TextP1.text = "Hello, " + Nom1 + " have a " + Taille + " house. " + Nom2 + " have a " + Porte + " door. There is a " + Objet + " around " + Nom3 + "'s house.";
			PanelP1.SetActive(true);
            
        }
    }
}
