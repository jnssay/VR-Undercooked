using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBarControl : MonoBehaviour
{
    public GameControl gameControl;
    public Slider hp_slider;
    public Image image;
    public float max_duration;
    public float current_duration;

    // Start is called before the first frame update
    void Start()
    {
        max_duration = gameControl.max_time;
        hp_slider.maxValue = max_duration;
        current_duration = max_duration;
    }

    // Update is called once per frame
    void Update()
    {
        current_duration = gameControl.current_time;
        if (hp_slider.value != current_duration)
        {
            hp_slider.value = current_duration;
        }
        if (current_duration / max_duration < 0.6 && current_duration / max_duration > 0.3)
        {
            image.color = Color.yellow;
        }
        else if (current_duration / max_duration <= 0.3)
        {
            image.color = Color.red;
        }

    }
}
