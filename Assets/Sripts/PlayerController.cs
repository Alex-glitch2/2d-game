using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    
    
    // Variables related to player character movement 
    public InputAction MoveAction; 
    Rigidbody2D rigidbody2d;
    Vector2 move; 
    public float speed = 3.0f; 


   // Varibales related to the heealth system
   public int maxhealth = 5; 
   public int health {get {return currentHealth;}}
   int currentHealth; 

   //Variables related to the temporary invinibility
   public float timInvincible = 2.0f;
   bool isInvinible;
   float damageCooldown;

    // Start is called before the first frame update
    void Start()
    {
    MoveAction.Enable(); 
    rigidbody2d = GetComponent<Rigidbody2D>();
    currentHealth = 1;
    }

    // Update is called once per frame
    void Update()
    {
      move = MoveAction.ReadValue<Vector2>();


      if (isInvinible)
      {

          damageCooldown -= Time.deltaTime;
          if (damageCooldown < 0)
      
       {
        isInvinible = false; 
       }

      }
    }



    // FixedUpdate has the same call rate as physics system  
    void FixedUpdate()
    {
      Vector2 position = (Vector2)rigidbody2d.position + move * speed * Time.deltaTime;
      rigidbody2d.MovePosition(position);  
    }


      public void ChangeHealth (int amount) 
      {
      if (amount < 0)
      {

        if (isInvinible)
        {
          return;
        }
      isInvinible = true;
      damageCooldown = timInvincible;
      }


    currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxhealth);
    UIHealthbar.instance.SetValue(currentHealth / (float)maxhealth);

     Debug.Log(currentHealth + "/" + maxhealth);
     }


}    


