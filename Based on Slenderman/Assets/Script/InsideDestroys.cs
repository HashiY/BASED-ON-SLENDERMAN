using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideDestroys : MonoBehaviour
{
    [SerializeField] private float sphereRadius;

    void Update()
    {
        WarningPosition();
    }

    //Para destruir o objeto se um outro objeto entrar dentro dessa esfera
    void WarningPosition()
    {
        
        if (Physics.CheckSphere(transform.position, sphereRadius))
        {
            Destroy(transform.parent.gameObject);
        }
    }

    //Colocando uma cor vermelha esferica
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, sphereRadius);
    }
}
