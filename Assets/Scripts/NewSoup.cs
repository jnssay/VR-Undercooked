using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSoup : MonoBehaviour
{
    public GameObject nextSoupPrefab;

    private void OnTriggerEnter(Collider ingredient) {
        if (ingredient.CompareTag("Raw-Fry"))
        {
            Debug.Log("Meat is in the water");
            PutMeatInSoup(transform.position, transform.rotation);
            Destroy(ingredient.gameObject);
            Destroy(transform.parent.gameObject);
        }
        if (ingredient.CompareTag("Cup"))
        {
            Debug.Log("Poured water from cup into pot");
            PutMeatInSoup(transform.position, transform.rotation);
            Destroy(ingredient.gameObject);
            Destroy(transform.parent.gameObject);
        }
    }

    private void PutMeatInSoup(Vector3 position, Quaternion rotation)
    {
        Instantiate(nextSoupPrefab, position, rotation);
    }
}
