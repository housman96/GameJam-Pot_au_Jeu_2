using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open_door : MonoBehaviour
{
    // Start is called before the first frame update
    Collider2D m_BoxCollider;
    SpriteRenderer m_Renderer;
    bool trigger = false;
    bool isKilled = false;
    public Sprite BloodyDoor;
    Sprite ColoredDoor;
    GameObject villager;
    GameObject player;

    

    void OnTriggerEnter2D (Collider2D other)
    {
        Debug.Log("TrigerEnter");
        trigger = true;
        player = other.gameObject;
        Debug.Log("other: " + player);
        Debug.Log(transform.parent.gameObject.GetComponent<House>());
        villager = transform.parent.gameObject.GetComponent<House>().villager.gameObject;
        Debug.Log("Villager: " + villager);
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
    }

    // Update is called once per frame
    void Update()
    {
        float p1 = Input.GetAxis("P1_Action");
        float p2 = Input.GetAxis("P2_Action");

        if (trigger == true &&  isKilled == false && (p1 == 1 || p2 ==2))
        {
            m_Renderer.sprite = BloodyDoor;
            isKilled = true;
            Debug.Log("Trigger: " + trigger+" // P1: "+ p1+ " // P2: " + p2);










        }
        

    }
}
