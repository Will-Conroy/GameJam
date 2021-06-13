using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuppetController : MonoBehaviour
{
    
    /* Events */
    public UnityEvent PuppetMenuClick;
    
    void OnMouseDown()
    {
        PuppetMenuClick?.Invoke();
    }
}
