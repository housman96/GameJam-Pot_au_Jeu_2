using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    public GameObject canvasMenu;
    public GameObject canvasCredits;

    public void Start()
    {
        canvasCredits.SetActive(false);
    }

    public void onClickNewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void onClickCredits()
    {
        StartCoroutine("menuToCredits");
    }

    public void onClickMenu()
    {
        StartCoroutine("creditsToMenu");
    }

    public IEnumerator menuToCredits()
    {
        float a = 1;
        while (a >= 0)
        {
            yield return new WaitForSeconds(0.01f);
            setAlphaObject(canvasMenu, a);
            a -= 0.05f;
        }
        canvasMenu.SetActive(false);

        yield return new WaitForSeconds(0.5f);
        canvasCredits.SetActive(true);
        setAlphaObject(canvasCredits, 0);
        while (a <= 1)
        {
            yield return new WaitForSeconds(0.01f);
            setAlphaObject(canvasCredits, a);
            a += 0.05f;
        }

    }

    public IEnumerator creditsToMenu()
    {
        float a = 1;
        while (a >= 0)
        {
            yield return new WaitForSeconds(0.01f);
            setAlphaObject(canvasCredits, a);
            a -= 0.05f;
        }
        canvasCredits.SetActive(false);

        yield return new WaitForSeconds(0.5f);
        canvasMenu.SetActive(true);
        setAlphaObject(canvasMenu, 0);
        while (a <= 1)
        {
            yield return new WaitForSeconds(0.01f);
            setAlphaObject(canvasMenu, a);
            a += 0.05f;
        }

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
