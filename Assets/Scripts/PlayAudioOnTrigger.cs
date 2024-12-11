using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioOnTrigger : MonoBehaviour
{
    public AudioClip sound;

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
            if (source != null){
                source.PlayOneShot(sound);
            }

        }
        if ((other.tag == "BurgerFinish") || (other.tag == "SoupFinish"))
        {
            if (source != null)
            {
                source.PlayOneShot(sound);
            }
        }
    }
}
