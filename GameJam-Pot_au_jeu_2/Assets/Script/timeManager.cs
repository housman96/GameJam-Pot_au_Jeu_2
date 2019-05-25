using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeManager : MonoBehaviour
{
    public Slider timeSlider;
    public Light mainLight;
    public Image p1UI;
    public Image p2UI;

    public float transition;

    private float timeValue;
    private Color nightColor;
    private Color dayColor;
    private Color fadeA;
    private Color fadeB;

    public GameObject PanelVillagerKillP1;
    public GameObject PanelVillagerKillP2;

    bool isInPhase1 = false;
    bool isInPhase2 = false;
    bool isInPhase3 = false;
    bool isInPhase4 = false;


    // Start is called before the first frame update
    void Start()
    {
        nightColor = new Color(0.2392157f, 0.3568628f, 0.9490196f, 1f);
        dayColor = new Color(1, 1, 1, 1);
        fadeA = new Color(0, 0, 0, 0);
        fadeB = new Color(0, 0, 0, 1);
        transition = 1;

        p1UI.GetComponent<Image>().color = fadeB;
        p2UI.GetComponent<Image>().color = fadeB;
    }

    // Update is called once per frame
    void Update()
    {
        timeValue = timeSlider.value;

        if (timeValue >= 12f)
        {
            mainLight.intensity = 0.66f;
            mainLight.color = nightColor;
        }
        else
        {
            mainLight.intensity = 1f;
            mainLight.color = dayColor;
        }

        if (timeValue >= 11.75 & timeValue < 12 && !isInPhase1)
        {
            isInPhase1 = true;
            isInPhase4 = false;

            StartCoroutine(fadeOut(p1UI));
            StartCoroutine(fadeOut(p2UI));
            //transition += Time.deltaTime / 2;
            //p1UI.color = Color.Lerp(fadeA, fadeB, transition);
            //p2UI.color = Color.Lerp(fadeA, fadeB, transition);
        }
        else if (timeValue >= 12 & timeValue < 12.25 && !isInPhase2)
        {
            isInPhase2 = true;
            isInPhase1 = false;

            StartCoroutine(fadeIn(p1UI));
            StartCoroutine(fadeIn(p2UI));
            //transition -= Time.deltaTime / 2;
            //p1UI.color = Color.Lerp(fadeA, fadeB, transition);
            //p2UI.color = Color.Lerp(fadeA, fadeB, transition);
        }
        else if (timeValue >= 23.75 & timeValue < 24 && !isInPhase3)
        {
            isInPhase3 = true;
            isInPhase2 = false;

            StartCoroutine(fadeOut(p1UI));
            StartCoroutine(fadeOut(p2UI));
            //transition += Time.deltaTime / 2;
            //p1UI.color = Color.Lerp(fadeA, fadeB, transition);
            //p2UI.color = Color.Lerp(fadeA, fadeB, transition);
        }
        else if (timeValue >= 0 & timeValue < 0.25 && !isInPhase4)
        {

            isInPhase4 = true;
            isInPhase3 = false;

            StartCoroutine(fadeIn(p1UI));
            StartCoroutine(fadeIn(p2UI));
            //transition -= Time.deltaTime / 2;
            //p1UI.color = Color.Lerp(fadeA, fadeB, transition);
            //p2UI.color = Color.Lerp(fadeA, fadeB, transition);

            PanelVillagerKillP1.SetActive(false);
            PanelVillagerKillP2.SetActive(false);
        }
    }

    public IEnumerator fadeOut(Image imageFondu)
    {

        //yield return new WaitForSeconds(4f);
        //Debug.Log("FadeOut");
        while (imageFondu.color.a < 1)
        {
            imageFondu.color = new Color(imageFondu.color.r, imageFondu.color.g, imageFondu.color.b, imageFondu.color.a + 0.01f);
            yield return new WaitForSeconds(0.01f);
        }
    }

    public IEnumerator fadeOutPanel(GameObject panel)
    {

        //yield return new WaitForSeconds(4f);
        //Debug.Log("FadeOut");
        while (panel.GetComponent<CanvasRenderer>().GetAlpha() < 1)
        {
            panel.GetComponent<CanvasRenderer>().SetAlpha(panel.GetComponent<CanvasRenderer>().GetAlpha() + 0.01f);
            yield return new WaitForSeconds(0.01f);
        }
        panel.SetActive(false);
        panel.GetComponent<CanvasRenderer>().SetAlpha(0);
        panel.SetActive(true);
    }

    public IEnumerator fadeIn(Image imageFondu)
    {

        //yield return new WaitForSeconds(4f);
        //Debug.Log("FadeOut");
        while (imageFondu.color.a > 0)
        {
            imageFondu.color = new Color(imageFondu.color.r, imageFondu.color.g, imageFondu.color.b, imageFondu.color.a - 0.01f);
            yield return new WaitForSeconds(0.01f);
        }
    }

}
