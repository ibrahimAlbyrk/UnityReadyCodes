using UnityEngine;

public class fixCameraWidth : MonoBehaviour
{
    public float widthToBeSeen;
    void Update()
    {
        Camera.main.orthographicSize = (float)(widthToBeSeen * Screen.height / Screen.width * 0.5);
    }
}
