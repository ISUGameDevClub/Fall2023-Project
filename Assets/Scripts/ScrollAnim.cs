using UnityEngine;

public class ScrollAnim : MonoBehaviour
{
    public void AutoBackToMainMenu()
    {
        FindObjectOfType<LevelLoader>().StartTransition("0MainMenu");
        FindObjectOfType<UISFX>().ButtonSelectSFX();
    }
}
