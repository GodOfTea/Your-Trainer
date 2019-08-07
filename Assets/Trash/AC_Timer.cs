using UnityEngine;
using UnityEngine.UI;

public class AC_Timer : MonoBehaviour
{
    public Text timer;

    public float minutes, seconds;

    public PauseMenuButton pmb;
    public ACGameContrl gc;
    public CircleSpawner cs;

    void Start()
    {
        minutes = 1f;
        seconds = 30f;
    }

    void Update()
    {
        if (!pmb.menuOpen && cs.startGame && !gc.endGame)
        {
            CountTime();
            timer.text = minutes.ToString("0") + ":" + seconds.ToString("00");
        }

    }

    void CountTime()
    {
        if (seconds <= 0f && minutes <= 0f)
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
