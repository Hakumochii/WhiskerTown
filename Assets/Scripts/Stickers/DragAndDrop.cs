using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
 void OnMouseDrag()
 {
    Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    transform.position = mousePos;
 }
}