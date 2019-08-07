
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    [SerializeField]
    GameObject MenuUI;
    [SerializeField]
    GameObject PlayMenuUI;
    [SerializeField]
    GameObject RecordsMenuUI;
    [SerializeField]
    RecordsController rc;

    // void Start()
    // {
    //     rc = GameObject.FindGameObjectWithTag("RecordsMenu").GetComponent<RecordsController>();
    // }

    public void NextStep(string button)
    {
        switch (button)
        {
            case "Play":
                PlayButton();
                break;
            case "Records":
                RecordsButton();
                break;
            case "Settings":
                MenuUI.SetActive(false);
                break;
            case "Reaction Test":
                SceneManager.LoadScene(1);
                break;
            case "Wrong Way":
                SceneManager.LoadScene(2);
                break;
            case "Accuracy Circle":
                SceneManager.LoadScene(3);
                break;
            case "Back":
                BackButton();
                break;
        }
    }


    void BackButton()
    {
        
    }

    void PlayButton()
    {
        MenuUI.SetActive(false);
        PlayMenuUI.SetActive(true);
    }

    void RecordsButton()
    {
        MenuUI.SetActive(false);
        rc.UpdateRecords();
        RecordsMenuUI.SetActive(true);
    }
}
