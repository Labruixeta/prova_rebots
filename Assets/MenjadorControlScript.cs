using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenjadorControlScript : MonoBehaviour {
	public bool estatMenjador = false;
	public GameObject menjar;
	public Vector3 posicioMenjar;

	void Start () {
	}
	

	void Update () {
		if (estatMenjador == false) {
			if (GameObject.FindGameObjectWithTag ("Menjar") != null) {
				menjar = GameObject.FindGameObjectWithTag ("Menjar");
				estatMenjador = true;
			} else {
				print ("Tot Menjat!");
			}
		} else {
			posicioMenjar = menjar.transform.position;
			GetComponent<Rigidbody>().transform.position = Vector3.MoveTowards(transform.position, posicioMenjar, 10f * Time.deltaTime);
			estatMenjador = false;
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag=="Menjar"){
			Destroy (other.gameObject);
		}
	}




}
