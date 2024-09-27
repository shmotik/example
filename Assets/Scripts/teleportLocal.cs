using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportLocal : MonoBehaviour
{
	public Transform Teleport;
	public GameObject Text;
	private bool teleported;
	private GameObject player;
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
				player.transform.position = Teleport.position;
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
