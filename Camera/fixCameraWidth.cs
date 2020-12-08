using UnityEngine;

public class fixCameraWidth : MonoBehaviour
{
    public float visibleWidth;
    void Update()
    {
        Camera.main.orthographicSize = (float)(visibleWidth * Screen.height / Screen.width * 0.5);
    }
}
