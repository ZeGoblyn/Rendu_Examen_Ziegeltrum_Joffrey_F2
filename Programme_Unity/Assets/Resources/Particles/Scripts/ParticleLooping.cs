﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLooping : MonoBehaviour {
	[SerializeField] private GameObject fxPrefab;
	[SerializeField] private float intervalMin;
	[SerializeField] private float intervalMax;
	[SerializeField] private float positionFactor;
	[SerializeField] private float killtime;

	private void Start () {
		InvokeRepeating ("Burst", 0.0F, Random.Range (intervalMin, intervalMax));
	}

	private void Burst () {
		if (gameObject.activeSelf == false)
			return;

		GameObject clone;
		Vector3 pos = transform.position;
		pos.x += Random.Range (-positionFactor, positionFactor);
		pos.y += Random.Range (-positionFactor, positionFactor);
		pos.z += Random.Range (-positionFactor, positionFactor);
		
		clone = Instantiate (fxPrefab, pos, transform.rotation);
		//clone.transform.parent = transform;
		//clone.transform.localPosition = pos;
		Destroy (clone.gameObject, killtime);
	}
}