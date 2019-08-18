using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bado_City
{
    public class ButtonData : MonoBehaviour
    {
        public List<Action> OnClickActions = new List<Action>();
        public List<StatesActions> MyActions = new List<StatesActions>();

        private void Start()
        {
            SetOnClickAction();
        }

        /// <summary>
        /// Non potendo mettere a inspector le action non di unity ho optato per uno switch
        /// </summary>
        private void SetOnClickAction()
        {
            foreach (StatesActions _action in MyActions)
            {
                switch (_action)
                {
                    case StatesActions.ActToTabbozMenu:
                        OnClickActions.Add(GameManager.MyGameManager.GoToTabbozMenu);
                        break;
                    case StatesActions.ActToShops:

                        OnClickActions.Add(GameManager.MyGameManager.GoToShops);
                        break;
                    case StatesActions.ActToWork:

                        OnClickActions.Add(GameManager.MyGameManager.GoToWork);
                        break;
                    case StatesActions.ActToSchool:

                        OnClickActions.Add(GameManager.MyGameManager.GoToSchool);
                        break;
                    case StatesActions.ActToFriends:

                        OnClickActions.Add(GameManager.MyGameManager.GoToFriends);
                        break;
                    case StatesActions.ActToDisco:

                        OnClickActions.Add(GameManager.MyGameManager.GoToDisco);
                        break;
                    case StatesActions.ActToGirlfriend:

                        OnClickActions.Add(GameManager.MyGameManager.GoToGirlfriend);
                        break;
                    case StatesActions.ActToCallFriends:

                        OnClickActions.Add(GameManager.MyGameManager.GoToCallFriends);
                        break;
                    case StatesActions.ActToOutWtYrFriends:

                        OnClickActions.Add(GameManager.MyGameManager.GoToOutWtYrFriends);
                        break;
                    case StatesActions.ActToRace:

                        OnClickActions.Add(GameManager.MyGameManager.GoToRace);
                        break;
                    case StatesActions.ActToOutWtYrGf:

                        OnClickActions.Add(GameManager.MyGameManager.GoToOutWtYrGf);
                        break;
                    case StatesActions.ActToCallYrGf:

                        OnClickActions.Add(GameManager.MyGameManager.GoToCallYrGf);
                        break;
                    case StatesActions.ActToLeaveGf:

                        OnClickActions.Add(GameManager.MyGameManager.GoToLeaveGf);
                        break;
                    case StatesActions.ActToLkngForGirlfriend:

                        OnClickActions.Add(GameManager.MyGameManager.GoToLkngForGirlfriend);
                        break;
                    default:
                        break;
                }
            }
        }

        public enum StatesActions
        {
            ActToTabbozMenu,
            ActToShops,
            ActToWork,
            ActToSchool,
            ActToFriends,
            ActToDisco,
            ActToGirlfriend,
            ActToCallFriends,
            ActToOutWtYrFriends,
            ActToRace,
            ActToOutWtYrGf,
            ActToCallYrGf,
            ActToLeaveGf,
            ActToLkngForGirlfriend
        }
    }
}
