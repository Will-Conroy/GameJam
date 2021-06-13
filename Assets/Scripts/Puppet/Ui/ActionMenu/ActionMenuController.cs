using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMenuController : MonoBehaviour
{
    private bool isVisable;
    private GameObject[] puppets;

    public void Awake(){
        puppets = GameObject.FindGameObjectsWithTag("Puppet");
        foreach(GameObject puppet in puppets)
            puppet.GetComponentInChildren<PuppetController>().PuppetMenuClick.AddListener(delegate{toggleVisiable(puppet.transform.GetChild(1).GetChild(0).gameObject);});
        isVisable = false;
        gameObject.SetActive(isVisable);
    }

    public void toggleVisiable(GameObject me){
        if(me == gameObject){
            isVisable = !isVisable;
            gameObject.SetActive(isVisable);
        }else if(isVisable){
            isVisable = !isVisable;
            gameObject.SetActive(isVisable);
        }
        
    }
}
