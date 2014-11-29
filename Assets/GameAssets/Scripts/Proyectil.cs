using UnityEngine;
using System.Collections;

public class Proyectil : MonoBehaviour {
	
	public Transform enemigoPrefab;
	public float tiempoVida=10;
	float acumuladorTiempo;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		acumuladorTiempo+=Time.deltaTime;
		if (acumuladorTiempo > tiempoVida){
			Destroy(this.gameObject);
		}
	}
	
	void OnCollisionEnter(Collision collision){
		//Destroy(collision.gameObject);
		if (collision.gameObject.tag=="Enemigo"){
			Enemigo enemigo = collision.gameObject.GetComponent<Enemigo>();
			if (enemigo != null) {
				enemigo.recibirDano(1);
			}
		}
		Destroy(this.gameObject);
	}
}
