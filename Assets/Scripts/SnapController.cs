using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapController : MonoBehaviour
{ 
    public List<Transform> snapPoints;
    public List<DragAndDrop> draggableObjects;
    public float snapRange = 0.5f;

    //Don't fully understand this code, but it is what has the object snap to place
    void Start()
    {
        //adding the DragAndDrop script of objects with tag token to the draggable object list
        foreach (GameObject token in GameObject.FindGameObjectsWithTag("token"))
        {
            draggableObjects.Add(token.GetComponent<DragAndDrop>());
        }

        foreach (DragAndDrop draggable in draggableObjects)
        {
            draggable.dragEndedCallback = OnDragEnded;
        }

    }

    private void OnDragEnded(DragAndDrop draggable)
    {
        float closestDistance = -1;
        Transform closestSnapPoint = null;

        foreach(Transform snapPoint in snapPoints)
        {
            float currentDistance = Vector2.Distance(draggable.transform.localPosition, snapPoint.localPosition);
            if (closestSnapPoint == null || currentDistance < closestDistance)
            {
                closestSnapPoint = snapPoint;
                closestDistance = currentDistance;
            }
        }

        if(closestSnapPoint != null && closestDistance <= snapRange)
        {
            draggable.transform.localPosition = closestSnapPoint.localPosition;
            draggable.canBeDragged = false;
        }
    }
}
