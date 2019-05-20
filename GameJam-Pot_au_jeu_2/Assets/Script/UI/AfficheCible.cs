using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AfficheCible : MonoBehaviour
{

    public TextMeshProUGUI target1;
    public TextMeshProUGUI target2;
    public TextMeshProUGUI target3;

    public TextMeshProUGUI target1Done;
    public TextMeshProUGUI target2Done;
    public TextMeshProUGUI target3Done;

    private GameObject cible1;
    private GameObject cible2;
    private GameObject cible3;

    // Start is called before the first frame update
    void Start()
    {
        target1Done.gameObject.SetActive(false);
        target2Done.gameObject.SetActive(false);
        target3Done.gameObject.SetActive(false);

    }

    public void SetLesCiblesVisu(GameObject cible1, GameObject cible2, GameObject cible3)
    {
        this.cible1 = cible1;
        this.cible2 = cible2;
        this.cible3 = cible3;
        target1.text = cible1.GetComponent<Villager>().villagerName;
        target2.text = cible2.GetComponent<Villager>().villagerName;
        target3.text = cible3.GetComponent<Villager>().villagerName;
    }

    public void AfficherLaMort(GameObject cible)
    {
        if (cible == cible1)
        {
            target1Done.gameObject.SetActive(true);
        }

        else if (cible == cible2)
        {
            target2Done.gameObject.SetActive(true);
        }

        else if (cible == cible3)
        {
            target3Done.gameObject.SetActive(true);
        }

    }

}
