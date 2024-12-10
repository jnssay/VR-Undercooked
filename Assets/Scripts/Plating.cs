using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Plating : MonoBehaviour
{
    public GameObject burgerPrefab;
    public GameObject soupPrefab;
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
        GameObject burger = Instantiate(burgerPrefab, position, rotation);
        Destroy(other.gameObject);
        // KillPlate();
        Destroy(gameObject);
    }

    private void PlateSoup(Collider other)
    {
        Vector3 position = other.transform.position;
        Quaternion rotation = other.transform.rotation;
        GameObject burger = Instantiate(soupPrefab, position, rotation);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }

}
