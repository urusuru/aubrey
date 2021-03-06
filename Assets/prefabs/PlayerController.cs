﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using matnesis.TeaTime;

public class PlayerController : MonoBehaviour {

    public PistolController pistol;
    
    // Use this for initialization
    void Start () {

        shootInputRoutine();

        changeBulletRoutine();

        toLastCheckPointRoutine();

        this.tt("lockScreen").Loop(delegate(ttHandler handler) {

			if (Input.GetKey(KeyCode.Tab)) {

				Debug.Log("vamos a ver que pasa");

				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
			}

		});
	}

    public void toLastCheckPointRoutine() {

        this.tt("toLastCheckPointRoutine").Loop(delegate (ttHandler handler) {

            if (Input.GetKeyDown(KeyCode.R))
            {

                //
                // restart, take me to the last checkpoint
                //

                transform.position = GameManager.Get.LastCheckPoint;

            }

        });
    }

    public void addBullet(BulletController.BulletTypeEnum bulletType)
    {
        pistol.addBullet(bulletType);
    }

    void shootInputRoutine() {

        this.tt("shootInputRoutine").Loop(delegate(ttHandler handler) {

            if (Input.GetMouseButton(0)) {

                pistol.shoot();

            }

        });

    }

    void changeBulletRoutine() {

        this.tt("changeBulletRoutine").Loop(delegate (ttHandler handler) {

            if (Input.GetKeyDown(KeyCode.Alpha1)){
                pistol.SetBullet(PistolController.BulletTypeEnum.Black);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2)){
                pistol.SetBullet(PistolController.BulletTypeEnum.Yellow);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                pistol.SetBullet(PistolController.BulletTypeEnum.Red);
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                pistol.SetBullet(PistolController.BulletTypeEnum.Blue);
            }

        });
    }
}
