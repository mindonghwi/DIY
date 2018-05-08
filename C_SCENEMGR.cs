using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class C_SCENEMGR : MonoBehaviour {


    public void mainScene()
    {
        SceneManager.LoadScene(1);
    }
    public void defenceScene()
    {
        SceneManager.LoadScene(2);
    }
    public void customScene()
    {
        SceneManager.LoadScene(3);
    }
    public void mapEdittingScene()
    {
        if (GameObject.Find("MapEditer"))
        {
            Destroy(GameObject.Find("MapEditer"));
        }
        SceneManager.LoadScene(4);
    }
    public void shopScene()
    {
        SceneManager.LoadScene(5);
    }
    public void customGameScene()
    {
        SceneManager.LoadScene(6);
    }
    public void storyScene()
    {
        SceneManager.LoadScene(0);
    }
    public void LoginScene()
    {
        SceneManager.LoadScene(7);
    }
    public void CloseScene()
    {
        Application.Quit();
    }
    
}
