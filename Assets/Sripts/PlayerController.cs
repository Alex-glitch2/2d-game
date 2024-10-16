using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    
    public InputAction moveAction; 
    // Start is called before the first frame update
    void Start()
    {
    moveAction.Enable();  
    }

    // Update is called once per frame
    void Update()
    {
      Vector2 move = moveAction.ReadValue<Vector2>();
      Debug.Log(move); 
      Vector2 position = (Vector2)transform.position + move * 0.1f;
      transform.position = position;  
    }
}     
