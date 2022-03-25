using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;

    private Vector3 forward; // tem a ver com a frente e tras
    private Vector3 strafe; // tem a ver com a direita e esquerda
    private Vector3 vertical; //tem a ver com a gravidade e o pulo
    private Vector3 finalVelocity;

    [SerializeField] private float forwardSpeed = 5f;
    [SerializeField] private float strafeSpeed = 5f;

    private float gravity;
    private float jumpSpeed;
    private float maxJumpHeight = 2f;
    private float timeToMaxHeight = 0.5f;

    private float forwardInput;
    private float strafeInput;

    [SerializeField] private float runningSpeed = 5f;

    PlayerInputActions pia;

    #region PlayerInputActions
    private void Awake()
    {
        pia = new PlayerInputActions();
    }

    private void OnEnable()
    {
        pia.Enable();
    }

    private void OnDisable()
    {
        pia.Disable();
    }
    #endregion

    void Start()
    {
        controller = GetComponent<CharacterController>();

        gravity = (-2 * maxJumpHeight) / (timeToMaxHeight * timeToMaxHeight);
        jumpSpeed = (2 * maxJumpHeight) / timeToMaxHeight;
    }
    
    void Update()
    {
        //Inputs
        forwardInput = pia.PlayerActions.Forward.ReadValue<float>();//Input.GetAxisRaw("Vertical");
        strafeInput = pia.PlayerActions.Strafe.ReadValue<float>();  //Input.GetAxisRaw("Horizontal");

        MovePlayer();
    }

    private void MovePlayer()
    {
        //calculando as forcas
        forward = forwardInput * forwardSpeed * transform.forward;
        strafe = strafeInput * strafeSpeed * transform.right;

        //gravidade a cada frame
        vertical += gravity * Time.deltaTime * Vector3.up;

        //receta para nao almentar por conta da gravidade
        if (controller.isGrounded)
        {
            vertical = Vector3.down;
        }

        //recebe a velocidade do pulo e nao deixa pular no ar
        if (pia.PlayerActions.Jump.triggered && controller.isGrounded) //Input.GetKeyDown(KeyCode.Space)
        {
            vertical = jumpSpeed * Vector3.up;
        }

        //Para cair rapidamente quando bater a cabeca no teto
        if(vertical.y > 0 && (controller.collisionFlags & CollisionFlags.Above) != 0)
        {
            vertical = Vector3.zero;
        }

        //Se aperta o LeftShift
        if (pia.PlayerActions.LS.ReadValue<float>() > 0.1f)//Input.GetKey(KeyCode.LeftShift)
        {
            finalVelocity = (forward + strafe + vertical) * runningSpeed;
        }
        else
        {
            finalVelocity = forward + strafe + vertical;
        }

        controller.Move(finalVelocity * Time.deltaTime);
    }

    //Para dar o pulo quando colidir com o Trampoline 
    private void OnTriggerEnter(Collider other)
    {
        Rigidbody objRig = other.GetComponent<Rigidbody>();

        if(objRig.useGravity == true)
        {
            Mola mola = other.GetComponent<Mola>();
            if (mola != null)
            {
                vertical = mola.impulseForce * Vector3.up;
                finalVelocity = forward + strafe + vertical;
                controller.Move(finalVelocity * Time.deltaTime);
            }
        }
    }
}
