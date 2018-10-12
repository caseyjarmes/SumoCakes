﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightResult : MonoBehaviour {

    // Player objects, applied in editor, representing players 1 and 2
    [SerializeField]
    private AttackInput player1;
    [SerializeField]
    private AttackInput player2;

    [SerializeField]
    private GameObject objTimer;
    private Timer timer;

    public Transform space { get; protected set; }

	// Use this for initialization
	void Start ()
    {
        timer = objTimer.GetComponent<Timer>();

        player1.transform.position = new Vector3(-2, 0, 0);
        player2.transform.position = new Vector3(2, 0, 0);
	}
	
	// Update is called once per frame
	void Update ()
    {
        TranslateSpace();
	}

    private int DetermineRound()
    {
        // Player 1 victories
        if (player1.Punched && player2.Headbutted)
        {
            return 1;
        }
        else if (player1.Headbutted && player2.Kicked)
        {
            return 2;
        }
        else if (player1.Kicked && player2.Punched)
        {
            return 3;
        }

        // Player 2 victories
        else if (player2.Punched && player1.Headbutted)
        {
            return -1;
        }
        else if (player2.Headbutted && player1.Kicked)
        {
            return -2;
        }
        else if (player2.Kicked && player1.Punched)
        {
            return -3;
        }
        else return 0;
    }

    private void TranslateSpace()
    {
        if (timer.TimeUp)
        {
            player1.transform.Translate(DetermineRound(), 0, 0);
            player2.transform.Translate(DetermineRound(), 0, 0);
        }
    }
}