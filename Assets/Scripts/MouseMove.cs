using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour
{
    private Vector3 handleStartPosition;
    private Vector3 handleToOriginVector;
    public float moveSpeed = 1.0f;
    public bool isDragging;
    private bool isReturning = false;

    void OnMouseDown()
    {
        handleToOriginVector = transform.root.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        handleStartPosition = transform.root.position;
        isDragging = true;
    }

    void OnMouseDrag()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.root.position = new Vector2(mousePos.x + handleToOriginVector.x, transform.root.position.y);
    }

    void OnMouseUp()
    {
        isDragging = false;
        var isRight = handleStartPosition.x - transform.root.position.x < 0 ? true : false; 
        float dist = Vector3.Distance(transform.root.position, handleStartPosition);
        if (dist < 1.7)
            isReturning = true;
        else
        {
            Destroy(gameObject);
            if (isRight)
                ScoreManager.instance.AddScore(CounterSide.Right);
            else
                ScoreManager.instance.AddScore(CounterSide.Left);
            GameManager.instance.InitNewImage();
        }
        //    GameManager.instance.ChangeSquare();
        Debug.Log("Distance to other: " + dist);

    }

    void Update ()
    {
        if (isReturning)
        {
            transform.root.position = Vector3.Lerp(transform.root.position, handleStartPosition, Time.deltaTime * moveSpeed);
            if (Vector3.Distance(transform.root.position, handleStartPosition) < 0.1)
            {
                isReturning = false;
            }
        }
            
    }
}
