using UnityEngine;
using UnityEngine.UI;

public class Common_timer : MonoBehaviour
{
    public PauseMenuButton pmb;

    public Text timer;
    [SerializeField]
    float minutes, seconds;
    void Start()
    {
        minutes = 1f;
        seconds = 30f;
    }

    public bool CountTime()
    {
        timer.text = minutes.ToString("0") + ":" + seconds.ToString("00");
        if (seconds <= 0f && minutes <= 0f)
        {
            return true;
        }
        else
        {
            seconds -= Time.deltaTime;
            if (seconds <= 0f && minutes == 1f)
            {
                minutes = 0;
                seconds = 59;
            }
            return false;
        }
    }
}
