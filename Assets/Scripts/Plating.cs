using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Alteruna;

public class Plating : MonoBehaviour
{
    public GameObject burgerPrefab;
    public Spawner spawner;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BurgerPrefinish"))
        {
            Debug.Log("Plating burger");
            PlateBurger(other);
        }
        //if (other.CompareTag("SoupPrefinish"))
        //{
        //    Debug.Log("Plating Soup");
        //    PlateSoup(other);
        //}
    }

    private void PlateBurger(Collider other)
    {
        Vector3 position = gameObject.transform.position;
        Quaternion rotation = gameObject.transform.rotation;
        GameObject burger = spawner.Spawn(0, position, rotation);
        Destroy(other.gameObject);
        // KillPlate();
        Destroy(gameObject);
    }


}
