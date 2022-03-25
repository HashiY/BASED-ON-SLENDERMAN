using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animation hinge;

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
    //Vai fazer a animacao da porta se apertar o E e se estiver encostando no collider da porta
    private void OnTriggerStay()
    {
        if (pia.PlayerActions.E.triggered) //Input.GetKey(KeyCode.E)
        {
            hinge.Play();
        }
    }
}
