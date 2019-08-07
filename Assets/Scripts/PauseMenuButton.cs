using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuButton : MonoBehaviour
{
    public bool menuOpen;
    SpriteRenderer sr;

    [SerializeField]
    GameObject sound, help, menu;


    private void Start()
    {
        menuOpen = false;
        sr = GetComponent<SpriteRenderer>();
        Buttons();
    }
    void OnMouseDown()
    {
        if (menuOpen)
        {
            sr.color = new Vector4(0f, 0f, 0f, 75/255f);
            sr.flipX = false;
            menuOpen = false;
        }
        else
        {
            sr.color = new Vector4(0f, 0f, 0f, 200/255f);
            sr.flipX = true;
            menuOpen = true;
        }
        Buttons();
    }

    void Buttons()
    {
        Display(menuOpen);
    }

    void Display(bool set)
    {
        sound.SetActive(set);
        menu.SetActive(set);
        help.SetActive(set);
    }
}
