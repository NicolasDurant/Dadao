using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLoader : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
