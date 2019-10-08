using System;
using UnityEngine.EventSystems;

namespace Tabboz_3D
{
    public class MyBuyButton3D : MyButtonBase3D
    {
        #region Actions
        public Action AddToCart;
        #endregion
        public override void OnPointerClick(PointerEventData eventData)
        {
            AddToCart?.Invoke();
            base.OnPointerClick(eventData);
        }
    }
}