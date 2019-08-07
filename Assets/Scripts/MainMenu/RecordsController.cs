using UnityEngine;
using UnityEngine.UI;

public class RecordsController : MonoBehaviour
{
    [SerializeField]
    Text rtbs;
    [SerializeField]
    Text wwbs;
    [SerializeField]
    Text acbs;

    public void UpdateRecords()
    {
        CheckKeys();
        rtbs.text = PlayerPrefs.GetFloat("RTBestScore").ToString("0.000");
        wwbs.text = PlayerPrefs.GetInt("WWBestScore").ToString();
        acbs.text = PlayerPrefs.GetInt("ACBestScore").ToString();
    }

    void CheckKeys()
    {
        if (!PlayerPrefs.HasKey("WWBestScore"))
        {
            PlayerPrefs.SetInt("WWBestScore", -999999);
        }
        if (!PlayerPrefs.HasKey("ACBestScore"))
        {
            PlayerPrefs.SetInt("ACBestScore", -999999);
        }
        if (!PlayerPrefs.HasKey("RTBestScore"))
        {
            PlayerPrefs.SetInt("RTBestScore", 99999);
        }
    }
}
