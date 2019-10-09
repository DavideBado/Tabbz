public class ItemInventoryInfoData : ItemInfoDataBase
{
    public void Setup(ISaleable _item)
    {
        Item = _item;
        IconImage.sprite = _item.Icon;
        NameTxt.text = _item.Name;
        DescriptionTxt.text = _item.Description();        
    }
}
