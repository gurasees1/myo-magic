﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;

public class PlayerMove : MonoBehaviour {

    public GameObject myo = null;

    public GameObject spell_1;
    public GameObject spell_2;
    public GameObject spell_3;

    private double endTime;

    // Use this for initialization
    void Start () {
        endTime = DateTime.Now.TimeOfDay.TotalSeconds;
    }
	
	// Update is called once per frame
	void Update () {
        ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo>();

        if (Input.GetKeyDown("a") && endTime < DateTime.Now.TimeOfDay.TotalSeconds) {
            GameObject spell = Instantiate((GameObject)spell_1, new Vector3(0, 3, -13), transform.rotation) as GameObject;
            spell.gameObject.GetComponent<BoulderSpell>().z_direction = 1;
            endTime = DateTime.Now.TimeOfDay.TotalSeconds + 2;
            ExtendUnlockAndNotifyUserAction(thalmicMyo);
        }

        if (Input.GetKeyDown("s") && endTime < DateTime.Now.TimeOfDay.TotalSeconds) {
            GameObject spell = Instantiate((GameObject)spell_2, new Vector3(0, 20, -20), transform.rotation) as GameObject;
            spell.gameObject.GetComponent<MeteorScript>().direction = 1;
            endTime = DateTime.Now.TimeOfDay.TotalSeconds + 2;
        }

        if (Input.GetKeyDown("d") && endTime < DateTime.Now.TimeOfDay.TotalSeconds) {
            GameObject spell = Instantiate((GameObject)spell_3, new Vector3(0, 0, 0), transform.rotation) as GameObject;
            spell.gameObject.GetComponent<DigitalRuby.LightningBolt.LightningBoltScript>().StartPosition = new Vector3(0, 2.5f, -18);
            spell.gameObject.GetComponent<DigitalRuby.LightningBolt.LightningBoltScript>().EndPosition = new Vector3(0, 3, 20);
            endTime = DateTime.Now.TimeOfDay.TotalSeconds + 2;
        }
    }
    void ExtendUnlockAndNotifyUserAction(ThalmicMyo myo)
    {
        ThalmicHub hub = ThalmicHub.instance;

        if (hub.lockingPolicy == LockingPolicy.Standard)
        {
            myo.Unlock(UnlockType.Timed);
        }

        myo.NotifyUserAction();
    }
}
