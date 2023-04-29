using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerCarMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;

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
        Vector3 changeInPos = ( Vector3.up * Forward()) + (Vector3.right * Right());

        return changeInPos;
    }

    void MoveCar()
    {
        rb.MovePosition(transform.position + Movement() * Time.fixedDeltaTime);
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //Todo: Add Reference to game manager win lose 

        MoveCar();
    }


}
