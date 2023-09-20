using UnityEngine;

public class BgMusic : MonoBehaviour
{
    private static BgMusic _bgMusic;

    private void Awake()
    {
        if (_bgMusic == null)
        {
            DontDestroyOnLoad(gameObject);
            _bgMusic = this;
        }
        else if (_bgMusic != this)
        {
            Destroy(gameObject);
        }
    }

}
