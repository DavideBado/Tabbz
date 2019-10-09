using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        public void UpdateItems()
        {
            m_items.Clear();
            switch (MenuItemsType)
            {
                case ItemsType.MotorBikes:
                    foreach (ISaleable _item in GameManager3D.instance.tabboz.MyBikes)
                    {
                        m_items.Add(_item);
                    }
                    break;
                case ItemsType.Clothes:
                    foreach (ISaleable _item in GameManager3D.instance.tabboz.MyClothes)
                    {
                        m_items.Add(_item);
                    }
                    break;
                case ItemsType.Cigarettes:
                    foreach (ISaleable _item in GameManager3D.instance.tabboz.MyCigarettes)
                    {
                        m_items.Add(_item);
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