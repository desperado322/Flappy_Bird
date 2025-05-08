using UnityEngine;
using System.Collections.Generic;

public class SaveMusicOnScene : MonoBehaviour
{
    [SerializeField] private string _musicTag;

    private void Awake()
    {
        GameObject _music = GameObject.FindWithTag(_musicTag);

        if (_music != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            gameObject.tag = _musicTag;
            DontDestroyOnLoad(gameObject);
        }
    }
}