using UnityEngine;

public class ACCircleContrl : MonoBehaviour {

	public CircleSpawner cs;
    public ACGameContrl gc;
    public PauseMenuButton pmb;
    [SerializeField]
    Vector3 scale;
    [SerializeField]
    Vector3 speed = new Vector3(0.000001f, 0.000001f, 0);
    bool maxCircleSize;
    public int points;


	void Start ()
	{
        points = 200;
        maxCircleSize = false;
        cs = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CircleSpawner>();
        gc = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ACGameContrl>();
        pmb = GameObject.FindGameObjectWithTag("PauseArrow").GetComponent<PauseMenuButton>();
    }

	void OnMouseDown()
	{
        if (!pmb.menuOpen)
        {
            gc.UpdateScore(points);
            Destroy(gameObject);
            cs.SpawnNewCircle();
        }
    }
    void CountSizeCirlce()
    {
        scale = gameObject.transform.localScale;
        if (scale.x >= 2.0f && scale.y >= 2.0f)
            maxCircleSize = true;
        if (!maxCircleSize)
            gameObject.transform.localScale += speed;
        else
        {
            gameObject.transform.localScale -= speed;
            if (scale.x <= 0f && scale.y <= 0f)
            {
                points = -300;
                gc.UpdateScore(points);
                Destroy(gameObject);
                cs.SpawnNewCircle();
            }
        }
    }

	void Update ()
	{
        if (gc.endGame)
        {
            Destroy(gameObject);
        }
        if (!pmb.menuOpen)
        {
            CountSizeCirlce();
        }
    }
}
