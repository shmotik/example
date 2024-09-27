using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{

    private static TextMeshProUGUI OnHoverText;

    void Start()
    {
        OnHoverText = GameObject.Find("teleportmenu/OnHoverText").GetComponent<TextMeshProUGUI>();
    }

    public static void SetOnHoverText(string objName)
    {
        OnHoverText.text = objName;
    }

    public static void OffOnHoverText()
    {
        OnHoverText.text = "";
    }
 
}
