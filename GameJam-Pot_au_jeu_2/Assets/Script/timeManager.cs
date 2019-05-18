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

    // Start is called before the first frame update
    void Start()
    {
        nightColor = new Color(0.2392157f, 0.3568628f, 0.9490196f, 1f);
        dayColor = new Color(1, 1, 1, 1);
        fadeA = new Color(0, 0, 0, 0);
        fadeB = new Color(0, 0, 0, 1);
        transition = 1;
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

        if (timeValue >= 11.75 & timeValue < 12)
        {
            transition += Time.deltaTime / 2;
            p1UI.color = Color.Lerp(fadeA, fadeB, transition);
            p2UI.color = Color.Lerp(fadeA, fadeB, transition);
        }
        else if (timeValue >= 12 & timeValue < 12.25)
        {
            transition -= Time.deltaTime / 2;
            p1UI.color = Color.Lerp(fadeA, fadeB, transition);
            p2UI.color = Color.Lerp(fadeA, fadeB, transition);
        }
        else if (timeValue >= 23.75 & timeValue < 24)
        {
            transition += Time.deltaTime / 2;
            p1UI.color = Color.Lerp(fadeA, fadeB, transition);
            p2UI.color = Color.Lerp(fadeA, fadeB, transition);
        }
        else if (timeValue >= 0 & timeValue < 0.25)
        {
            transition -= Time.deltaTime / 2;
            p1UI.color = Color.Lerp(fadeA, fadeB, transition);
            p2UI.color = Color.Lerp(fadeA, fadeB, transition);
        }
    }
}
