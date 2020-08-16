using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {

	[Tooltip("In seconds")][SerializeField] float levelLoadDelay = 1f;
	[Tooltip("FX on death prefab")][SerializeField] GameObject deathFX = null;

	private void OnTriggerEnter(Collider other)
	{
		StartDeathSequence();
	}

	private void StartDeathSequence()
	{
		SendMessage("OnPlayerDeath");
		deathFX.SetActive(true);
		Invoke("ReloadScene", levelLoadDelay);
	}

	private void ReloadScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
