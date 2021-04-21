using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public float rotateValue = 0.01f;

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(new Vector3(0, rotateValue, 0));
    }
}