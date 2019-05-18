using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open_door : MonoBehaviour
{
    // Start is called before the first frame update
    private Collider m_BoxCollider;
    private Renderer m_Renderer;

    void Start()
    {
        m_BoxCollider = GetComponent<BoxCollider>();
        m_BoxCollider.enabled = true;
        m_BoxCollider.isTrigger = false;
        // m_SphereCollider = GetComponent<SphereCollider>();
        // m_SphereCollider.isTrigger = false;
        m_Renderer = GetComponent<Renderer>();
        m_Renderer.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && m_BoxCollider.isTrigger == true)
        {
            //Toggle the Collider on and off when pressing the space bar
            //m_BoxCollider.enabled = false;
            m_Renderer.enabled = false;

            //Output to console whether the Collider is on or not
            //Debug.Log("Collider.enabled = " + m_BoxCollider.enabled);
            Debug.Log("Renderer.enabled = " + m_Renderer.enabled);
        }

    }
}
