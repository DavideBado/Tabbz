using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Tabboz_Base;

public class LoadingState : StateMachineBehaviour
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
        if (GameManager.MyGameManager.CurrentSceneIndex != GameManager.MyGameManager.NextSceneIndex)
        {
            SceneManager.sceneLoaded += FindLoader;
            SceneManager.LoadScene(GameManager.MyGameManager.NextSceneIndex);
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
        GameManager.MyGameManager.CurrentSceneIndex = GameManager.MyGameManager.NextSceneIndex;
        SceneManager.sceneLoaded -= FindLoader;
    }
}
