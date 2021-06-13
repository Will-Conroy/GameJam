using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMenuController : MonoBehaviour
{
    private bool isVisable;

    public void Awake(){
        isVisable = false;
        gameObject.SetActive(isVisable);
    }



    public void toggleVisiable(){
        isVisable = !isVisable;
        gameObject.SetActive(isVisable);
    }
}
