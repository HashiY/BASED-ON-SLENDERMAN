using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    [SerializeField] private Transform characterBody;
    [SerializeField] private Transform characterHead;
    [SerializeField] private Transform positionLight;
    [SerializeField] private Transform flashlight;

    //Sensibilidade do mouse
    [SerializeField] private float sensitivityX = 1;
    [SerializeField] private float sensitivityY = 1;

    private float rotationX = 0;
    private float rotationY = 0;

    private float angleYMin = -90;
    private float angleYMax = 90;

    //Controla a suavidade da camera
    private float smoothRotX = 0;
    private float smoothRotY = 0;
    private float smoothCoefX = 0.005f;
    private float smoothCoefY = 0.005f;

    PlayerInputActions pia;

    #region PlayerInputActions
    public void Awake()
    {
        pia = new PlayerInputActions();
    }

    public void OnEnable()
    {
        pia.Enable();
    }

    public void OnDisable()
    {
        pia.Disable();
    }
    #endregion

    //Usa o LateUpdate pois a camera segue o objeto com a posicao atualizada
    void LateUpdate()
    {
        //Coloca a posicao da camera ficar fixa na cabeca do player
        transform.position = characterHead.position;
        flashlight.position = positionLight.position;
    }
    
    void Update()
    {
        CameraMovement();
    }

    void CameraMovement()
    {
        float horizontalDelta = pia.PlayerActions.MouseX.ReadValue<float>() * sensitivityX; //Input.GetAxisRaw("Mouse X")
        float verticalDelta = pia.PlayerActions.MouseY.ReadValue<float>() * sensitivityY; //Input.GetAxisRaw("Mouse Y")

        //Interpola o valor do deslocamento
        smoothRotX = Mathf.Lerp(smoothRotX, horizontalDelta, smoothCoefX);
        smoothRotY = Mathf.Lerp(smoothRotY, verticalDelta, smoothCoefY);

        //Deslocamento a cada frame
        rotationX += smoothRotX;
        rotationY += smoothRotY;

        //Limitando o angulo que a camera pode rotacionar em Y
        rotationY = Mathf.Clamp(rotationY, angleYMin, angleYMax);

        //Fazer o corpo se mover na direcao que a camera aponta
        characterBody.localEulerAngles = new Vector3(0, rotationX, 0);

        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
    }
}
