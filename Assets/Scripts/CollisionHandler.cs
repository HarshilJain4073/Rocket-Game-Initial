using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField]float levelLoadDelay = 1f;
    void OnCollisionEnter(Collision other) {
        switch(other.gameObject.tag)
        {
            case "Spawn":
                Debug.Log("This is spawn point");
                break;
            case "Fuel":
                Debug.Log("This is the fuel");
                break;
            case "Finish":
                startNextlevelsequence();
                Debug.Log("Successfully landed");
                break;
            default:
                StartCrashSequence();
                Debug.Log("Please balance rocket");
                break;
        }
    }

    private void startNextlevelsequence()
    {
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel",levelLoadDelay);
    }

    void StartCrashSequence()
    {
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel",levelLoadDelay);
    }

    private void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int NextSceneIndex = currentSceneIndex + 1;
        if(NextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            NextSceneIndex = 0;
        }

        SceneManager.LoadScene(NextSceneIndex);
    }

    private void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
