using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponItemUI : MonoBehaviour
{
    [SerializeField] TMP_Text GunNameText;
    [SerializeField] TMP_Text AmountText;
    [SerializeField] Image GunImage;
    [SerializeField] Button EquipButton;

    GunSlot Data;
    WeaponStorageUI StorageUI;

    public void load(GunSlot Input, WeaponStorageUI parentUI)
    {
        Data = Input;
        StorageUI = parentUI;

        if (GunNameText != null)
            GunNameText.text = Data.Gun.GunName;

        if (AmountText != null)
            AmountText.text = "x" + Data.Amount;

        if (GunImage != null)
            GunImage.sprite = Data.Gun.GunImage;

        if (EquipButton != null)
        {
            EquipButton.interactable = Data.Amount > 0;
            EquipButton.onClick.AddListener(() => StorageUI.OpenEquipPanel(Data));
        }
    }
}
