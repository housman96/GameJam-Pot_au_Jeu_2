using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverHandler : MonoBehaviour
{
    public GameObject txtJ1;
    public GameObject txtJ2;

    // TODO : change bool
    private bool isJ1Winner = true;


    // Start is called before the first frame update
    void Start()
    {
        if (isJ1Winner)
        {
            txtJ1.SetActive(true);
            txtJ2.SetActive(false);
        }
        else
        {
            txtJ1.SetActive(false);
            txtJ2.SetActive(true);
        }
    }

    public void onClickNewGame()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Restart!");
    }

    public void onClickExit()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
