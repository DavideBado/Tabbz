using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tabboz_3D
{
    public class MyBuyButton3DData : MyButton3DBaseData
    {
        protected ShopBase m_shop;
        [HideInInspector]
        public ISaleable Item;
        public List<Actions> MyActions = new List<Actions>();
        public List<MyItemDelegate> MyItemDelegates = new List<MyItemDelegate>();
        protected MyBuyButton3D myBuyButton3D;

        #region DelegatesDef
        public delegate void MyItemDelegate(ISaleable _item);
        #endregion

        #region Delegates
        MyItemDelegate UpdateItems;
        #endregion

        private void OnDisable()
        {
            myBuyButton3D.AddToCart -= AddToCart;
            UpdateItems -= GameManager3D.instance.uIManager.UpdateItemsInMenu;
        }
        public override void SetOnClickAction()
        {
            foreach (Actions _action in MyActions)
            {
                switch (_action)
                {
                    case Actions.Buy:
                        OnClickActions.Add(m_shop.CheckOutCart);
                        break;
                    default:
                        break;
                }
            }
            MyItemDelegates.Add(UpdateItems); //Da spostare #####################################
        }
        public enum Actions
        {
            Buy
        }

        public void SetupButtonData(ShopBase _shop, ISaleable _item, MyBuyButton3D _buyButton)
        {
            m_shop = _shop;
            Item = _item;
            myBuyButton3D = _buyButton;
            ActionsSub();
            DelegatesSub();
            SetOnClickAction();
        }

        private void AddToCart()
        {
            m_shop.Cart.Add(Item);
        }
        private void ActionsSub()
        {
            myBuyButton3D.AddToCart += AddToCart;
        }
        private void DelegatesSub()
        {
            UpdateItems += GameManager3D.instance.uIManager.UpdateItemsInMenu;
        }

    }
}