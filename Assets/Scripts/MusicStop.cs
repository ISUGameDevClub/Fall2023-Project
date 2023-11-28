using UnityEngine;

public class MainMusicControl : MonoBehaviour
{
    
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
