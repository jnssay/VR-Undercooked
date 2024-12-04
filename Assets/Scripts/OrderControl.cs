using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderControl : MonoBehaviour
{
    public OrderingSystem ordering_system;
    public GameControl game_control;

    private float max_order_countdown = 60f;    // an order last about 60 seconds before disappearing
    private float current_order_countdown;
    private bool order_failed = false;

    // Start is called before the first frame update
    void Start()
    {
        current_order_countdown = max_order_countdown;
    }

    // Update is called once per frame
    void Update()
    {
        if (!game_control.stage_clear)
        {
            if (game_control.stage_ongoing)
            {
                current_order_countdown -= Time.deltaTime;
            }
            // if order_countdown reaches 0, order has failed and disappears
            if (current_order_countdown <= 0)
            {
                order_failed = true;
                ordering_system.orders_failed += 1;
                gameObject.SetActive(false);
            }
        }

    }
}
