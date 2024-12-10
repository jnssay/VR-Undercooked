using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumChopsBarControl : MonoBehaviour
{
    
    public RawMeatControl raw_meat_control;
    public Slider hp_slider;
    public Image image;
    public GameObject num_chops_bar;

    private GameControl game_control;
    private float current_num_chops;

    // Start is called before the first frame update
    void Start()
    {
        game_control = FindObjectOfType<GameControl>();
        hp_slider.maxValue = raw_meat_control.max_num_chops;
        hp_slider.value = hp_slider.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        if (raw_meat_control.is_choppable)
        {
            num_chops_bar.SetActive(true);
            if (raw_meat_control.current_num_chops != 0)
            {
                hp_slider.value = raw_meat_control.max_num_chops - raw_meat_control.current_num_chops;
            }
        }
        else
        {
            num_chops_bar.SetActive(false);
        }


    }
}
