using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu_UI : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject menuOpciones;
    public GameObject menuPausa;
    public GameObject menuControles;
    public GameObject HUD;
    public GameObject libro;
    public bool isMainMenu;
    bool isLibroAbierto =false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //If es MainMenu, mostrar mainMenu
        if (isMainMenu)
        {
            mainMenu.SetActive(true);
            menuOpciones.SetActive(false);
            menuPausa.SetActive(false);
            menuControles.SetActive(false);
            HUD.SetActive(false);
            libro.SetActive(false);
        }
        //Sino mostrar hud del game
        else
        {
            mainMenu.SetActive(false);
            menuOpciones.SetActive(false);
            menuPausa.SetActive(false);
            menuControles.SetActive(false);
            HUD.SetActive(true);
            libro.SetActive(false);
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Estudio");
    }

    public void GoToMainMenu()
    {
        mainMenu.SetActive(true);
        menuOpciones.SetActive(false);
        menuPausa.SetActive(false);
        menuControles.SetActive(false);
        HUD.SetActive(false);
        libro.SetActive(false);
    }

    public void GoToOptions()
    {
        mainMenu.SetActive(false);
        menuOpciones.SetActive(true);
        menuPausa.SetActive(false);
        menuControles.SetActive(false);
        HUD.SetActive(false);
        libro.SetActive(false);
    }
    public void SalirGame()
    {
        Application.Quit();
    }

    public void GoToPauseMenu()
    {
        mainMenu.SetActive(false);
        menuOpciones.SetActive(false);
        menuPausa.SetActive(true);
        menuControles.SetActive(false);
        HUD.SetActive(false);
        libro.SetActive(false);
    }

    public void ReturnButton()
    {
        if (isMainMenu)
        {
            GoToMainMenu();
        }
        else
        {
            GoToPauseMenu();
        }
    }
    public void GoToControlMenu()
    {
        mainMenu.SetActive(false);
        menuOpciones.SetActive(false);
        menuPausa.SetActive(false);
        menuControles.SetActive(true);
        HUD.SetActive(false);
        libro.SetActive(false);
    }

    //Botones del hud
    public void PauseJuego()
    {
        Time.timeScale = 0f;
        mainMenu.SetActive(false);
        menuOpciones.SetActive(false);
        menuPausa.SetActive(true);
        menuControles.SetActive(false);
        HUD.SetActive(false);
        libro.SetActive(false);
    }

    public void ReturnToGame()
    {
        Time.timeScale = 1f;
        mainMenu.SetActive(false);
        menuOpciones.SetActive(false);
        menuPausa.SetActive(false);
        menuControles.SetActive(false);
        HUD.SetActive(true);
        libro.SetActive(false);
    }

    public void AbrirYCerrarLibro()
    {
        if (isLibroAbierto)
        {
            mainMenu.SetActive(false);
            menuOpciones.SetActive(false);
            menuPausa.SetActive(false);
            menuControles.SetActive(false);
            HUD.SetActive(true);
            libro.SetActive(false);
            isLibroAbierto = false;
        }
        if (!isLibroAbierto)
        {
            mainMenu.SetActive(false);
            menuOpciones.SetActive(false);
            menuPausa.SetActive(false);
            menuControles.SetActive(false);
            HUD.SetActive(true);
            libro.SetActive(true);
            isLibroAbierto = true;
        }
    }
}