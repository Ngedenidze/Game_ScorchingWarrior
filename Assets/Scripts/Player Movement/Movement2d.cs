using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2d : MonoBehaviour
{
    public float moveSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
     
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3 (moveHorizontal, 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
    }
    
  
    
}
