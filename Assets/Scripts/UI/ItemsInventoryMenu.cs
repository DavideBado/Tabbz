using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tabboz_Base;

namespace Tabboz_3D
{
    public class ItemsInventoryMenu : MonoBehaviour, IItemsMenu
    {
        public ItemsType MenuItemsType;
        public GameObject m_panel;
        public GameObject m_content;
        public GameObject m_itemPrefab;
        private List<ISaleable> m_items = new List<ISaleable>();

        public GameObject Panel { get { return m_panel; } }
        public GameObject Content { get { return m_content; } }
        public GameObject ItemPrefab { get { return m_itemPrefab; } }
        public List<ISaleable> Items { get { return m_items; } }

        public void UpdateItems(ISaleable _item)
        {
            m_items.Clear();
            switch (MenuItemsType)
            {
                case ItemsType.MotorBikes:
                    if (_item is BikesConfigData)
                    {
                        GameObject _newItemInfo = Instantiate(ItemPrefab, Content.transform);
                        ItemInventoryInfoData InfoData = _newItemInfo.GetComponent<ItemInventoryInfoData>();
                        InfoData.Setup(_item);
                        m_items.Add(_newItemInfo.GetComponent<ISaleable>());
                    }
                    break;
                case ItemsType.Clothes:
                   if(_item is ClothesConfigData)
                    {
                        GameObject _newItemInfo = Instantiate(ItemPrefab, Content.transform);
                        ItemInventoryInfoData InfoData = _newItemInfo.GetComponent<ItemInventoryInfoData>();
                        InfoData.Setup(_item);
                        m_items.Add(_newItemInfo.GetComponent<ISaleable>());
                    }
                    break;
                case ItemsType.Cigarettes:
                    if (_item is CigarettesConfigData)
                    {
                        GameObject _newItemInfo = Instantiate(ItemPrefab, Content.transform);
                        ItemInventoryInfoData InfoData = _newItemInfo.GetComponent<ItemInventoryInfoData>();
                        InfoData.Setup(_item);
                        m_items.Add(_newItemInfo.GetComponent<ISaleable>());
                    }
                    break;
                case ItemsType.Gasha:
                    break;
                default:
                    break;
            }
        }

        public enum ItemsType
        {
            MotorBikes,
            Clothes,
            Cigarettes,
            Gasha
        }
    }
}