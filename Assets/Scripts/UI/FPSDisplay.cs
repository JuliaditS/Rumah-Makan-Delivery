using UnityEngine;
using UnityEngine.UI;

public class FPSDisplay : MonoBehaviour
{
    public Text fpsText;

    float deltaTime = 0f;
    float fps = 0f;

    private void Awake()
    {        
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        fps = 1 / deltaTime;
        fpsText.text = fps.ToString();
    }
}
