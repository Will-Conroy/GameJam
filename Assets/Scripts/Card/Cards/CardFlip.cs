using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CardFlip : MonoBehaviour
{
    /*---- Events ----*/
    public UnityEvent flipComplete = new UnityEvent();


    /*---- Veriables ----*/
    private bool halfPassed = false;
    private bool doFlip = false;
    private Vector3 startPos;
    private float t;
    private float flipTime = 0.5f;


    /*---- Initialization ----*/
    void Awake()
    {
    }


    /*---- Methods ----*/
    public void flip(){
        t = 0;
        doFlip = true;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!doFlip){return;}

        t += Time.deltaTime;
        float proportion = Mathf.Min(t / flipTime, 1);
        transform.position = Vector3.Lerp(startPos, startPos+new Vector3(3,0,-1),proportion);
        if (proportion <= 0.5){
            transform.rotation = Quaternion.Euler(0, 180f * proportion, 0);
        } else{
            transform.rotation = Quaternion.Euler(0, -180f + 180f * proportion, 0);
        }
        if (!halfPassed && proportion > 0.5f){
            halfPassed = true;
            GetComponent<Card>().front();
        }
        if (proportion >= 1){
            doFlip = false;
            flipComplete.Invoke();
        }
    }


    /*---- Getters & Setters ----*/

}
