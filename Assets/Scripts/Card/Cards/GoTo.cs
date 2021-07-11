using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GoTo : MonoBehaviour
{
    /*---- ENUMS ----*/

    /*---- Events ----*/     
    public UnityEvent moveComplete = new UnityEvent();


    /*----Veriables----*/
    private bool movementLocked = false;
    private bool hasReachedTarget = true;
    float t;
    private Vector3 target;
    private float speed = 0.05f;


    /*----Initialization----*/
    void Awake()
    {
        target = transform.position;
    }


    /*----Methods----*/
      // Update is called once per frame
    void Update()
    {
        if (!hasReachedTarget){
            float distance = (transform.position - target).magnitude;
            if ((!movementLocked) && distance > 0.01f ) //stop moving when close enough?
            {
                t += Time.deltaTime;
                float moveSpeed = speed / Mathf.Max(0.9f - 0.9f * Mathf.Pow(t,2), speed);

                transform.position = Vector3.Lerp(transform.position, target, moveSpeed * 100 * Time.deltaTime);
            } else if (!movementLocked)
            {
                cancelMove();
                transform.position = target;
            }
        }
    }

    public void cancelMove(){
        hasReachedTarget = true;
        moveComplete.Invoke();
        moveComplete.RemoveAllListeners();
    }


    /*----Getters & Setters----*/
    public void setTarget(Vector3 newTarget)
    {
        t = 0;
        target = newTarget;
        hasReachedTarget = false;
    }
}
