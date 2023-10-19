using UnityEngine;

public class MainMusicControl : MonoBehaviour
{
    //can we have a slider in inspector that is changeable on this script-c
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
