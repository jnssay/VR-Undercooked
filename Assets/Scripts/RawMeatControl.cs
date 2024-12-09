using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RawMeatControl : MonoBehaviour
{
    public float max_num_chops = 5f;
    public float current_num_chops;
    public bool is_choppable = false;

    // Start is called before the first frame update
    void Start()
    {
        current_num_chops = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
