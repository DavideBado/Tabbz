using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tabboz_3D
{
    public class ContinueButtonData3D : MyButton3DBaseData
    {
        public List<StatesActions> MyActions = new List<StatesActions>();

        private void Start()
        {
            SetOnClickAction();
        }

        /// <summary>
        /// Non potendo mettere a inspector le action non di unity ho optato per uno switch
        /// </summary>
        public override void SetOnClickAction()
        {
            foreach (StatesActions _action in MyActions)
            {
                switch (_action)
                {
                    case StatesActions.ActStartGame:
                        OnClickActions.Add(GameManager3D.instance.fSMManager.Act_StartGame);
                        break;
                    default:
                        break;
                }
            }
        }

        public enum StatesActions
        {
            ActStartGame,
        }
    }
}