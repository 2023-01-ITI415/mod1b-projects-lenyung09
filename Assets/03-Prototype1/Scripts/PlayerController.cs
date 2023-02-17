using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    
    public float speed;

    private int count;

    private int livesCount = 3;

    public Text countText;

    public Text livesText;

    public Text winText;

    public Collider goal;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        goal.gameObject.SetActive(false);
        winText.gameObject.SetActive(false);
    }

    void Update() {
        if (Input.GetKeyDown ("space") || Input.GetKeyDown ("w") || Input.GetKeyDown ("up")) {
                Vector3 jump = new Vector3 (0.0f, 400.0f, 0.0f);
           
                rb.AddForce (jump);
            }
        if (Input.GetKeyDown ("s") || Input.GetKeyDown ("down")) {
                Vector3 jump = new Vector3 (0.0f, -100.0f, 0.0f);
           
                rb.AddForce (jump);
            }    
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
            if (count >= 16) 
            {
                goal.gameObject.SetActive(true);
            }
        }
        if (other.gameObject.CompareTag("Apple"))
    {
        other.gameObject.SetActive(false);
        livesCount--;
        livesText.text = "Lives: " + livesCount.ToString();
        if (livesCount == 0){
        SceneManager.LoadScene("Main-Prototype 1");
        }
    }
    if (other.gameObject.CompareTag("Finish")) {
        winText.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    
    }
    
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }
}
