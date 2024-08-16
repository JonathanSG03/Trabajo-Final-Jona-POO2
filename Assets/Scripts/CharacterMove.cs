using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    private CharacterController ctrl;

    private float movX;
    private float movZ;
    private Vector3 movi;

    public float vel;
    public float velJump;

    private Vector3 velY;
    public float gravity = -9.8f;

    private bool isGrounded;
    public Transform groundCheck;
    public float radius;
    public LayerMask groundMask;


    void Start()
    {

        ctrl = GetComponent<CharacterController>();
    }


    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, radius, groundMask);
        movX = Input.GetAxis("Horizontal");
        movZ = Input.GetAxis("Vertical");

        //movi = new Vector3(movX, 0, movZ);
        movi = transform.right * movX + transform.forward * movZ;
        ctrl.Move(movi * vel * Time.deltaTime);

        if (isGrounded && velY.y < 0)
        {
            velY.y = 0;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velY.y = Mathf.Sqrt(velJump * -2 * gravity);
        }
        velY.y += gravity * Time.deltaTime; // VelY(0/0/0) -> VelY (0,gravedad,0)
        ctrl.Move(velY * Time.deltaTime);

        if (vel == 50 || vel == 10)
        {
            Invoke("VelocidadNormal", 10f);
        }

    
    }

    public void MasVelocidad(float soyVeloz)
    {
        vel = soyVeloz;
    }

    public void VelocidadNormal()
    {
        vel = 30;
    }

    public void Envenenamiento()
    {
        vel = 10;
    }
}
