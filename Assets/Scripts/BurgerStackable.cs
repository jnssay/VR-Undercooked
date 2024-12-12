using System.Collections;
using System.Collections.Generic;
using Alteruna;
using UnityEngine;

public class BurgerStackable : MonoBehaviour
{
    public GameObject nextBurgerPrefab; // The prefab representing the next burger state
    public int burgerStep; // Current step of this burger piece
    private string burgerStepTag; // Dynamically assigned tag for this step
    private string nextBurgerIngredient; // Expected next ingredient's tag
    public Spawner spawner;

    private void Start()
    {
        // Assign a tag and expected ingredient based on the burgerStep
        switch (burgerStep)
        {
            case 1:
                burgerStepTag = "BurgerStep1";
                nextBurgerIngredient = "BurgerPatty";
                break;
            case 2:
                burgerStepTag = "BurgerStep2";
                nextBurgerIngredient = "BurgerCheese";
                break;
            case 3:
                burgerStepTag = "BurgerStep3";
                nextBurgerIngredient = "BurgerStep1";
                break;
            case 4:
                burgerStepTag = "BurgerPreFinish";
                nextBurgerIngredient = ""; // No further ingredient needed
                break;
            default:
                burgerStepTag = "UnknownStep";
                nextBurgerIngredient = "";
                Debug.LogWarning($"Burger step {burgerStep} is not recognized!");
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the other object matches the expected next ingredient
        if (other.CompareTag(nextBurgerIngredient))
        {
            Debug.Log($"Detected correct ingredient: {nextBurgerIngredient}");
            Debug.Log($"Stacking burger step {burgerStepTag} with {nextBurgerIngredient}");
                StackBurger(other);
        }
        else
        {
            Debug.LogWarning($"Incorrect ingredient detected! Expected: {nextBurgerIngredient}, Got: {other.tag}");
        }
    }

    private void StackBurger(Collider other)
    {
        // Instantiate the next burger state prefab
        Vector3 position = transform.position; // Keep the same position
        Quaternion rotation = transform.rotation; // Keep the same rotation

        // GameObject burger = Instantiate(nextBurgerPrefab, position, rotation);
        GameObject burger = spawner.Spawn(0, position, rotation);

        // Clean up the current and other objects
        Destroy(other.gameObject);
        Destroy(gameObject);

        Debug.Log($"Burger stacked successfully: New prefab ({nextBurgerPrefab.name}) instantiated.");
    }
}
