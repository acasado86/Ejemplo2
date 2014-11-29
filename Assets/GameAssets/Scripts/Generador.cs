using UnityEngine;
using System.Collections;

public class Generador : MonoBehaviour {
	
	public Transform enemigoPrefab;
	public float tiempoEspera = 5;
	public float altura = 2;
	// Use this for initialization
	void Start () {
		StartCoroutine(GenerarEnemigosCorrutina());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	IEnumerator GenerarEnemigosCorrutina(){
		while (true){
			yield return new WaitForSeconds(tiempoEspera);
			Transform nuevoEnemigo = (Transform) Instantiate(enemigoPrefab);
			nuevoEnemigo.position = this.transform.position + new Vector3(0,altura,0);
		}
	}
}
