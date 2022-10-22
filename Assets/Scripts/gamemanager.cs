using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour
{

    bool toggle = true;

    public void endgame() {
        if (toggle) { 
            restart();
            toggle = false;
        }
    }

    void restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }

}
