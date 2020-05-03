﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    void Update() {
        if (Input.GetKeyDown(KeyCode.X)) {
            //also play a lil sound and make a transition
            SoundPlayer.quickStart("Sounds/buttonPress");

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);

            
        }
    }
}