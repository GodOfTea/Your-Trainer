using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsClick : MonoBehaviour
{
    [SerializeField]
    MenuButtons mb;
    void OnMouseDown()
    {
        mb.NextStep(gameObject.name);
    }
}
