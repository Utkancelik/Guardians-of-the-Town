using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItemGenerator : MonoBehaviour
{
    [SerializeField] private List<GameObject> TurkishItemsPrefab = new List<GameObject>();
    [SerializeField] private List<GameObject> FinnishItemsPrefabs = new List<GameObject>();
    [SerializeField] private List<GameObject> SelectedItems = new List<GameObject>();

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
        for (int i = 0; i < totalMatchCount; i++)
        {
            // 0 ile toplam prefab say�s� (12) ile aras�nda random bir say� belirle
            int randomItem = Random.Range(0, ItemsPrefab.Count);
            // ��kan say� indexindeki objeyi tut
            GameObject selectedItem = ItemsPrefab[randomItem];
            // bu objeyi ilk eleman olarak selected item listesine ekle
            SelectedItems.Add(selectedItem);
            ItemsPrefab.RemoveAt(randomItem);
            // ��kan say�n�n indexinde bulunan prefabin ilk harfini al
            char firstLetter = selectedItem.name[0];
            // ayn� harften bir obje bulana kadar random at
            int randomItemWithSameFirstLetter = Random.Range(0, ItemsPrefab.Count);
            while (ItemsPrefab[randomItemWithSameFirstLetter].name[0] != firstLetter && ItemsPrefab[randomItemWithSameFirstLetter] != selectedItem)
            {
                randomItemWithSameFirstLetter = Random.Range(0, ItemsPrefab.Count);
            }
            GameObject newItemWitheSameFirstLetter = ItemsPrefab[randomItemWithSameFirstLetter];
            SelectedItems.Add(newItemWitheSameFirstLetter);
            ItemsPrefab.RemoveAt(randomItemWithSameFirstLetter);
        }
    }
}
