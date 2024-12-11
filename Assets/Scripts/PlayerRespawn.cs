using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Transform spawn_point_1;
    public Transform spawn_point_2;

    private int chosen_spawn_point;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            chosen_spawn_point = Random.Range(1, 2);
            if (chosen_spawn_point == 1)
            {
                other.gameObject.transform.position = spawn_point_1.position;
            }
            else if (chosen_spawn_point == 2)
            {
                other.gameObject.transform.position = spawn_point_2.position;
            }
        }
    }
}
