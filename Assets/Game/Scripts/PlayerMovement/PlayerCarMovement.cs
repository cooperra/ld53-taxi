using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerCarMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    //Set this value to 4.5
    private readonly float boundary = 4.5f;

    #region PlayerInput plus speed;
    private float Forward()
    {
         
        
        return Input.GetAxis("Vertical") * speed;
    }
    private float Right()
    {
        
        return Input.GetAxis("Horizontal") * speed;
    }
    #endregion
    //Player Car Movement;
    Vector3 Movement()
    {
        Vector3 fwd = Vector3.up * Forward();
        //Simple Collision Detection For Boundary. Fix if possible
        if(transform.position.y >= boundary * 0.05f)
        {
            fwd.y = 0;
            fwd.y-= speed * Time.deltaTime;
        }
        else if (transform.position.y <= -boundary)
        {
            fwd.y = 0;
            fwd.y += speed * Time.deltaTime;
        }
        
        
        
        Vector3 changeInPos = (fwd + (Vector3.right * Right()));
        
        return changeInPos;
    }
    private void OnDestroy()
    {
        //explode!!
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*Handle Collisions for Obstacle
         * Car Tag and Obstacle are the same label Obstacle
         * 
         */

        if(collision.gameObject.CompareTag("Obstacle"))
        {
           //Decrease Money
        }
    }
    void MoveCar()
    {
        rb.MovePosition(transform.position + Movement() * Time.fixedDeltaTime);
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            GameManager.instance.Conditions = Conditions.exit;
        }
    }
    private void FixedUpdate()
    {
        //Todo: Add Reference to game manager win lose 
        if (GameManager.instance.Conditions == Conditions.start || GameManager.instance.Conditions == Conditions.finish)
        {
            MoveCar();
        }
    }


}
