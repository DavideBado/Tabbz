using System;
using UnityEngine.EventSystems;

namespace Tabboz_3D
{
    public class MyBuyButton3D : MyButtonBase3D
    {
        MyBuyButton3DData myBuyButton3DData;
        #region Actions
        public Action AddToCart;
        #endregion

        protected override void Awake()
        {
            myBuyButton3DData = GetComponent<MyBuyButton3DData>();
        }
        public override void OnPointerClick(PointerEventData eventData)
        {
            AddToCart?.Invoke();
            base.OnPointerClick(eventData);
            foreach (MyBuyButton3DData.MyItemDelegate _itemDelegate in myBuyButton3DData.MyItemDelegates)
            {
                _itemDelegate(myBuyButton3DData.Item);
            }
        }
    }
}