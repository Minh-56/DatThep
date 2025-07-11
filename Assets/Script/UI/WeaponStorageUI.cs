using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class WeaponStorageUI : MonoBehaviour
{
    [SerializeField] Transform GunContent;
    [SerializeField] GameObject GunItemPrefab;

    [SerializeField] GameObject EquipPanel;
    [SerializeField] TMP_Text EquipGunName;
    [SerializeField] TMP_InputField InputAmmo;
    [SerializeField] Button ConfirmButton;

    WeaponStorage kho;
    GunSlot selectedGun;

    void Start()
    {
        kho = Object.FindFirstObjectByType<WeaponStorage>();
        RefreshGunList();
        EquipPanel.SetActive(false);
    }

    public void RefreshGunList()
    {
        foreach (Transform child in GunContent)
            Destroy(child.gameObject);

        foreach (var slot in kho.GunList)
        {
            var go = Instantiate(GunItemPrefab, GunContent);
            var ui = go.GetComponent<WeaponItemUI>();
            ui.load(slot, this);
        }
    }

    public void OpenEquipPanel(GunSlot Data)
    {
        selectedGun = Data;
        EquipPanel.SetActive(true);
        EquipGunName.text = Data.Gun.GunName;
        InputAmmo.text = "0";
        ConfirmButton.onClick.RemoveAllListeners();
        ConfirmButton.onClick.AddListener(() => ChooseUnit());
    }

    void ChooseUnit()
    {
        EquipPanel.SetActive(false);
        this.gameObject.SetActive(false); // ẩn UI kho

        WeaponEquipManager equipSystem = Object.FindFirstObjectByType<WeaponEquipManager>();
        if (equipSystem != null)
        {
            int AmmoNum = int.TryParse(InputAmmo.text, out int Num) ? Num : 0;
            equipSystem.StartEquipMode(selectedGun.Gun, AmmoNum);
        }
    }
    //đóng panle của kho vũ khí
    public void ClosePanel()
    {
        this.gameObject.SetActive(false);
    }
}
