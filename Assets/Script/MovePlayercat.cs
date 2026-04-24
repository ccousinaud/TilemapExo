using UnityEngine;

public class MovePlayercat : MonoBehaviour
{
     public float moveSpeed;
        
           
       
           public bool isJumping;
           public float jumpForce;
       
           private Vector2 _velocity = Vector3.zero;
           private Rigidbody2D _rb;

           void Start()
           {
               _rb = GetComponent<Rigidbody2D>();
           }
           
           void Update()
           {
               float horizontalMovement = Input.GetAxis("Horizontal")*moveSpeed*Time.deltaTime;
       
               if (Input.GetButtonDown("Jump"))
               {
                   isJumping = true;
               } 
       
       
               MovePlayer(horizontalMovement);
       
           }

           void MovePlayer(float horizontalMovement)
           {
               Vector2 targetVelocity = new Vector2(horizontalMovement, _rb.linearVelocity.y);

               _rb.linearVelocity =  targetVelocity;

               if (isJumping)
               {
                   _rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                   isJumping = false;
               }
           }
}
