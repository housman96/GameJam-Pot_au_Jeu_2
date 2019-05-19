using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    public GameObject panelMenu;
    public GameObject panelTutoriel;
    public GameObject panelCredits;

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
        float a = 0;

        setAlphaObject(panelCredits, 0);
        panelCredits.SetActive(true);

        while (a <= 1)
        {
            yield return new WaitForSeconds(0.01f);
            setAlphaObject(panelCredits, a);
            a += 0.05f;
        }
        yield return new WaitForSeconds(0.5f);

        a = 1;
        while (a >= 0)
        {
            yield return new WaitForSeconds(0.01f);
            setAlphaObject(panelMenu, a);
            a -= 0.05f;
        }
        panelMenu.SetActive(false);
    }

    public IEnumerator menuToTutorial()
    {
        float a = 0;

        setAlphaObject(panelTutoriel, 0);
        panelTutoriel.SetActive(true);

        while (a <= 1)
        {
            yield return new WaitForSeconds(0.01f);
            setAlphaObject(panelTutoriel, a);
            a += 0.05f;
        }
        yield return new WaitForSeconds(0.5f);

        a = 1;
        while (a >= 0)
        {
            yield return new WaitForSeconds(0.01f);
            setAlphaObject(panelMenu, a);
            a -= 0.05f;
        }
        panelMenu.SetActive(false);
    }

    public IEnumerator creditsToMenu()
    {
        float a = 1;
        setAlphaObject(panelMenu, 0);
        panelMenu.SetActive(true);
        while (a <= 1)
        {
            yield return new WaitForSeconds(0.01f);
            setAlphaObject(panelMenu, a);
            a += 0.05f;
        }
        yield return new WaitForSeconds(0.5f);

        a = 1;
        while (a >= 0)
        {
            yield return new WaitForSeconds(0.01f);
            setAlphaObject(panelCredits, a);
            a -= 0.05f;
        }
        panelCredits.SetActive(false);

    }

    public IEnumerator tutorielToMenu()
    {
        float a = 1;
        setAlphaObject(panelMenu, 0);
        panelMenu.SetActive(true);
        while (a <= 1)
        {
            yield return new WaitForSeconds(0.01f);
            setAlphaObject(panelMenu, a);
            a += 0.05f;
        }
        yield return new WaitForSeconds(0.5f);

        a = 1;
        while (a >= 0)
        {
            yield return new WaitForSeconds(0.01f);
            setAlphaObject(panelTutoriel, a);
            a -= 0.05f;
        }
        panelTutoriel.SetActive(false);

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
