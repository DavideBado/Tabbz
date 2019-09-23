using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
namespace Tabboz_Base
{
    public class LoadSceneButton : MyButtonBase
    {        
        public override void OnPointerClick(PointerEventData eventData)
        {
            GameManager.MyGameManager.NextSceneIndex = GetComponent<LoadSceneButtonData>().SceneIndex; // Da sostituire con MySceneManager
            base.OnPointerClick(eventData);
        }
    }
}
