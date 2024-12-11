using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowl : MonoBehaviour
{
    public GameObject soupPrefab;
    public GameObject emptyPotPrefab;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Ontrigger");
        if (other.CompareTag("Bowl"))
        {
            Debug.Log("Plating soup");
            PlateSoup(other);
        }
    }

    private void PlateSoup(Collider other)
    {
        Vector3 position = other.transform.position;
        Quaternion rotation = other.transform.rotation;
        GameObject soup = Instantiate(soupPrefab, position, rotation);
        Instantiate(emptyPotPrefab, this.transform.position, this.transform.rotation);
        Destroy(other.gameObject);
        Destroy(this.gameObject);
    }
}
