using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = 5;
    }

    public void SetHealth(int hp)
    {
        slider.value = hp;
    }
}
