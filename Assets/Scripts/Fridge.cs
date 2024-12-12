using UnityEngine;
using Alteruna;
using System.Collections;

public class Fridge : MonoBehaviour
{
    public GameObject foodPrefab;
    private string targetComponentTag;
    public bool foodOnFridge = true;
    private Vector3 spawnPosition;
    private Quaternion spawnRotation;
    public float spawnWaitTime = 2f;
    public bool useManualPosition = false;
    public Vector3 manualSpawnPosition;
    public Spawner spawner;
    public float spawnDistance = -1.0f;

    private Coroutine spawnRoutine;

    void Awake()
    {
        targetComponentTag = foodPrefab.tag;

        // Store the spawn position slightly above the fridge
        if (useManualPosition)
        {
            spawnPosition = manualSpawnPosition;
        }
        else
        {
            spawnPosition = transform.position;
            spawnRotation = transform.rotation;
        }

        // SpawnFirstFood();
    }

    // private void OnTriggerExit(Collider other)
    // {
    //     if (other.CompareTag(targetComponentTag))
    //     {
    //         Debug.Log("Food removed from fridge: " + other.name);
    //         foodOnFridge = false;

    //         // Start the delayed spawn only if not already running
    //         if (spawnRoutine != null)
    //         {
    //             StopCoroutine(spawnRoutine);
    //         }
    //         spawnRoutine = StartCoroutine(WaitAndSpawnFood());
    //     }
    // }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag(targetComponentTag))
    //     {
    //         // Food is placed back before spawning new one
    //         Debug.Log("Food placed back on fridge: " + other.name);
    //         foodOnFridge = true;

    //         // If we were waiting to spawn a new one, cancel that
    //         if (spawnRoutine != null)
    //         {
    //             StopCoroutine(spawnRoutine);
    //             spawnRoutine = null;
    //         }
    //     }
    // }

    private IEnumerator WaitAndSpawnFood()
    {
        yield return new WaitForSeconds(spawnWaitTime);

        // Check again if no food is on the fridge
        if (!foodOnFridge)
        {
            SpawnFood();
            foodOnFridge = true;
        }

        spawnRoutine = null;
    }

    public void SpawnFood()
    {
        spawner.Spawn(0, spawnPosition, spawnRotation);
    }

    void SpawnFirstFood()
    {
        spawner.Spawn(0, spawnPosition, spawnRotation);
    }
}
