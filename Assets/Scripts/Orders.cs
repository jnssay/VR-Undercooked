using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Orders : MonoBehaviour
{
    public GameObject itemPrefab;
    public Transform contentPanel;
    public List<ItemData> itemList = new List<ItemData>();
    public float countdown = 30f;

    void Start()
    {

        UpdateListDisplay();
    }

    void Update()
    {
        AddItem(Random.Range(0, 2) == 0 ? "Burger" : "Soup");
    }

    public void UpdateListDisplay()
    {

        foreach (Transform child in contentPanel)
        {
            Destroy(child.gameObject);
        }


        foreach (var itemData in itemList)
        {
            GameObject newItem = Instantiate(itemPrefab, contentPanel);
            TextMeshProUGUI itemText = newItem.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI timerText = newItem.transform.Find("Text (TMP) (1)").GetComponent<TextMeshProUGUI>();

            itemText.text = itemData.itemName;
            timerText.text = $"Time: {itemData.timeRemaining}s";

            StartCoroutine(StartTimer(itemData, timerText));
        }
    }

    public void AddItem(string newItem)
    {
        if (itemList.Count < 5)
        {
            ItemData newItemData = new ItemData(newItem, countdown);
            itemList.Add(newItemData);
            UpdateListDisplay();
        }
    }

    public void ClearAllItems()
    {
        itemList.Clear();
        UpdateListDisplay();
    }

    private IEnumerator StartTimer(ItemData itemData, TextMeshProUGUI timerText)
    {
        while (itemData.timeRemaining > 0)
        {
            itemData.timeRemaining -= Time.deltaTime;
            timerText.text = $"Time: {Mathf.Ceil(itemData.timeRemaining)}s";
            yield return null;
        }

        timerText.text = "Time's up!";
        yield return new WaitForSeconds(2f);
        itemList.Remove(itemData);
    }


    public class ItemData
    {
        public string itemName;
        public float timeRemaining;

        public ItemData(string name, float time)
        {
            itemName = name;
            timeRemaining = time;
        }
    }


    



}
