﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{

    public Bullet prefabbullet;
    private Bullet bullet;

    void Start()
    {
        InstantiateBullet();
    }

    // Update is called once per frame
    void Update()
    {
        if(bullet == null)
        {
            InstantiateBullet();
        }
    }

    private void InstantiateBullet()
    {
        bullet = Instantiate(prefabbullet, transform);
        bullet.transform.localPosition = new Vector3(0.003f, -0.297f, 0);
    }


}

