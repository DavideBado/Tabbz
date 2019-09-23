using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tabboz_Base;

public class EnterTheClothesSState : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameManager.MyGameManager.ClothesSIn.SetActive(true);
        Debug.Log(GameManager.MyGameManager.ClothesShop.Name);
        ItemsMenuGen();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameManager.MyGameManager.ClothesSIn.SetActive(false);
    }
    
    private void ItemsMenuGen()
    {
        GameObject _itemsMenu = GameManager.MyGameManager.ClothesSIn.GetComponent<ShopPanelData>().ItemsMenu;
        GameObject _itemsInfoPref = GameManager.MyGameManager.ClothesSIn.GetComponent<ShopPanelData>().ItemsInfoPref;
        GameObject _content = _itemsMenu.GetComponent<ScrollRect>().content.gameObject;
        foreach (ClothesConfigData _cloth in GameManager.MyGameManager.ClothesShop.Clothings)
        {
            GameObject itemInfoInsta = Instantiate(_itemsInfoPref, _content.transform);
            itemInfoInsta.GetComponent<ClothesInfoData>().IconImage.sprite = _cloth.Icon;
            //itemInfoInsta.GetComponent<ClothesInfoData>().NameBackgroundImage.sprite = _clothing...;
            //itemInfoInsta.GetComponent<ClothesInfoData>().DescriptBackgroundImage.sprite = _clothing.....;
            //itemInfoInsta.GetComponent<ClothesInfoData>().PriceBackgroundImage.sprite = _clothing.....;
            itemInfoInsta.GetComponent<ClothesInfoData>().NameTxt.text = _cloth.Name;
            itemInfoInsta.GetComponent<ClothesInfoData>().DescriptionTxt.text = _cloth.Description;
            itemInfoInsta.GetComponent<ClothesInfoData>().PriceTxt.text = (_cloth.Price.ToString() + "$");
        }
    }
}
