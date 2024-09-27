using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class teleport_to_quiz : MonoBehaviour
{
	public Transform Teleport;
	public GameObject Text;
	private bool teleported;
	private GameObject player;

	[Header("Индекс сцены")]
	public int sceneIndex;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (teleported == true)
		{
			Text.SetActive(true);
			if (Input.GetKeyDown(KeyCode.E))
			{
				Cursor.lockState = CursorLockMode.None;
				SceneManager.LoadScene(sceneIndex);
				teleported = false;
			}
		}
	}
	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player")
		{
			player = col.gameObject;
			teleported = true;
		}
	}
	void OnTriggerExit(Collider col)
	{
		if (col.tag == "Player")
		{
			teleported = false;
			Text.SetActive(false);
		}
	}

}
