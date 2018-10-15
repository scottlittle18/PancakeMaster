using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    string currentScene;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
    }

    public void TestLevel()
        {
            SceneManager.LoadScene("Test Level");
        }
    
        public void LoadTitleScreen()
        {
            SceneManager.LoadScene("Title Screen");
        }

        public void Level1()
        {
            SceneManager.LoadScene("Level 1");
        }

        public void Level2()
        {
            SceneManager.LoadScene("Level 2");
        }

        public void Level3()
        {
            SceneManager.LoadScene("Level 3");
        }

        public void Level4()
        {
            SceneManager.LoadScene("Level 4");
        }

        public void Retry()
        {
            SceneManager.LoadScene(currentScene);
        }

        public void Credits()
        {
            SceneManager.LoadScene("Credits");
        }

        public void QuitGame()
        {        
            Application.Quit();
        }

}
