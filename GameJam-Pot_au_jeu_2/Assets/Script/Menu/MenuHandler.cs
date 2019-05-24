using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    public GameObject panelMenu;
    public GameObject panelTutoriel;
    public GameObject panelCredits;

    public bool isInTransition = false;

    public void Start()
    {
        panelCredits.SetActive(false);
        panelTutoriel.SetActive(false);
        panelMenu.SetActive(true);
    }

    public void onClickNewGame()
    {
        SceneManager.LoadScene(1);
        Debug.Log("Play!");
    }

    public void onClickTutorial()
    {
        StartCoroutine("menuToTutorial");
    }

    public void onClickCredits()
    {
        StartCoroutine("menuToCredits");
    }

    public void onClickMenu(bool isCredit)
    {
        if (isCredit)
            StartCoroutine("creditsToMenu");
        else
            StartCoroutine("tutorielToMenu");
    }

    public void onClickExit()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public IEnumerator menuToCredits()
    {
        if (!isInTransition)
        {
            isInTransition = true;

            panelCredits.layer = 1;
            panelMenu.layer = 0;

            float a = 0;

            setAlphaObject(panelCredits, 0);
            panelCredits.SetActive(true);

            while (a <= 1)
            {
                yield return new WaitForSeconds(0.01f);
                setAlphaObject(panelCredits, a);
                setAlphaObject(panelMenu, 1 - a);
                a += 0.05f;
            }

            panelMenu.SetActive(false);
        }
        isInTransition = false;
    }

    public IEnumerator menuToTutorial()
    {
        if (!isInTransition)
        {
            isInTransition = true;
            float a = 0;

            setAlphaObject(panelTutoriel, 0);

            panelTutoriel.layer = 1;
            panelMenu.layer = 0;


            panelTutoriel.SetActive(true);


            while (a <= 1)
            {
                yield return new WaitForSeconds(0.01f);
                setAlphaObject(panelTutoriel, a);
                setAlphaObject(panelMenu, 1 - a);
                a += 0.05f;
            }

            panelMenu.SetActive(false);

        }
        isInTransition = false;
    }

    public IEnumerator creditsToMenu()
    {
        if (!isInTransition)
        {
            isInTransition = true;
            panelCredits.layer = 0;
            panelMenu.layer = 1;

            float a = 0;
            setAlphaObject(panelMenu, 0);
            panelMenu.SetActive(true);
            while (a <= 1)
            {
                yield return new WaitForSeconds(0.01f);
                setAlphaObject(panelMenu, a);
                setAlphaObject(panelCredits, 1 - a);
                a += 0.05f;
            }

            panelCredits.SetActive(false);
        }
        isInTransition = false;
    }

    public IEnumerator tutorielToMenu()
    {
        if (!isInTransition)
        {
            isInTransition = true;
            panelTutoriel.layer = 0;
            panelMenu.layer = 1;

            float a = 0;

            setAlphaObject(panelMenu, 0);
            panelMenu.SetActive(true);

            while (a <= 1)
            {
                yield return new WaitForSeconds(0.01f);
                setAlphaObject(panelMenu, a);
                setAlphaObject(panelTutoriel, 1 - a);
                a += 0.05f;
            }
            panelTutoriel.SetActive(false);

        }
        isInTransition = false;

    }


    public void setAlphaObject(GameObject myObject, float a)
    {
        foreach (Transform child in myObject.transform)
        {
            if (child.GetComponent<CanvasRenderer>() != null)
            {
                child.GetComponent<CanvasRenderer>().SetAlpha(a);
            }
            setAlphaObject(child.gameObject, a);
        }
    }
}
