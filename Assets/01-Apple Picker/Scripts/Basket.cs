using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
public Text scoreGT;

void Start() {
    GameObject scoreGO = GameObject.Find("ScoreCounter" ); 
    scoreGT = scoreGO.GetComponent<Text>();
    scoreGT.text = "0"; 
}
void Update () {
    
 Vector3 mousePos2D = Input.mousePosition;

 mousePos2D.z = -Camera.main.transform.position.z;
 Vector3 mousePos3D = Camera.main.ScreenToWorldPoint( mousePos2D ); // c

 // Move the x position of this Basket to the x position of the Mouse
 Vector3 pos = this.transform.position;
 pos.x = mousePos3D.x;
 this.transform.position = pos;
 }
 void OnCollisionEnter( Collision coll ) {
    GameObject collidedWith = coll.gameObject;
    if ( collidedWith.CompareTag("Apple") ) {
        Destroy( collidedWith );
        int score = int.Parse(scoreGT.text);
        score += 100;
         // Track the high score
        scoreGT.text = score.ToString();
 
            if (score > HighScore.score) {
                HighScore.score = score;
            }
    }
   
    
 }

 }
