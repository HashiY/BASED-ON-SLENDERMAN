using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickKey : MonoBehaviour
{
    [SerializeField] private Component doorCollider;
    [SerializeField] private GameObject key;

    public PlayerInputActions pia;

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

    //Vai ser pego a chave com E se estiver encostando no collider da chave
    private void OnTriggerStay()
    {
        if (pia.PlayerActions.E.triggered)//Input.GetKey(KeyCode.E)
        {
            doorCollider.GetComponent<BoxCollider>().enabled = true;
            key.SetActive(false);
            Destroy(key);
        }
    }
}
