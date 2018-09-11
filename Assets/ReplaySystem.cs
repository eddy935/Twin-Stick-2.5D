using UnityEngine;

public class ReplaySystem : MonoBehaviour
{
    const int BUFFER_FRAMES = 100;
    MyKeyFrame[] keyFrames = new MyKeyFrame[BUFFER_FRAMES];

    Rigidbody myRigidbody;
    GameManager gameManager;

    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.recording)
        {
            RecordFrames();
        }
        else
        {
            PlayBack();
        }
    }

    void PlayBack()
    {
        myRigidbody.isKinematic = true;
        var frame = Time.frameCount % BUFFER_FRAMES;
        print("Reading frame " + frame);

        transform.position = keyFrames[frame].position;
        transform.rotation = keyFrames[frame].rotation;
    }

    void RecordFrames()
    {
        myRigidbody.isKinematic = false;

        var frame = Time.frameCount % BUFFER_FRAMES;
        var time = Time.time;
        print("Writing Frame " + frame);

        keyFrames[frame] = new MyKeyFrame(time, transform.position, transform.rotation);
    }
}


/// <summary>
/// Structure for storing Time, Rotation & Position
/// </summary>
public struct MyKeyFrame
{
    public float frameTime;
    public Vector3 position;
    public Quaternion rotation;

    public MyKeyFrame(float aTime, Vector3 aPosition, Quaternion aRotation)
    {
        frameTime = aTime;
        position = aPosition;
        rotation = aRotation;
    }
}
