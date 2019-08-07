using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMainMenu : MonoBehaviour
{
    void OnMouseDown()
    {
        SceneManager.LoadScene(0);
    }
}
