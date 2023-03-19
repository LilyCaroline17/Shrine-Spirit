using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DragAndDrop : MonoBehaviour
{

    public delegate void DragEndedDelegate(DragAndDrop draggableObject);

    public DragEndedDelegate dragEndedCallback;


    private bool IsDragged = false;
    public Vector3 originalPosition;
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;

    public float delay; //Decides how long to wait before item disappears
    public bool canBeDragged = true;
    public GameObject prefab;
    
    private void OnMouseDown() //Save original position of the item if the item can still be dragged
    {
        if (canBeDragged)
        { 
            IsDragged = true;
            originalPosition = transform.localPosition;
            mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            spriteDragStartPosition = transform.localPosition;
        }
        else
        {
            IsDragged = false;   
        }
        
    }

    private void OnMouseDrag() //Has the gameObject follow the mouse
    {
        if (IsDragged)
        {
            transform.localPosition = spriteDragStartPosition + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPosition);
        }
    }

    private void OnMouseUp()
    {
        IsDragged = false;
        //Debug.Log(this);
        DragAndDrop that = this;
        if (this != null)
        {
            dragEndedCallback(that);
        }

        if (canBeDragged)
        {
            //Brings the object back to its original position if it doesn't snap to the target
            transform.localPosition = originalPosition;
        }
        else
        {
            //Supposed to destroy moved gameObject and create new one in its place
            Destroy(gameObject, delay);

            //*Below does not work properly right now*
            //prefab = Instantiate(gameObject); 
            //prefab.transform.localPosition = originalPosition;
            //canBeDragged = true;
            
        }
        

    }
}
