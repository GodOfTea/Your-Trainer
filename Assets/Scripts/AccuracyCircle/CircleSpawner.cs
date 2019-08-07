using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CircleSpawner : MonoBehaviour {


    [SerializeField]
    Text startTimer;
	public GameObject circlePrefab;
	float x = 0 , y = 0;
    float timer = 0;
    public bool startGame;

    public ACGameContrl gc;
    public Screen_Space scr;
    public PauseMenuButton pmb;

    void Start () 
	{
        startGame = false;
        startTimer = GameObject.FindGameObjectWithTag("Counting").GetComponent<Text> ();
        StartCoroutine (StartCount ());
	}

    IEnumerator StartCount ()
    {
        int count = 3;
        while (count != 0)
        {
            yield return new WaitForSeconds(1f);
            //Debug.Log(count);
            count--;
            startTimer.text = count.ToString();
        }
        yield return new WaitForSeconds(1f);
        Destroy(startTimer);
        startGame = true;
        SpawnNewCircle();
        yield return new WaitForSeconds(1f);
        SpawnNewCircle();
        yield return new WaitForSeconds(1f);
        SpawnNewCircle();
    }

    void Update()
    {
        if (!pmb.menuOpen && startGame && !gc.endGame)
        {
            timer += Time.deltaTime;
            if (timer >= 30f)
            {
                SpawnNewCircle();
                timer = 0f;
            }
        }
    }

    public void SpawnNewCircle()
    {
        if (!gc.endGame)
        {
            x = Random.Range(-scr.ScreenWidth + scr.widthBoarder/* + 150*/, scr.ScreenWidth - scr.widthBoarder/* - 150*/) / scr.unitSize;
            y = Random.Range(-scr.ScreenHeight + scr.heightBoarder/* + 300*/, scr.ScreenHeight - scr.heightBoarder/* - 500*/) / scr.unitSize;
            Instantiate(circlePrefab, new Vector3(x, y, 0), Quaternion.identity);
        }
    }
}
