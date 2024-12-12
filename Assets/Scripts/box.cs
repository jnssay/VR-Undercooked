using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class box : MonoBehaviour
{
    public float BurgerScore = 5.0f;
    public float PlayerScore;
    public float SoupScore = 10.0f;
    public float MissScore = 5.0f;

    private float BurgerTotalScore;
    private float SoupTotalScore;
    private float MissedScore;

    public int completeCount = 0;
    public int missCount = 0;

    public TextMeshProUGUI burgerScoreText;
    public TextMeshProUGUI soupScoreText;
    public TextMeshProUGUI missedScoreText;
    public TextMeshProUGUI totalScoreText;

    private Orders ordersSystem;
    public ADDTOCANNON cannon;

    void Start()
    {
        ordersSystem = FindObjectOfType<Orders>();
    }

    void Update()
    {
        burgerScoreText.text = $"Burger Points: {BurgerTotalScore}";
        soupScoreText.text = $"Soup Points: {SoupTotalScore}";
        missedScoreText.text = $"Missed Points: {MissedScore}";
        totalScoreText.text = $"{PlayerScore}";

        CheckForTimedOutOrders();
    }

    void checkFinishedFood(Collider other)
    {

        string itemTag = other.CompareTag("BurgerFinish") ? "Burger" : other.CompareTag("SoupFinish") ? "Soup" : null;

        if (itemTag != null)
        {
            Orders.ItemData matchedOrder = FindMatchingOrder(itemTag);

            if (matchedOrder != null)
            {
                if (itemTag == "Burger")
                {
                    PlayerScore += (BurgerScore + Mathf.Ceil(matchedOrder.timeRemaining));
                    BurgerTotalScore += (BurgerScore + Mathf.Ceil(matchedOrder.timeRemaining));
                    Debug.Log("Burger Detected! Adding: " + matchedOrder.timeRemaining);
                    completeCount++;
                }
                else if (itemTag == "Soup")
                {
                    PlayerScore += (SoupScore + Mathf.Ceil(matchedOrder.timeRemaining));
                    SoupTotalScore += (SoupScore + Mathf.Ceil(matchedOrder.timeRemaining));
                    Debug.Log("Soup Detected! Adding: " + matchedOrder.timeRemaining);
                    completeCount++;
                }

                Debug.Log(PlayerScore);
                ordersSystem.itemList.Remove(matchedOrder);
                cannon.LaunchFood(other.gameObject);
            }
            else
            {
                MissedScore -= MissScore;
                PlayerScore -= MissScore;
                missCount++;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ENTERED");
        checkFinishedFood(other);
    }

    Orders.ItemData FindMatchingOrder(string itemTag)
    {
        List<Orders.ItemData> matchingOrders = ordersSystem.itemList.FindAll(item => item.itemName == itemTag);
        if (matchingOrders.Count == 0)
        {
            return null;
        }

        matchingOrders.Sort((order1, order2) => order1.timeRemaining.CompareTo(order2.timeRemaining));

        return matchingOrders[0];
    }

    void CheckForTimedOutOrders()
    {
        foreach (var item in ordersSystem.itemList)
        {
            if (item.timeRemaining <= 0)
            {
                MissedScore -= MissScore;
                PlayerScore -= MissScore;
                missCount++;
                Debug.Log($"Missed Order! Deducting: {MissScore}");
                ordersSystem.itemList.Remove(item); 
                break;
            }
        }
    }

}
