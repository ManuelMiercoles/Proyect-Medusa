﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public void startGame()
    {
        SceneManager.LoadScene("Nivel 1");
    }
}
