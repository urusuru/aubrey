﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PistolController : MonoBehaviour {

    public enum BulletTypeEnum { Black, Blue, Red, Yellow };

    public Dictionary<BulletController.BulletTypeEnum, int> bulletsCounter;

    public Material[] bulletMaterials;

    public BulletController bulletPrefab;

    public float bulletSpeed = 50f;

    public  TextMesh pistolText;


    // Use this for initialization
    void Start () {

        bulletsCounter = new Dictionary<BulletController.BulletTypeEnum, int>();

        bulletsCounter[BulletController.BulletTypeEnum.Black] = 0;
        bulletsCounter[BulletController.BulletTypeEnum.Blue] = 0;
        bulletsCounter[BulletController.BulletTypeEnum.Red] = 0;
        bulletsCounter[BulletController.BulletTypeEnum.Yellow] = 0;

        pistolText.text = "∞";

        SetBullet(BulletTypeEnum.Black);

    }

    public void shoot(){

        //
        // instantiante the bullet and fire it
        //

        GameObject bullet = (GameObject)Instantiate(bulletPrefab.gameObject, transform.position, Quaternion.identity);

        bullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
    }

    public void addBullet(BulletController.BulletTypeEnum bulletType)
    {
        bulletsCounter[bulletType]++;

        Debug.Log(bulletsCounter[BulletController.BulletTypeEnum.Black]);
        Debug.Log(bulletsCounter[BulletController.BulletTypeEnum.Blue]);
        Debug.Log(bulletsCounter[BulletController.BulletTypeEnum.Red]);
        Debug.Log(bulletsCounter[BulletController.BulletTypeEnum.Yellow]);
    }

    public void SetBullet(BulletTypeEnum bulletType){

        if (bulletType == BulletTypeEnum.Black) {

            pistolText.color = Color.black;

            pistolText.text = "∞";

            bulletPrefab.GetComponent<Renderer>().material = bulletMaterials[0];

            bulletPrefab.bulletType = BulletController.BulletTypeEnum.Black;

            bulletPrefab.GetComponent<TrailRenderer>().sharedMaterial.SetColor("_EmissionColor", new Color(0.0f, 0.0f, 0.0f));
        }

        if (bulletType == BulletTypeEnum.Blue){

            pistolText.color = Color.blue;

            pistolText.text = "" + bulletsCounter[BulletController.BulletTypeEnum.Blue];

            bulletPrefab.GetComponent<Renderer>().material = bulletMaterials[1];

            bulletPrefab.bulletType = BulletController.BulletTypeEnum.Blue;

            bulletPrefab.GetComponent<TrailRenderer>().sharedMaterial.SetColor("_EmissionColor", new Color(0.0f, 0.0f, 1.0f));
        }

        if (bulletType == BulletTypeEnum.Red){

            pistolText.color = Color.red;

            pistolText.text = "" + bulletsCounter[BulletController.BulletTypeEnum.Red];

            bulletPrefab.GetComponent<Renderer>().material = bulletMaterials[2];

            bulletPrefab.bulletType = BulletController.BulletTypeEnum.Red;

            bulletPrefab.GetComponent<TrailRenderer>().sharedMaterial.SetColor("_EmissionColor", new Color(1.0f, 0.0f, 0.0f));
        }

        if (bulletType == BulletTypeEnum.Yellow)
        {
            pistolText.color = Color.yellow;

            pistolText.text = "" + bulletsCounter[BulletController.BulletTypeEnum.Yellow];

            bulletPrefab.GetComponent<Renderer>().material = bulletMaterials[3];

            bulletPrefab.bulletType = BulletController.BulletTypeEnum.Yellow;

            bulletPrefab.GetComponent<TrailRenderer>().sharedMaterial.SetColor("_EmissionColor", new Color(1.0f, 1.0f, 0.0f));
        }
    }
}
