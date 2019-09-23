using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Tabboz_Base
{
    public abstract class LoaderBase : MonoBehaviour
    {
        public GameObject LoadingPanel, CountinueButton;

        public virtual void SetGameManager()
        {

        }

        public void OnLoaded()
        {
            if (CountinueButton != null)
                CountinueButton.SetActive(true);
        }
    }
}