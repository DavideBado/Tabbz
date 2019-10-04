using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Tabboz_Base
{/// <summary>
/// Classe comune a tutti i loader
/// </summary>
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