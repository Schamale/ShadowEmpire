﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class _new_game : MonoBehaviour
{

    public AudioSource press_start;

    public void PressNewGame()
    {
        press_start.Play();
        StartCoroutine(DelaySound());
    }
    

    IEnumerator DelaySound()
    {
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
