using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chronoManager : MonoBehaviour
{
    public Slider slider;

    [SerializeField]
    private int timeDivider;

    // Update is called once per frame
    private void Update()
    {
        slider.value += Time.deltaTime/timeDivider;

        if(slider.value == 24)
        {
            slider.value = 0;
        }
    }
}
