using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDrag : MonoBehaviour {
    /*---- Veriables ----*/
    private bool followMouse = false;
    private Vector3 relativePos;
    List<GameObject> currentCollisions = new List<GameObject>();


    /*---- Initialization ----*/
    void Start()
    {

    }

    /*---- Methods ----*/
     void OnTriggerEnter2D(Collider2D col)
    {
        currentCollisions.Add(col.gameObject);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        currentCollisions.Remove(col.gameObject);
    }

    void OnMouseDown()
    {
        if (!GetComponentInParent<Card>().isDraggable())
        {
            return;
        }
        followMouse = true;
        Vector3 mousePos = GetWorldPositionOnPlane(Input.mousePosition, 0f);
        relativePos = this.transform.position - mousePos;
        relativePos.z = 0;
        GetComponentInParent<GoTo>().cancelMove();
    }

    //Called when the player lets go of the card, It will try and excute the card effect if there are legal targets
    void OnMouseUp()
    {
        if (followMouse)
        {
            followMouse = false;

            if(currentCollisions.Count != 0){
                GameObject.FindGameObjectWithTag("Hand").GetComponent<Hand>().lockCards();
                GetComponentInParent<Card>().cardPlay(currentCollisions);
            }

            GetComponentInParent<Zone>().display();
            GameObject.FindGameObjectWithTag("Hand").GetComponent<Hand>().unlockCards();

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (followMouse)
        {
            Vector3 mousePos = GetWorldPositionOnPlane(Input.mousePosition, transform.position.z);
            mousePos.z = -51;
            transform.parent.position = Vector3.Lerp(transform.parent.position, mousePos + relativePos, 0.1f * Time.deltaTime * 100);
        }
    }


    /*---- Getters & Setters ----*/
    public Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
        float distance;
        xy.Raycast(ray, out distance);
        return ray.GetPoint(distance);
    }
   
}
