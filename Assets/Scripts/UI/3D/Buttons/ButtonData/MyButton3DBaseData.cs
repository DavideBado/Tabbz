using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tabboz_3D
{
    public abstract class MyButton3DBaseData : MonoBehaviour
    {
        public List<Action> OnClickActions = new List<Action>();       
        //public List<StatesActions> MyActions = new List<StatesActions>();
               
        //private void Start()
        //{
        //    SetOnClickAction();
        //}

        /// <summary>
        /// Non potendo mettere a inspector le action non di unity ho optato per uno switch
        /// </summary>
        public virtual void SetOnClickAction()
        {
            //foreach (StatesActions _action in MyActions)
            //{
            //    switch (_action)
            //    {
            //        default:
            //            break;
            //    }
            //}
        }

        //public enum StatesActions
        //{

        //}
    }
}
