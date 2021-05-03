using UnityEngine;
using UnityEngine.SceneManagement;

public class Cheats : MonoBehaviour
{
    bool isColiding = true;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ChangeColision();
        NextLevel();
    }

    void ChangeColision ()
    {
        if (Input.GetKey(KeyCode.C))
        {
            ShakeItUp();
        }
    }

    void ShakeItUp ()
    {
        if(isColiding == true)
        {
            GetComponent<CapsuleCollider>().enabled = false;
            isColiding = false;
        }
        else if (isColiding == false)
        {
            GetComponent<CapsuleCollider>().enabled = true;
            isColiding = true;
        }
     }

    void NextLevel ()
    {
        if (Input.GetKey(KeyCode.L))
        {
            int nextLevelIndex = SceneManager.GetActiveScene().buildIndex + 1;
            if(nextLevelIndex == SceneManager.sceneCountInBuildSettings)
            {
                nextLevelIndex = 0;
            }
            SceneManager.LoadScene(nextLevelIndex);
        }
    }

}
