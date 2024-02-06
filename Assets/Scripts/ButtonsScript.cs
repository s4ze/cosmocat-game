using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartGame()
    {
        Debug.Log("��������");
        SceneManager.LoadScene("AstroidMove");
        SceneManager.UnloadSceneAsync("menu");
    }
    public void CloseApplication()
    {
        Application.Quit();
    }
    public void ToMenu()
    {
        SceneManager.LoadScene("menu");
    }
    public void ToRetry()
    {
        SceneManager.LoadScene("menu");
    }
}
