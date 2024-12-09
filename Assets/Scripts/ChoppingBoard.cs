using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoppingBoard : MonoBehaviour
{
    public GameObject choppedMeatPrefab;
    // Dictionary to map tags to their respective chopped prefabs
    public Dictionary<string, GameObject> choppedFoodPrefabs = new Dictionary<string, GameObject>();

    void Start()
    {
        choppedFoodPrefabs.Add("UnchoppedMeat", choppedMeatPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        //KillUnchoppedFood();

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
        if (other.tag == "UnchoppedMeat")
        {
            // Start the chopping process
            Debug.Log("Chopping");
            RawMeatControl raw_meat_control = other.gameObject.GetComponent<RawMeatControl>();
            raw_meat_control.is_choppable = true;
        }
    }



    //private IEnumerator ChopFood(GameObject unchoppedFood)
    //{
    //    // Wait for the chopping time to elapse
    //    yield return new WaitForSeconds(choppingTime);

    //    // Get the corresponding chopped prefab based on the tag
    //    GameObject choppedFoodPrefab = choppedFoodPrefabs[unchoppedFood.tag];

    //    // Replace the unchopped food with the chopped version
    //    Vector3 position = unchoppedFood.transform.position;
    //    Quaternion rotation = unchoppedFood.transform.rotation;

    //    // Instantiate the first chopped food at the position of the unchopped food
    //    GameObject choppedFood1 = Instantiate(choppedFoodPrefab, position + new Vector3(-0.1f, 0, 0), rotation);
    //    GameObject choppedFood2 = Instantiate(choppedFoodPrefab, position + new Vector3(0.1f, 0, 0), rotation);

    //    // Apply force to make them fall to the side
    //    Rigidbody rb1 = choppedFood1.GetComponent<Rigidbody>();
    //    if (rb1 != null)
    //    {
    //        rb1.AddForce(new Vector3(-1, 0, 0), ForceMode.Impulse);
    //    }

    //    Rigidbody rb2 = choppedFood2.GetComponent<Rigidbody>();
    //    if (rb2 != null)
    //    {
    //        rb2.AddForce(new Vector3(1, 0, 0), ForceMode.Impulse);
    //    }
    //    // Destroy the unchopped food
    //    Destroy(unchoppedFood);
    //}

}
