using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoppingBoard : MonoBehaviour
{
    public GameObject choppedMeatPrefab;
    public float choppingTime = 5.0f;
        // Dictionary to map tags to their respective chopped prefabs
    public Dictionary<string, GameObject> choppedFoodPrefabs = new Dictionary<string, GameObject>();

    void Start()
    {
        choppedFoodPrefabs.Add("UnchoppedMeat", choppedMeatPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        KillUnchoppedFood();
        // Chopping logic should be checked here
    }

    private void KillUnchoppedFood()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1f);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("UnchoppedMeat"))
            {
                RaycastHit whatFoodHit;
                if (Physics.Raycast(collider.transform.position, Vector3.up, out whatFoodHit))
                {
                    if (whatFoodHit.collider.CompareTag("Raw-Fry"))
                    {
                        Debug.Log("Unchopped Food still here after cooked food has spawned");
                        Destroy(collider.gameObject);
                    }
                }
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering object has a tag that matches a known unchopped food
        if (choppedFoodPrefabs.ContainsKey(other.tag))
        {
            // Start the chopping process
            StartCoroutine(ChopFood(other.gameObject));
        }
    }


    private IEnumerator ChopFood(GameObject unchoppedFood)
    {
        // Wait for the chopping time to elapse
        yield return new WaitForSeconds(choppingTime);

        // Get the corresponding chopped prefab based on the tag
        GameObject choppedFoodPrefab = choppedFoodPrefabs[unchoppedFood.tag];

        // Replace the unchopped food with the chopped version
        Vector3 position = unchoppedFood.transform.position;
        Quaternion rotation = unchoppedFood.transform.rotation;

        // Instantiate the chopped food at the position of the unchopped food
        Instantiate(choppedFoodPrefab, position, rotation);

        // Destroy the unchopped food
        Destroy(unchoppedFood);
    }
}
