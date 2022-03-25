using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ObjectCounter : MonoBehaviour
{
    private int papers;

	[SerializeField] private Text textPaper;
	[SerializeField] private Text textWon;
	[SerializeField] private Button buttonRestart;
	[SerializeField] private Button buttonQuit;
	[SerializeField] private GameObject won;

	void Start()
    {
		won.gameObject.SetActive(false);
	}

    void Update()
	{
		//Criando uma responsividade 
		textPaper.transform.position = new Vector2(Screen.width - textPaper.GetComponent<RectTransform>().sizeDelta.x / 2 - 20, Screen.height - textPaper.GetComponent<RectTransform>().sizeDelta.y / 2 - 10);
		//Numeros de papers que existem na cena
		var objects = GameObject.FindGameObjectsWithTag("Paper");
		
		papers = objects.Length;
		textPaper.text = papers.ToString();
	}
	
	//Diminui no texto a quantidade de itens que precisa pegar
	public void GetPaper()
	{
		papers--;
		if (papers <= 0) 
		{
			papers = 0;
			TookAllPapers();
		}

		textPaper.text = papers.ToString();
	}
	
	//Mostrar o texto e o botao de reiniciar e sair quando pegar todos
	void TookAllPapers()
	{
		won.gameObject.SetActive(true);
		textWon.transform.position = new Vector2(Screen.width / 2, Screen.height - textWon.GetComponent<RectTransform>().sizeDelta.y / 2 - 10);
		buttonRestart.transform.position = new Vector2((Screen.width / 2), Screen.height - buttonRestart.GetComponent<RectTransform>().sizeDelta.y / 2 - 200);
		buttonQuit.transform.position = new Vector2((Screen.width / 2), Screen.height - buttonQuit.GetComponent<RectTransform>().sizeDelta.y / 2 - 300);
	}
}
