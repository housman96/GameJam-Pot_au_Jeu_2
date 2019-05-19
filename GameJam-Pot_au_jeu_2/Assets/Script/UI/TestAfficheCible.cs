using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAfficheCible : MonoBehaviour
{
    public GameObject panelP1;
    public GameObject panelP2;

    public GameObject cible1;
    public GameObject cible2;
    public GameObject cible3;

    // Start is called before the first frame update
    void Start()
    {
        panelP1.GetComponent<AfficheCible>().SetLesCiblesVisu(cible1, cible2, cible3);
        panelP2.GetComponent<AfficheCible>().SetLesCiblesVisu(cible1, cible2, cible3);

        
    }

    // Update is called once per frame
    void Update()
    {
        panelP1.GetComponent<AfficheCible>().AfficherLaMort(cible2);
        panelP2.GetComponent<AfficheCible>().AfficherLaMort(cible3);
    }
}
