using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Tabboz_Base;
using Tabboz_3D;
public class ItemInShopInfoData : ItemInfoDataBase
{
    public TMP_Text PriceTxt;
    public Image PriceBackgroundImage;
    public MyButton3DBaseData BuyButtonData; 
    public MyBuyButton3D BuyButton;
    
    public void Setup(ISaleable _item, ShopBase _shop)
    {
        Item = _item;
        IconImage.sprite = _item.Icon;
        NameTxt.text = _item.Name;
        DescriptionTxt.text = _item.Description();
        PriceTxt.text = _item.Price.ToString();
        BuyButtonData.GetComponent<MyBuyButton3DData>().SetupButtonData(_shop, _item, BuyButton);
    }
}
