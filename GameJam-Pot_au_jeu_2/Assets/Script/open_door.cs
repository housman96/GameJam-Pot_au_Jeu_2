using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class open_door : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite BloodyDoor;

    public GameObject camera;

    public Slider chronoSlider;
    public float chronoValue;

    bool trigger = false;
    bool isKilled = false;

    Image imageFondu;
    Image p1UI;
    Image p2UI;
    Collider2D m_BoxCollider;
    SpriteRenderer m_Renderer;
    Sprite ColoredDoor;
    GameObject villager;
    GameObject player;

    public GameObject PanelVillagerKillP1;
    public GameObject PanelVillagerKillP2;


    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("TrigerEnter");
        trigger = true;
        player = other.gameObject;
        Debug.Log("other: " + player);
        Debug.Log(transform.parent.gameObject.GetComponent<House>());
        villager = transform.parent.gameObject.GetComponent<House>().villager.gameObject;
        Debug.Log("Villager: " + villager);
        //Debug.Log(chronoValue);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("TrigerExit");
        trigger = false;
    }

    void Start()
    {
        m_BoxCollider = GetComponent<Collider2D>();
        m_Renderer = GetComponent<SpriteRenderer>();
        ColoredDoor = m_Renderer.sprite;


        p1UI = GameObject.Find("P1UI").GetComponent<Image>();
        p2UI = GameObject.Find("P2UI").GetComponent<Image>(); ;
    }

    // Update is called once per frame
    void Update()
    {
        float p1 = Input.GetAxis("P1_Action");
        float p2 = Input.GetAxis("P2_Action");

        chronoValue = chronoSlider.value;

        if (trigger == true && isKilled == false && (p1 == 1 || p2 == 1) && chronoValue >= 13)
        {
            if (p1 == 1) { imageFondu = p1UI; }
            else { imageFondu = p2UI; }
            Debug.Log("Trigger: " + trigger + " // P1: " + p1 + " // P2: " + p2);
            isKilled = true;
            StartCoroutine("fadeOut");
            gameManager.Instance.killVillager(player, villager);
        }


    }

    public IEnumerator fadeOut()
    {
        while (imageFondu.color.a < 1)
        {
            imageFondu.color = new Color(imageFondu.color.r, imageFondu.color.g, imageFondu.color.b, imageFondu.color.a + 0.01f);
            yield return new WaitForSeconds(0.01f);
        }
        gameManager.Instance.teleportPlayer(player);

		if (player.tag == "Player1") {            PanelVillagerKillP1.GetComponent<KillText>().UpdateKillText(villager);
            PanelVillagerKillP1.SetActive(true);
        }

        if (player.tag == "Player2")
        {
            PanelVillagerKillP2.GetComponent<KillText>().UpdateKillText(villager);
            PanelVillagerKillP2.SetActive(true);
        }

        m_Renderer.sprite = BloodyDoor;

		
    }
}
