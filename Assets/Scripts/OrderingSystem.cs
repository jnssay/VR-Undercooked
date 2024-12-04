using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderingSystem : MonoBehaviour
{
    public float initial_orders = 2;
    public GameControl game_control;
    public float max_order_interval = 10f;  // new order arrives every 10 seconds
    public float orders_failed = 0;
    public float orders_completed = 0;

    private float current_order_interval;


    // Start is called before the first frame update
    void Start()
    {
        current_order_interval = max_order_interval;
    }

    // Update is called once per frame
    void Update()
    {
        if (!game_control.stage_clear)
        {
            if (game_control.stage_ongoing)
            {
                current_order_interval -= Time.deltaTime;
            }
            if (current_order_interval <= 0)
            {
                // create a new order gameobject
                current_order_interval = max_order_interval;
            }
        }

    }
}
