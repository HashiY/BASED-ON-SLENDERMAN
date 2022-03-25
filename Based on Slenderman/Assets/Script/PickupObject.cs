using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    [SerializeField] private float pickUpRange = 5;
    [SerializeField] private float moveForce = 250;
    [SerializeField] private Transform holdParent;
    private GameObject heldObj;
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

    void Update()
    {
        if (pia.PlayerActions.Mouse0.triggered) // Input.GetMouseButtonDown(0)
        {            
            if (heldObj == null)
            {
                //Para detectar um colisor
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
                {
                    PickupObjects(hit.transform.gameObject);
                }
            }
            else
            {
                DropObject();
            }
        }

        if(heldObj != null)
        {
            MoveObject();
        }
    }

    void MoveObject()
    {
        //Se a distancia da mao e do objeto for maior que 0.1
        if(Vector3.Distance(heldObj.transform.position, holdParent.position) > 0.1f)
        {
            //O objeto vai se mover
            Vector3 moveDirection = (holdParent.position - heldObj.transform.position);
            heldObj.GetComponent<Rigidbody>().AddForce(moveDirection * moveForce);
        }
    }

    //Muda as configuracoes do Rigidbody para segurar o obj
    void PickupObjects(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>())
        {
            Rigidbody objRig = pickObj.GetComponent<Rigidbody>();
            objRig.useGravity = false;
            objRig.drag = 10;

            objRig.transform.SetParent(holdParent);
            heldObj = pickObj;
        }
    }

    //Voltando para o normal as mudancas que fez quando esta com o objeto
    void DropObject()
    {
        Rigidbody heldRig = heldObj.GetComponent<Rigidbody>();
        heldRig.useGravity = true;
        heldRig.drag = 1;

        heldObj.transform.SetParent(null);
        heldObj = null;
    }
}
