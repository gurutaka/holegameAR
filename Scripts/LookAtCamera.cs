using UnityEngine;

public class LookAtCamera : MonoBehaviour 
{
    public GameObject camera;

    void Update () 
    {
        transform.LookAt(camera.transform);
    }
}