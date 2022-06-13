using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Splashscreen : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public int goToScene;
    
    // Start is called before the first frame update
    void Awake()
    {
        videoPlayer.loopPointReached += Endvid;
    }

    public void Endvid(VideoPlayer vp)
    {
        SceneManager.LoadScene(goToScene);
    }
}
