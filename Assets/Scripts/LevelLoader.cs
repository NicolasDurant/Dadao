using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public int indexLevelToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        if (collisionGameObject.tag == "Player")
        {
            LoadScene();
        }
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(indexLevelToLoad);
    }
}
