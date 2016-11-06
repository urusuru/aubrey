﻿using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using matnesis.TeaTime;


public class DoorController : MonoBehaviour {

    public List<SwitchController> requiredSwitches;

    public Transform endPosition;

	// Use this for initialization
	void Start () {

        this.tt("checkSwitchesRoutine").Loop(300f, delegate(ttHandler handler) {

            requiredSwitches.ForEach(delegate (SwitchController switchC){

                //Debug.Log(switchC.buttonIsPressed);

            });

            bool stillPending = requiredSwitches.Any(r => !r.buttonIsPressed);

            if (!stillPending)
            {
                Debug.Log("abriendo puerta");

                openDoor();
                handler.EndLoop();

            }

        });


	}

    void openDoor() {

        Vector3 startPosition = transform.position;

        this.tt("openDoorRoutine").Loop(2f, delegate (ttHandler handler){

            transform.position = Vector3.Lerp(startPosition, endPosition.position, handler.t);

        });

    }
}