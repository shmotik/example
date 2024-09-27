using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoverable : MonoBehaviour
{
 private void OnMouseEnter()
    {
        UIManager.SetOnHoverText(gameObject.name);
    }

    private void OnMouseExit()
    {
        UIManager.OffOnHoverText();
    }
}
