using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
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
                Debug.Log("Successfully landed");
                break;
            default:
                ReloadLevel();
                Debug.Log("PLease balance rocket");
                break;
        }
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(0);
    }
}
