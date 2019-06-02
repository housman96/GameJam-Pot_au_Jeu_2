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

    bool isInFade = false;

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


        Debug.Log("test");
        PanelVillagerKillP1.SetActive(false);
        PanelVillagerKillP2.SetActive(false);
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
            isInPhase2 = false;
            isInPhase3 = false;
            isInPhase4 = false;

            StartCoroutine(fadeOut());
            //transition += Time.deltaTime / 2;
            //p1UI.color = Color.Lerp(fadeA, fadeB, transition);
            //p2UI.color = Color.Lerp(fadeA, fadeB, transition);
        }
        else if (timeValue >= 12 & timeValue < 12.25 && !isInPhase2)
        {
            isInPhase1 = false;
            isInPhase2 = true;
            isInPhase3 = false;
            isInPhase4 = false;

            StartCoroutine(fadeIn());
            //transition -= Time.deltaTime / 2;
            //p1UI.color = Color.Lerp(fadeA, fadeB, transition);
            //p2UI.color = Color.Lerp(fadeA, fadeB, transition);
        }
        else if (timeValue >= 23.75 & timeValue < 24 && !isInPhase3)
        {
            isInPhase1 = false;
            isInPhase2 = false;
            isInPhase3 = true;
            isInPhase4 = false;

            StartCoroutine(fadeOut());
            //transition += Time.deltaTime / 2;
            //p1UI.color = Color.Lerp(fadeA, fadeB, transition);
            //p2UI.color = Color.Lerp(fadeA, fadeB, transition);
        }
        else if (timeValue >= 0 & timeValue < 0.25 && !isInPhase4)
        {
            isInPhase1 = false;
            isInPhase2 = false;
            isInPhase3 = false;
            isInPhase4 = true;

            StartCoroutine(fadeIn());
            //transition -= Time.deltaTime / 2;
            //p1UI.color = Color.Lerp(fadeA, fadeB, transition);
            //p2UI.color = Color.Lerp(fadeA, fadeB, transition);

            //PanelVillagerKillP1.SetActive(false);
            //PanelVillagerKillP2.SetActive(false);

            StartCoroutine(fadeOutPanel());
        }
    }

    public IEnumerator fadeOut()
    {

        //yield return new WaitForSeconds(4f);
        //Debug.Log("FadeOut");

        //Debug.Log("FadeOut" + isInFade);
        yield return new WaitUntil(() => !isInFade);
        isInFade = true;
        while (p1UI.color.a < 1 || p2UI.color.a < 1)
        {
            p1UI.color = new Color(p1UI.color.r, p1UI.color.g, p1UI.color.b, p1UI.color.a + 0.01f);
            p2UI.color = new Color(p2UI.color.r, p2UI.color.g, p2UI.color.b, p2UI.color.a + 0.01f);
            yield return new WaitForSeconds(0.01f);
        }
        isInFade = false;
        //Debug.Log("FadeOut" + isInFade);
    }

    public IEnumerator fadeOutPanel()
    {

        //yield return new WaitForSeconds(4f);
        //Debug.Log("FadeOut");
        while (PanelVillagerKillP1.GetComponent<CanvasRenderer>().GetAlpha() < 1 || PanelVillagerKillP2.GetComponent<CanvasRenderer>().GetAlpha() < 1)
        {
            PanelVillagerKillP1.GetComponent<CanvasRenderer>().SetAlpha(PanelVillagerKillP1.GetComponent<CanvasRenderer>().GetAlpha() - 0.01f);
            PanelVillagerKillP2.GetComponent<CanvasRenderer>().SetAlpha(PanelVillagerKillP2.GetComponent<CanvasRenderer>().GetAlpha() - 0.01f);
            yield return new WaitForSeconds(0.01f);
        }
        PanelVillagerKillP1.SetActive(false);
        PanelVillagerKillP1.GetComponent<CanvasRenderer>().SetAlpha(1);

        PanelVillagerKillP2.SetActive(false);
        PanelVillagerKillP2.GetComponent<CanvasRenderer>().SetAlpha(1);
    }

    public IEnumerator fadeIn()
    {

        //yield return new WaitForSeconds(4f);
        //Debug.Log("fadeIn" + isInFade);

        yield return new WaitUntil(() => !isInFade);

        isInFade = true;
        while (p1UI.color.a > 0 || p2UI.color.a > 0)
        {
            p1UI.color = new Color(p1UI.color.r, p1UI.color.g, p1UI.color.b, p1UI.color.a - 0.01f);
            p2UI.color = new Color(p2UI.color.r, p2UI.color.g, p2UI.color.b, p2UI.color.a - 0.01f);
            yield return new WaitForSeconds(0.01f);
        }
        isInFade = false;
        //Debug.Log("fadeIn" + isInFade);
    }

}
