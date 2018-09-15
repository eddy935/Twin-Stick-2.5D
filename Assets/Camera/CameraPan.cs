using UnityEngine;

namespace Camera
{
    public class CameraPan : MonoBehaviour
    {
        GameObject player;


        // Use this for initialization
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        void LateUpdate()
        {
            transform.LookAt(player.transform);
        }
    }
}
