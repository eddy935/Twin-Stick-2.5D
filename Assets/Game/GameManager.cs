using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        public bool recording = true;

        bool isPaused;
        float fixedDeltaTime;

        void Start()
        {
            PlayerPrefsManager.UnlockLevel(2);
            print(PlayerPrefsManager.IsLevelUnlocked(1));
            print(PlayerPrefsManager.IsLevelUnlocked(2));

            fixedDeltaTime = Time.fixedDeltaTime;
            print(fixedDeltaTime);
        }

        // Update is called once per frame
        void Update()
        {
            recording = !CrossPlatformInputManager.GetButton("Fire1");

            if (Input.GetKeyDown(KeyCode.P) && isPaused)
            {
                isPaused = false;
                ResumeGame();
            }
            else if (Input.GetKeyDown(KeyCode.P) && !isPaused)
            {
                isPaused = true;
                PauseGame();
            }
        }

        void ResumeGame()
        {
            Time.timeScale = 1;
            Time.fixedDeltaTime = fixedDeltaTime;
        }

        void PauseGame()
        {
            Time.timeScale = 0;
            Time.fixedDeltaTime = 0;
        }

        void OnApplicationPause(bool pauseStatus)
        {
            isPaused = pauseStatus;
        }
    }
}
