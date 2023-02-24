using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class ApplePicker : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;
    void Start()
    {
        basketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }
public void AppleDestroyed() {
// a
// Destroy all of the falling Apples
GameObject[] appleArray=GameObject.FindGameObjectsWithTag("Apple");

 foreach ( GameObject tGO in appleArray ) {
 Destroy( tGO );
 }
 int basketIndex = basketList.Count - 1;
    GameObject tBasketGO = basketList[basketIndex];
    basketList.RemoveAt(basketIndex);
    Destroy(tBasketGO);
    
    if (basketList.Count == 0)
    {
    SceneManager.LoadScene("Main-ApplePicker");
    }
 
}
}