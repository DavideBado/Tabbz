using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Bado_City;

public class ClothesInfoData : MonoBehaviour
{
    public Image IconImage, NameBackgroundImage, DescriptBackgroundImage, PriceBackgroundImage;
    public TMP_Text NameTxt, DescriptionTxt, PriceTxt;
    [HideInInspector]
    public ClothesConfigData Item;
    public void Setup(ClothesConfigData _item)
    {
        Item = _item;
        IconImage.sprite = _item.Icon;
        NameTxt.text = _item.Name;
        DescriptionTxt.text = _item.Description;
        PriceTxt.text = _item.Price.ToString();
    }
}
