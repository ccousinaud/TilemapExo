using TMPro.EditorUtilities;
using UnityEngine;

public class MovePlayercat : MonoBehaviour
{
     [SerializeField] private float _moveSpeed;
     [SerializeField] private float _jumpForce;
    
     [SerializeField] private Vector2 _boxSize;
     [SerializeField] private float _castDistance;
     [SerializeField] private LayerMask _layerMask;
     
     private Rigidbody2D _rb;

     void Start()
     {
         _rb = GetComponent<Rigidbody2D>();
     }
           
     void Update()
     {
         if (Input.GetButtonDown("Jump"))
         { 
             if(GroundCheck())
             {
                 _rb.AddForce(new Vector2(0f, _jumpForce), ForceMode2D.Impulse);
             }
         } 
         
         float horizontalMovement = Input.GetAxis("Horizontal");
         _rb.linearVelocity =   new Vector2(horizontalMovement * _moveSpeed * Time.deltaTime, _rb.linearVelocity.y);
               
     }

     private bool GroundCheck()
     {

         return Physics2D.BoxCast(transform.position, _boxSize, 0, Vector2.down, _castDistance, _layerMask);

     }

     private void OnDrawGizmos()
     {
         Gizmos.color = Color.darkOrchid;
         Gizmos.DrawWireCube(transform.position + new Vector3(0,-_castDistance),_boxSize );
     }
}
