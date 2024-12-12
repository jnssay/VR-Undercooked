using System.Collections;
using System.Collections.Generic;
using Alteruna;
using UnityEngine;

public class PreCookSoup : MonoBehaviour
{
    public GameObject preFinishSoupPrefab;
    public float cookingTime = 1.0f;
    public string targetComponentTag = "Stove";
    private bool readyToCook = false;
    private Coroutine cookingCoroutine;
    public Spawner spawner;

    void Start()
    {
        // Optionally, initialize any variables or states here
    }

    void Update()
    {
        CheckIfOnTargetComponent();
    }

    private void CheckIfOnTargetComponent()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            // Check if the hit object has the target component tag
            if (hit.collider.CompareTag(targetComponentTag))
            {
                Debug.Log("Pot is on stove");
                if (!readyToCook)
                {
                    readyToCook = true;
                    Debug.Log("Cooking");

                    // Start the cooking coroutine
                    cookingCoroutine = StartCoroutine(CookSoup());
                }
            }
            else
            {
                readyToCook = false;
                if (cookingCoroutine != null)
                {
                    StopCoroutine(cookingCoroutine);
                    cookingCoroutine = null;
                }
            }
        }
        else
        {
            readyToCook = false;
            if (cookingCoroutine != null)
            {
                StopCoroutine(cookingCoroutine);
                cookingCoroutine = null;
            }
        }
    }

    private IEnumerator CookSoup()
    {
        // float elapsedTime = 0f;

        // while (elapsedTime < cookingTime)
        // {
        //     if (!readyToCook)
        //     {
        //         Debug.Log("Cooking stopped as taken out midway");
        //         yield break;
        //     }

        //     Debug.Log("elapsedTime"+ elapsedTime);
        //     elapsedTime += Time.deltaTime;
        //     yield return null;
        // }

        yield return new WaitForSeconds(cookingTime);
        spawner.Spawn(0, transform.position, transform.rotation);
        // Instantiate(preFinishSoupPrefab, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
