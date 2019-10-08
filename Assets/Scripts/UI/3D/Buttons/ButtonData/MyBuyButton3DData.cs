using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tabboz_3D
{
    public class MyBuyButton3DData : MyButton3DBaseData
    {
        protected ShopBase m_shop;
        protected ISaleable Item;
        public List<Actions> MyActions = new List<Actions>();
        protected MyBuyButton3D myBuyButton3D;
        private void OnDisable()
        {
            myBuyButton3D.AddToCart -= AddToCart;
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
    }
}