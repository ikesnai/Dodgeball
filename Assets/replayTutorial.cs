﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class replayTutorial : MonoBehaviour
{
    public float timeStart;
    public Text textBox;
    public GameObject restartBtn;
    public GameObject mainMenuBtn;
    public GameObject Ground;
    public GameObject Player;
    public GameObject Dodgeball;

    bool timerActive = true;

    void Start()
    {
        textBox.text = timeStart.ToString("F2");
        showGame(true);
        showBtn(false, restartBtn);
        showBtn(false, mainMenuBtn);
    }

    void Update()
    {
        if (timerActive == true && Player != null)
        {
            timeStart += Time.deltaTime;
            textBox.text = timeStart.ToString("F2");
        }
        else if (timerActive == false && Player == null)
        {
            showBtn(true, restartBtn);
            showBtn(true, mainMenuBtn);
        }
        else
        {
            timerActive = false;
        }
    }

    public void showGame(bool outcome)
    {
        textBox.GetComponent<Text>().enabled = outcome;
        Ground.GetComponent<TilemapRenderer>().enabled = outcome;
        Player.GetComponent<SpriteRenderer>().enabled = outcome;
        Dodgeball.GetComponent<createBall>().enabled = outcome;
    }

    public void showBtn(bool outcome, GameObject Btn)
    {
        Btn.GetComponent<Image>().enabled = outcome;
        Btn.GetComponent<Button>().enabled = outcome;
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("playScreen");
    }

    public void restartGame()
    {
        SceneManager.LoadScene("Game");
	}
}