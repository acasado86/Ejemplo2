using UnityEngine;
using System.Collections;

public class disparo : MonoBehaviour {
	
	public Transform proyectilPrefab;
	public Transform posicionDisparo;
	public float fuerzaDisparo=10f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if ( (Input.GetKeyDown(KeyCode.LeftControl) ) || (Input.GetMouseButtonDown(0))) {
			Transform nuevoProyectil;
			nuevoProyectil = (Transform) Instantiate(proyectilPrefab);
			nuevoProyectil.transform.position = this.posicionDisparo.transform.position;
			nuevoProyectil.rigidbody.AddForce(this.posicionDisparo.transform.forward*fuerzaDisparo, ForceMode.Impulse);
		}
	}
}
