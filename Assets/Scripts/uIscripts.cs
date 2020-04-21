using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class uIscripts : MonoBehaviour
{
    public string sceneName;
    public GameObject pauseMenu;

    public GameObject gamePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1 )
        {
            pauseMenu.SetActive(true);

        }
        if (pauseMenu.activeSelf)
        {
            Time.timeScale = 0;

        }
        else Time.timeScale = 1;

    }
    public void LoadingScenes(string sceneName)
    {
        //SceneManager.LoadScene(sceneName);
        Destroy(GameObject.Find("Game"));
        Instantiate(gamePrefab);
        pauseMenu = GameObject.Find("PauseMenu");

    }
    public void SceneQuiting()
    {
        Application.Quit();
    }
    

    
}
