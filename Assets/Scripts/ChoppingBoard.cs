using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoppingBoard : MonoBehaviour
{
    public GameObject choppedMeatPrefab;
    public GameObject choppedCheesePrefab;
    // Dictionary to map tags to their respective chopped prefabs
    public Dictionary<string, GameObject> choppedFoodPrefabs = new Dictionary<string, GameObject>();
    public NumChopsBarControl num_chops_bar_control;
    public GameObject num_chops_bar;

    void Start()
    {
        choppedFoodPrefabs.Add("UnchoppedMeat", choppedMeatPrefab);
        choppedFoodPrefabs.Add("UnchoppedCheese", choppedCheesePrefab);
    }

    // Update is called once per frame
    void Update()
    {
        //KillUnchoppedFood();

    }

    //private void KillUnchoppedFood()
    //{
    //    Collider[] colliders = Physics.OverlapSphere(transform.position, 1f);
    //    foreach (Collider collider in colliders)
    //    {
    //        if (collider.CompareTag("UnchoppedMeat"))
    //        {
    //            RaycastHit whatFoodHit;
    //            if (Physics.Raycast(collider.transform.position, Vector3.up, out whatFoodHit))
    //            {
    //                if (whatFoodHit.collider.CompareTag("Raw-Fry"))
    //                {
    //                    Debug.Log("Unchopped Food still here after cooked food has spawned");
    //                    Destroy(collider.gameObject);
    //                }
    //            }
    //        }
    //    }
    //}


    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering object has a tag that matches a known unchopped food
        if (other.tag == "UnchoppedMeat" || other.tag == "UnchoppedCheese")
        {
            // Start the chopping process
            Debug.Log("Chopping");
            RawFoodControl raw_food_control = other.gameObject.GetComponent<RawFoodControl>();
            raw_food_control.is_choppable = true;
            num_chops_bar.SetActive(true);
            if (raw_food_control.current_num_chops != 0)
            {
                Debug.Log("changing value!");
                num_chops_bar_control.hp_slider.value = raw_food_control.max_num_chops - raw_food_control.current_num_chops;
            }
            else
            {
                Debug.Log("setting value!");
                num_chops_bar_control.hp_slider.maxValue = raw_food_control.max_num_chops;
                num_chops_bar_control.hp_slider.value = num_chops_bar_control.hp_slider.maxValue;
            }


        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "UnchoppedMeat" || other.tag == "UnchoppedCheese")
        {
            // Start the chopping process
            Debug.Log("Chopping");
            RawFoodControl raw_food_control = other.gameObject.GetComponent<RawFoodControl>();
            raw_food_control.is_choppable = true;
            num_chops_bar.SetActive(true);
            if (raw_food_control.current_num_chops != 0)
            {
                Debug.Log("changing value!");
                num_chops_bar_control.hp_slider.value = raw_food_control.max_num_chops - raw_food_control.current_num_chops;
            }
            else
            {
                Debug.Log("setting value!");
                num_chops_bar_control.hp_slider.maxValue = raw_food_control.max_num_chops;
                num_chops_bar_control.hp_slider.value = num_chops_bar_control.hp_slider.maxValue;
            }


        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.tag == "UnchoppedMeat" || other.tag == "UnchoppedCheese")
        {

            RawFoodControl raw_food_control = other.gameObject.GetComponent<RawFoodControl>();
            raw_food_control.is_choppable = false;
            num_chops_bar.SetActive(false);
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
