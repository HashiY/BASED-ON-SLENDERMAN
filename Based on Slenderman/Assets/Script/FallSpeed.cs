using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallSpeed : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 velo;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //Foi criado para a velocidade de queda dos objetos gerados no ar nao ultrapassar o chao
    void Update()
    {
        velo = rb.velocity;
        velo.y = -15.0f;
        rb.velocity = velo;
    }
}
