using UnityEngine;
using System.Collections;

public class Enemigo : MonoBehaviour {
	
	public float velocidad=2f;
	CharacterController cmpCharacterComtroller;
	public Transform barraDeVida;
	public Material materialVerde;
	public Material materialRojo;
	public float vidaMaxima=2;
	public float vidaActual;
	
	// Use this for initialization
	void Start () {
		
		cmpCharacterComtroller = GetComponent<CharacterController>();
		StartCoroutine(CambioDireccionCorrutina());
		float anguloAleatorio = Random.Range(0.0f,360.0f);
		this.transform.rotation=Quaternion.AngleAxis(anguloAleatorio,Vector3.up);
		vidaActual=vidaMaxima;
	}
	
	// Update is called once per frame
	void Update () {
		//this.transform.position += new Vector3(0,0,0.5f)*Time.deltaTime;
		cmpCharacterComtroller.SimpleMove(this.transform.forward*velocidad);
	}
	
	IEnumerator CambioDireccionCorrutina(){
		while(true){
			yield return new WaitForSeconds(3);
			float anguloAleatorio = Random.Range(0.0f,360.0f);
			this.transform.rotation=Quaternion.AngleAxis(anguloAleatorio,Vector3.up);
		}
	}
	
	public void recibirDano(int dano){
		vidaActual-=dano;
		
		float anchoMaximoBarra = 1;
		float porcentajeVida=vidaActual/vidaMaxima;
		float anchoActualBarra = anchoMaximoBarra*porcentajeVida;
		
		Vector3 tamañoActual = barraDeVida.localScale;
		tamañoActual.x=anchoActualBarra;
		barraDeVida.localScale=tamañoActual;
		
		if (porcentajeVida > 0.5){
			barraDeVida.renderer.material=materialVerde;
		}else {
			barraDeVida.renderer.material=materialRojo;
		}
		
		if (vidaActual<=0){
			Destroy(this.gameObject);
		}
	}
}
