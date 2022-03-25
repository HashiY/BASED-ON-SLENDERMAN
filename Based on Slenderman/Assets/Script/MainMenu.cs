using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Vai para a cena do jogo
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    //Vai para a instrucao do jogo
    public void GotoInstructionsMenu()
    {
        SceneManager.LoadScene("InstructionsMenu");
    }

    //Volta para o Menu
    public void GotoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    //Sai do jogo
    public void ExitGame()
    {
        Application.Quit();
    }

    //Vai para a cena do Menu
    public void BackGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
