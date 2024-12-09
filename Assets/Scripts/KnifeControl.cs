using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeControl : MonoBehaviour
{
    public GameObject choppedMeatPrefab;
    public Dictionary<string, GameObject> choppedFoodPrefabs = new Dictionary<string, GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        choppedFoodPrefabs.Add("UnchoppedMeat", choppedMeatPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering object has a tag that matches a known unchopped food
        if (other.tag == "UnchoppedMeat")
        {
            // Start the chopping process
            
            RawMeatControl raw_meat_control = other.gameObject.GetComponent<RawMeatControl>();
            // only chop if the game object is choppable
            if (raw_meat_control.is_choppable)
            {
                if (raw_meat_control.current_num_chops >= raw_meat_control.max_num_chops)
                {
                    ChopFood(other.gameObject);
                }
                else
                {
                    raw_meat_control.current_num_chops += 1;
                }
                
                
            }
        }
    }

    private void ChopFood(GameObject unchoppedFood)
    {
        Debug.Log("Chopping");
        // Get the corresponding chopped prefab based on the tag
        GameObject choppedFoodPrefab = choppedFoodPrefabs[unchoppedFood.tag];

        // Replace the unchopped food with the chopped version
        Vector3 position = unchoppedFood.transform.position;
        Quaternion rotation = unchoppedFood.transform.rotation;

        // Instantiate the first chopped food at the position of the unchopped food
        GameObject choppedFood1 = Instantiate(choppedFoodPrefab, position + new Vector3(-0.1f, 0, 0), rotation);
        GameObject choppedFood2 = Instantiate(choppedFoodPrefab, position + new Vector3(0.1f, 0, 0), rotation);

        // Apply force to make them fall to the side
        Rigidbody rb1 = choppedFood1.GetComponent<Rigidbody>();
        if (rb1 != null)
        {
            rb1.AddForce(new Vector3(-1, 0, 0), ForceMode.Impulse);
        }

        Rigidbody rb2 = choppedFood2.GetComponent<Rigidbody>();
        if (rb2 != null)
        {
            rb2.AddForce(new Vector3(1, 0, 0), ForceMode.Impulse);
        }
        // Destroy the unchopped food
        Destroy(unchoppedFood);
    }
}
