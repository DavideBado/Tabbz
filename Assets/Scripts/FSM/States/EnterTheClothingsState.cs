using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Bado_City;

public class EnterTheClothingsState : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameManager.MyGameManager.ClothingsIn.SetActive(true);
        Debug.Log(GameManager.MyGameManager.ClothingsShop.Name);
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
        GameManager.MyGameManager.ClothingsIn.SetActive(false);
    }
    
    private void ItemsMenuGen()
    {
        GameObject _itemsMenu = GameManager.MyGameManager.ClothingsIn.GetComponent<ShopPanelData>().ItemsMenu;
        GameObject _itemsInfoPref = GameManager.MyGameManager.ClothingsIn.GetComponent<ShopPanelData>().ItemsInfoPref;
        GameObject _content = _itemsMenu.GetComponent<ScrollRect>().content.gameObject;
        foreach (ClothingConfigData _clothing in GameManager.MyGameManager.ClothingsShop.Clothings)
        {
            GameObject itemInfoInsta = Instantiate(_itemsInfoPref, _content.transform);
            itemInfoInsta.GetComponent<ClothingInfoData>().IconImage.sprite = _clothing.Icon;
            //itemInfoInsta.GetComponent<ClothingInfoData>().NameBackgroundImage.sprite = _clothing...;
            //itemInfoInsta.GetComponent<ClothingInfoData>().DescriptBackgroundImage.sprite = _clothing.....;
            //itemInfoInsta.GetComponent<ClothingInfoData>().PriceBackgroundImage.sprite = _clothing.....;
            itemInfoInsta.GetComponent<ClothingInfoData>().NameTxt.text = _clothing.Name;
            itemInfoInsta.GetComponent<ClothingInfoData>().DescriptionTxt.text = _clothing.Description;
            itemInfoInsta.GetComponent<ClothingInfoData>().PriceTxt.text = (_clothing.Price.ToString() + "$");
        }
    }
}
