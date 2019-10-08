using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tabboz_Base;

namespace Tabboz_3D
{
    public class ShopBase : Selectable
    {
        [HideInInspector]
        public bool IsOpen;
        public MeshRenderer OpnClsPanel;
        public Shop3DConfigData ShopData;
        public TimeManager timeManager;
        public DayManager dayManager;
        public List<MeshRenderer> SelectableObjects = new List<MeshRenderer>();
        public List<ISaleable> Cart = new List<ISaleable>();
        //#region DelegatesDef
        //public delegate void MyBuyDelegate(ISaleable _saleable);
        //#endregion

        //#region Delegates
        //MyBuyDelegate BuyNow;
        //#endregion

        #region Actions
        public Action CheckOutCart; 
        #endregion
        private void OnEnable()
        {
            timeManager.UpdateTime1h += OpenCheck;
            CheckOutCart += CheckOutNow;
        }

        private void OnDisable()
        {
            timeManager.UpdateTime1h -= OpenCheck;
            CheckOutCart -= CheckOutNow;
        }
        private void OpenCheck()
        {
            if (ShopData != null)
            {
                foreach (int _day in ShopData.WorkingDays)
                {
                    if (_day == (dayManager.currentWeekDay))
                    {
                        if (timeManager._Hours >= ShopData.OpeningTime && timeManager._Hours < ShopData.ClosingTime)
                        {
                            IsOpen = true;
                        }
                        else IsOpen = false;
                        SetThePanel(IsOpen);
                        return;
                    }
                }
                IsOpen = false;
                SetThePanel(IsOpen);
            }
        }

        private void SetThePanel(bool Open)
        {
            if (OpnClsPanel != null)
            {
                if (Open)
                    OpnClsPanel.material.color = Color.green;
                else
                    OpnClsPanel.material.color = Color.red;
            }
        }
        
        private void CheckOutNow()
        {
            Tabboz3D m_tabboz = GameManager3D.instance.tabboz;
            int Tot = 0;
            foreach (ISaleable _item in Cart)
            {
                Tot += _item.Price;
            }
            if(m_tabboz.Money >= Tot)
            {
                m_tabboz.Money -= Tot;
            }
        }
    }
}