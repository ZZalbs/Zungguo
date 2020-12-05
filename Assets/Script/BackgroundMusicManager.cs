using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    static BackgroundMusicManager myself = null;
    private void Awake()
    {
        if(myself == null)
        {
            myself = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        if (myself == this) return;
        else Destroy(gameObject);
    }

    void Start()
    {
        //GetComponent<AudioSource>().Play();
    }
}
