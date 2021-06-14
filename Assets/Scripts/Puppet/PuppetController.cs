using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuppetController : MonoBehaviour
{
    
    GameObject _puppet;
    [SerializeField] private bool ownedByPlayerOne;
    /* Events */
    public UnityEvent PuppetMenuClick;
     enum layerName
        {
            Attack = 6,
            Defend = 7,
        };
    
    void OnMouseDown()
    {
        PuppetMenuClick?.Invoke();
    }

    
    public void Awake(){
        _puppet = gameObject.transform.parent.gameObject;
        if(ownedByPlayerOne){
            _puppet.layer = (int) layerName.Attack;
        }else{
            _puppet.layer = (int) layerName.Defend;
        }
    }

    public bool isOwenedByPlayerOne(){
        return ownedByPlayerOne;
    }

    public void toggleLayor(){
        if (_puppet.layer == (int) layerName.Attack){
            _puppet.layer =  (int) layerName.Defend;
        }else{
             _puppet.layer =(int)  layerName.Attack;
        }
    }

}
