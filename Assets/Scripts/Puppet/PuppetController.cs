using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuppetController : MonoBehaviour
{
    
    
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
        if(ownedByPlayerOne){
            gameObject.layer = (int) layerName.Attack;
        }else{
            gameObject.layer = (int) layerName.Defend;
        }
    }

    public bool isOwenedByPlayerOne(){
        return ownedByPlayerOne;
    }

    public void toggleLayor(){
        if (gameObject.layer == (int) layerName.Attack){
            gameObject.layer =  (int) layerName.Defend;
        }else{
             gameObject.layer =(int)  layerName.Attack;
        }
    }

}
