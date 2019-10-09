using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Tabboz_3D;

public abstract class ItemInfoDataBase : MonoBehaviour
{
    public Image IconImage, NameBackgroundImage, DescriptBackgroundImage;
    public TMP_Text NameTxt, DescriptionTxt;
    [HideInInspector]
    public ISaleable Item;
}