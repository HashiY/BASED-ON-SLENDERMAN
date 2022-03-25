using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] private GameObject flashlight;
    [SerializeField] private GameObject ON;
    [SerializeField] private GameObject OFF;

    private bool flashlightActive = false;

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

    //Quando comecar o jogo a lanterna estara desligada
    void Start()
    {
        flashlight.gameObject.SetActive(false);
        ON.SetActive(false);
        OFF.SetActive(true);
    }

    void Update()
    {
        TurnOnFlashlight();
    }

    void TurnOnFlashlight()
    {
        //Liga a lanterna com F
        if (pia.PlayerActions.F.triggered)//Input.GetKeyDown(KeyCode.F)
        {
            if (flashlightActive == false)
            {
                flashlight.gameObject.SetActive(true);
                flashlightActive = true;
                ON.SetActive(true);
                OFF.SetActive(false);
            }
            else
            {
                flashlight.gameObject.SetActive(false);
                flashlightActive = false;
                ON.SetActive(false);
                OFF.SetActive(true);
            }
        }
    }
}
