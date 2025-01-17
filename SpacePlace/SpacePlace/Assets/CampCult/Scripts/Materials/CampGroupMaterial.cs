﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CampCreateGroup))]
public class CampGroupMaterial : MonoBehaviour {
	
	public enum SpawnType{
		Linear,
		Random
	}

	public Material[] mats;
	public SpawnType orderType;
	int orderNum = -1;
	private CampCreateGroup group;

	// Use this for initialization
	void Start () {
		group = GetComponent<CampCreateGroup>();
		group.onRefresh+= refresh;
	}
	
	// Update is called once per frame
	void refresh () {
		orderNum= -1;
		for(int i = 0; i<group.all.Count;i++){
			if(orderType == SpawnType.Linear){
				orderNum++;
				orderNum%=mats.Length;
				group.all[i].GetComponentInChildren<Renderer>().material = mats[orderNum];
			}else{
				group.all[i].GetComponentInChildren<Renderer>().material = mats[(int)Random.Range(0,mats.Length)];
			}
		}
	}
}
