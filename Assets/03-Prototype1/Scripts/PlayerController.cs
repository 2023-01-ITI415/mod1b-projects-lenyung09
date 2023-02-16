using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    
    public float speed;

    private int count;

    public Text countText;

    public Collider goal;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        goal.gameObject.SetActive(false);
    }
    
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Ups")) 
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
            if (count >= 15) 
            {
                goal.gameObject.SetActive(true);
            }
        }
    }
    
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }
}
