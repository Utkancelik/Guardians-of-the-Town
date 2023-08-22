using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class RandomItemGenerator : MonoBehaviour
{
    [SerializeField] private List<GameObject> TurkishItemsPrefab = new List<GameObject>();
    [SerializeField] private List<GameObject> FinnishItemsPrefabs = new List<GameObject>();
    [SerializeField] private List<GameObject> SelectedItems = new List<GameObject>();
    [SerializeField] private List<GameObject> ItemSlots = new List<GameObject>();


    [SerializeField] private int totalMatchCount = 4;
    private void Start()
    {
        string language = PlayerPrefs.GetString("Language");

        if (language == "Turkish")
        {
            ChooseRandomItems(TurkishItemsPrefab);
        }
        else if (language == "Finnish")
        {
            ChooseRandomItems(FinnishItemsPrefabs);
        }

        
    }
    private void ChooseRandomItems(List<GameObject> ItemsPrefab)
    {
        switch (MillGameManager.Instance.millGameMode)
        {
            case MillGameModes.FirstLetter:
                ChooseRandomItems_FirstLetterGame(ItemsPrefab);
                break;
            case MillGameModes.LastLetter:
                ChooseRandomItems_LastLetterGame(ItemsPrefab);
                break;
            case MillGameModes.Rhyme:
                ChooseRandomItems_RhymeGame(ItemsPrefab);
                break;
            default:
                break;
        }

        AddingRandomSelectedItemsToItemSlotsRandomly();
    }
    private void ChooseRandomItems_FirstLetterGame(List<GameObject> ItemsPrefab)
    {
        for (int i = 0; i < totalMatchCount; i++)
        {
            // 0 ile toplam prefab sayýsý (12) ile arasýnda random bir sayý belirle
            int randomItem = Random.Range(0, ItemsPrefab.Count);
            // çýkan sayý indexindeki objeyi tut
            GameObject selectedItem = Instantiate(ItemsPrefab[randomItem]);
            // bu objeyi ilk eleman olarak selected item listesine ekle
            SelectedItems.Add(selectedItem);
            ItemsPrefab.RemoveAt(randomItem);
            // çýkan sayýnýn indexinde bulunan prefabin ilk harfini al
            char firstLetter = selectedItem.name[0];
            // ayný harften bir obje bulana kadar random at
            int randomItemWithSameFirstLetter = Random.Range(0, ItemsPrefab.Count);
            while (ItemsPrefab[randomItemWithSameFirstLetter].name[0] != firstLetter)
            {
                randomItemWithSameFirstLetter = Random.Range(0, ItemsPrefab.Count);
            }
            GameObject newItemWitheSameFirstLetter = Instantiate(ItemsPrefab[randomItemWithSameFirstLetter]);
            SelectedItems.Add(newItemWitheSameFirstLetter);
            ItemsPrefab.RemoveAt(randomItemWithSameFirstLetter);
        }
    }

    private void ChooseRandomItems_LastLetterGame(List<GameObject> ItemsPrefab)
    {
        for (int i = 0; i < totalMatchCount; i++)
        {
            // 0 ile toplam prefab sayýsý (12) ile arasýnda random bir sayý belirle
            int randomItem = Random.Range(0, ItemsPrefab.Count);
            // çýkan sayý indexindeki objeyi tut
            GameObject selectedItem = Instantiate(ItemsPrefab[randomItem]);
            // bu objeyi ilk eleman olarak selected item listesine ekle
            SelectedItems.Add(selectedItem);
            ItemsPrefab.RemoveAt(randomItem);
            // çýkan sayýnýn indexinde bulunan prefabin ilk harfini al
            char lastLetter = selectedItem.name[^8];
            // ayný harften bir obje bulana kadar random at
            int randomItemWithSameLastLetter = Random.Range(0, ItemsPrefab.Count);
            while (ItemsPrefab[randomItemWithSameLastLetter].name[^1] != lastLetter)
            {
                randomItemWithSameLastLetter = Random.Range(0, ItemsPrefab.Count);
            }
            GameObject newItemWitheSameLastLetter = Instantiate(ItemsPrefab[randomItemWithSameLastLetter]);
            SelectedItems.Add(newItemWitheSameLastLetter);
            ItemsPrefab.RemoveAt(randomItemWithSameLastLetter);
        }
    }

    private void ChooseRandomItems_RhymeGame(List<GameObject> ItemsPrefab)
    {
        for (int i = 0; i < totalMatchCount; i++)
        {
            // 0 ile toplam prefab sayýsý (12) ile arasýnda random bir sayý belirle
            int randomItem = Random.Range(0, ItemsPrefab.Count);
            // çýkan sayý indexindeki objeyi tut
            GameObject selectedItem = Instantiate(ItemsPrefab[randomItem]);
            // bu objeyi ilk eleman olarak selected item listesine ekle
            SelectedItems.Add(selectedItem);
            ItemsPrefab.RemoveAt(randomItem);
            // çýkan sayýnýn indexinde bulunan prefabin ilk harfini al
            char firstLetter = selectedItem.name[0];
            // ayný harften bir obje bulana kadar random at
            int randomItemWithSameFirstLetter = Random.Range(0, ItemsPrefab.Count);
            while (ItemsPrefab[randomItemWithSameFirstLetter].name[0] != firstLetter && ItemsPrefab[randomItemWithSameFirstLetter] != selectedItem)
            {
                randomItemWithSameFirstLetter = Random.Range(0, ItemsPrefab.Count);
            }
            GameObject newItemWitheSameFirstLetter = Instantiate(ItemsPrefab[randomItemWithSameFirstLetter]);
            SelectedItems.Add(newItemWitheSameFirstLetter);
            ItemsPrefab.RemoveAt(randomItemWithSameFirstLetter);
        }
    }

    private void AddingRandomSelectedItemsToItemSlotsRandomly()
    {
        for (int i = 0; i < ItemSlots.Count; i++)
        {
            int random = Random.Range(0, SelectedItems.Count);

            GameObject randomSelectedItem = SelectedItems[random];

            randomSelectedItem.transform.SetParent(ItemSlots[i].transform);
            randomSelectedItem.GetComponent<DraggableItem>().originalParent = ItemSlots[i].transform;

            SelectedItems.RemoveAt(random);
        }
    }
}
