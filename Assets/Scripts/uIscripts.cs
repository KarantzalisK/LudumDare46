using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class uIscripts : MonoBehaviour
{
    public string sceneName;
    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);

        }
      
    }
    public void LoadingScenes(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void SceneQuiting()
    {
        Application.Quit();
    }
    public void unPauseit()
    {
        Time.timeScale = 1;
    }

    
}
