using UnityEngine;

namespace Camera
{
    public class CameraArm : MonoBehaviour
    {
        [SerializeField] float panSpeed = 10f;

        GameObject player;
        Vector3 armRotation;

        // Use this for initialization
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            armRotation = transform.rotation.eulerAngles;
        }

        void Update()
        {
            armRotation.y += Input.GetAxis("RightHoriz") * panSpeed;
            armRotation.x += Input.GetAxis("RightVert") * panSpeed;

            transform.position = player.transform.position;
            transform.rotation = Quaternion.Euler(armRotation);
        }
    }
}
