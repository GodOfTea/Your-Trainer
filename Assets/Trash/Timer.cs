using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private Text _timer;
    [SerializeField]
    float minutes, seconds;

    public PauseMenuButton pmb;
    public WW_GameContrl gc;

	void Start ()
    {
        minutes = 0f;
        seconds = 10f;
	}

	void Update ()
    {
        if (!pmb.menuOpen)
        {
            CountTime();
            _timer.text = minutes.ToString("0") + ":" + seconds.ToString("00");
        }
        
    }

    void CountTime ()
    {
        if (seconds <= 0 && minutes <= 0)
        {
            gc.EndGame();
        }
        else
        {
            seconds -= Time.deltaTime;
            if (seconds <= 0f && minutes == 1f)
            {
                minutes = 0;
                seconds = 59;
            }
        }
    }
}
