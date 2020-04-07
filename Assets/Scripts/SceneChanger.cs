using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //public void GameOver()
    //{
    //    SceneManager.LoadScene("GameOver");
    //}

    public void Restart()
    {
        SceneManager.LoadScene("ShopScene_MCtrls");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("ShopScene_MCtrls");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
