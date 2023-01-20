using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] float torqueAmount = 10f;
    [SerializeField] float baseSpeed = 18f;
    [SerializeField] float boostSpeed = 25f;
    SurfaceEffector2D surfaceEffector2D;
    bool canMove = true;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    void Update()
    {
        if(canMove)
        {
            AddRotation();
            RespondToBoost();
        }
    }

    public void DisableControls()
    {
        canMove = false;
    }

    void AddRotation()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }
        
        if(Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }

    void RespondToBoost()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }
}
