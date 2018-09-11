using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour
{
    public bool recording = true;

    // Use this for initialization
    void Start()
    {
        recording = !CrossPlatformInputManager.GetButton("Fire1");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
