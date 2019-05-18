using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class switchSunMoon : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private Image slot;

    public Sprite moon;
    public Sprite sun;

    // Update is called once per frame
    void Update()
    {
        if(slider.value >= 12)
        {
            slot.sprite = moon;
        }
        else
        {
            slot.sprite = sun;
        }
    }
}
