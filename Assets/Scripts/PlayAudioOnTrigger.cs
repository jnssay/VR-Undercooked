using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioOnTrigger : MonoBehaviour
{
    public AudioClip chop_meat_sound;
    public AudioClip chop_cheese_sound;
    public AudioClip cannon_sound;

    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "UnchoppedMeat")
        {
            RawFoodControl raw_food_control = other.gameObject.GetComponent<RawFoodControl>();
            if (source != null && raw_food_control.is_choppable)
            {
                source.PlayOneShot(chop_meat_sound);
            }
        }
        if (other.tag == "UnchoppedCheese")
        {
            RawFoodControl raw_food_control = other.gameObject.GetComponent<RawFoodControl>();
            if (source != null && raw_food_control.is_choppable)
            {
                source.PlayOneShot(chop_cheese_sound);
            }

        }

        if ((other.tag == "BurgerFinish") || (other.tag == "SoupFinish"))
        {
            if (source != null)
            {
                source.PlayOneShot(cannon_sound);
            }
        }
    }
}
