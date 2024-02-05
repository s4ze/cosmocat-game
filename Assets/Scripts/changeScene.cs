using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    public void ButtonPlay()
    {
        SceneManager.LoadScene("AstroidMove");
    }
}
