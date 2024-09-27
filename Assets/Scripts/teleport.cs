using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[AddComponentMenu("My components/teleport")]
public class teleport : MonoBehaviour
{
    [Header("Индекс сцены")]
    public int sceneIndex;

    void OnTriggerEnter(Collider myCollider)
    {
        if (myCollider.tag == ("Player"))
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}

