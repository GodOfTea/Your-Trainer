using UnityEngine;

public class Screen_Space : MonoBehaviour 
{
	float WidthUnits = 6;
	float HeightUnits = 10;

	public float ScreenWidth;
	public float ScreenHeight;

    public float widthBoarder;
    public float heightBoarder;

    public float unitSize;

    void Start () 
	{
        SwitchResolution(Screen.width, Screen.height);
    }

	void SwitchResolution (float width, float height)
	{
        unitSize = height / 5;
        ScreenWidth = Screen.width;
        ScreenHeight = Screen.height;
        widthBoarder = width / WidthUnits * 1f; //1 uint
        heightBoarder = height / HeightUnits * 3.5f; //3.5 units
    }
}
