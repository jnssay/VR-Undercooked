using System.Collections;
using UnityEngine;

public class Fridge : MonoBehaviour
{
    public GameObject foodPrefab;
    private string targetComponentTag;
    private bool foodOnFridge = true;
    private Vector3 spawnPosition;
    private Quaternion spawnRotation;
    public float spawnWaitTime = 2f;
    public bool useManualPosition = false;
    public Vector3 manualSpawnPosition;

    void Awake()
    {
        targetComponentTag = foodPrefab.tag;

        // Store the spawn position slightly above the fridge
        if (useManualPosition)
            spawnPosition = manualSpawnPosition;
        else
            spawnPosition = transform.position + Vector3.up * 3f + Vector3.forward * 0.6f + Vector3.left * 0.5f; // Adjust the offset as needed

        spawnRotation = transform.rotation;
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the exiting object has the target component tag
        if (other.CompareTag(targetComponentTag))
        {
            Debug.Log("Food has been removed from the fridge: " + other.name);
            foodOnFridge = false;

            StartCoroutine(WaitAndInstantiateFood());
        }
    }

    private IEnumerator WaitAndInstantiateFood()
    {
        // Wait for 2 seconds
        yield return new WaitForSeconds(spawnWaitTime);

        // Check again if the food is still not on the fridge
        if (!foodOnFridge)
        {
            Debug.Log("Spawning food");
            Instantiate(foodPrefab, spawnPosition, spawnRotation);
            foodOnFridge = true;
        }
    }
}
