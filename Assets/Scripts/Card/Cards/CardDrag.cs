using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDrag : MonoBehaviour {

    private bool followMouse = false;
    private Vector3 relativePos;
    List<GameObject> currentCollisions = new List<GameObject>();

    public Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
        float distance;
        xy.Raycast(ray, out distance);
        return ray.GetPoint(distance);
    }

    // Use this for initialization
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        currentCollisions.Add(col.gameObject);
        Debug.Log("Entered");

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

    void OnMouseUp()
    {
        if (followMouse)
        {
            followMouse = false;
            Debug.Log("Droped");
            if(currentCollisions.Count == 0){
                //Lock Hand here
                GetComponentInParent<Card>().cardPlay(currentCollisions);
            }
            if (transform.parent.parent.gameObject.CompareTag("Hand")){
                GetComponentInParent<Hand>().display();
            }
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
}
