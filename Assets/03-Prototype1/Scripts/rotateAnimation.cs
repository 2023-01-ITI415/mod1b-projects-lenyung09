using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateAnimation : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
    //Vec3 to transform multiplied by deltaTime to make action occur smoothly by updating per second
    //representing seconds since last frame update
    //dynamically changes value based on length of a frame
    transform.Rotate(new Vector3 (15,30,45) * Time.deltaTime);
    }
}
