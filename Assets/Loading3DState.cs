using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Tabboz_Base;
using Tabboz_3D;

public class Loading3DState : StateMachineBehaviour
{
    LoaderBase loader;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        LoadScene();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        loader.CountinueButton.SetActive(false);
        loader.LoadingPanel.SetActive(false);
    }

    private void LoadScene()
    {
        loader = FindObjectOfType<LoaderBase>();
        loader.LoadingPanel.SetActive(true);
        loader.CountinueButton.SetActive(false);
        if (GameManager3D.instance.CurrentSceneIndex != GameManager3D.instance.NextSceneIndex)
        {
            SceneManager.sceneLoaded += FindLoader;
            SceneManager.LoadScene(GameManager3D.instance.NextSceneIndex);
        }
        else
        {
            loader.SetGameManager();
        }
    }

    void FindLoader(Scene _scene, LoadSceneMode _loadSceneMode)
    {
        loader = FindObjectOfType<LoaderBase>();
        loader.LoadingPanel.SetActive(true);
        loader.CountinueButton.SetActive(false);
        loader.SetGameManager();
        GameManager3D.instance.CurrentSceneIndex = GameManager3D.instance.NextSceneIndex;
        SceneManager.sceneLoaded -= FindLoader;
    }
}