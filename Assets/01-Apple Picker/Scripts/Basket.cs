using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get the current screen position of t
        Vector3 mousePos2D = Input.mousePosition;
        // The Camera's z position sets how far
        mousePos2D.z = -Camera.main.transform.position;
        // Convert the point from 2D screen spa
        Vector3 mousePos3D = Camera.main.Screen;
        // Move the x position of this Basket t
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;

    }
}
