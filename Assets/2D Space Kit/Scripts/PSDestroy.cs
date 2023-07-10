using UnityEngine;
using System.Collections;

public class PSDestroy : MonoBehaviour {
	//public GameObject ParentGameobject;
	// Use this for initialization
	void Start () {
		Destroy(gameObject, GetComponent<ParticleSystem>().duration);
		//Destroy(ParentGameobject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
