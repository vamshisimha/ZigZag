using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public static BackgroundMusic backgroundMusic;
    private void Awake()
    {
        if(backgroundMusic == null)
        {
            backgroundMusic = this;
        }
        else if(backgroundMusic != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
}
