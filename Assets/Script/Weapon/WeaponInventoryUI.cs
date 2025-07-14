using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class WeaponInventoryUI : MonoBehaviour
{
    public Transform gunTabContent;           // Kéo GunTabContent vào đây
    public GameObject weaponItemPrefab;       // Kéo WeaponItemUI.prefab vào đây

    [System.Serializable]
    public class WeaponData
    {
        public string name;
        public Sprite sprite;
        public int quantity;
    }
    public List<WeaponData> gunList;          // Điền data vũ khí mẫu

    void Start()
    {
        foreach (Transform child in gunTabContent)
            Destroy(child.gameObject);

        foreach (var data in gunList)
        {
            var item = Instantiate(weaponItemPrefab, gunTabContent);
            item.transform.Find("Image").GetComponent<Image>().sprite = data.sprite;
            item.transform.Find("Text (TMP)").GetComponent<TMP_Text>().text = data.name;
            item.transform.Find("Quality").GetComponent<TMP_Text>().text = "x" + data.quantity;

        }
    }
}
