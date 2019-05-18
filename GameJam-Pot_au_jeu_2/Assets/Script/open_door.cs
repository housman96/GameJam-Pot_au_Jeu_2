using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open_door : MonoBehaviour
{
    // Start is called before the first frame update
    private Collider m_Collider;
    private Renderer m_Renderer;

    void Start()
    {
        m_Collider = GetComponent<Collider>();
        m_Collider.enabled = true;
        m_Renderer = GetComponent<Renderer>();
        m_Renderer.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Toggle the Collider on and off when pressing the space bar
            m_Collider.enabled = false;
            m_Renderer.enabled = false;

            //Output to console whether the Collider is on or not
            Debug.Log("Collider.enabled = " + m_Collider.enabled);
            Debug.Log("Renderer.enabled = " + m_Renderer.enabled);
        }

    }
}
