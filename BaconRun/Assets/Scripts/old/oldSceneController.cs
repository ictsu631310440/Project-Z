using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class oldSceneController : MonoBehaviour
{
    public GameObject txtTime;
    public GameObject MainMenu;
    public GameObject PauseMenu;
    public GameObject GameOverUI;
    private float time = 0.0f;
    
    public static bool OpenGameoverUI = false;
    public static bool OpenwinnerUI = false;
    public static bool Startgame = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        txtTime.SetActive(true);
        Startgame = false;
        
        
        OpenGameoverUI = false;
        OpenwinnerUI = false;
        
        PauseMenu.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        PauseMenu.SetActive(false); //ปิดหน้าต่างหยุด
        MainMenu.SetActive(false);
        
        Time.timeScale = 1; //เวลาในเกมเดินต่อ
        txtTime.SetActive(true);
        Startgame = true;
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1 && OpenGameoverUI != true && Startgame == true)
        {
            txtTime.SetActive(false);
            MainMenu.SetActive(false);
            PauseMenu.SetActive(true);
            Time.timeScale = 0;
            
            Cursor.visible = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0 && OpenGameoverUI != true &&
                 Startgame == true)
        {
            ResumeGame();
        }
    }

    public void LoadScene(int num)
    {
        SceneManager.LoadSceneAsync(num);
    }

    public void GotoMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GotoPlayGame()
    {
        SceneManager.LoadScene("PlayGame");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
