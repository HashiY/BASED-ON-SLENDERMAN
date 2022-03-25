using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObject : MonoBehaviour
{
	//Destroi o objeto depois do tempo escolhido

	[SerializeField] private float time;
	void Start()
	{
		Invoke("Delete", time);
	}

	void Delete()
	{
		Destroy(this.gameObject);
	}
}
