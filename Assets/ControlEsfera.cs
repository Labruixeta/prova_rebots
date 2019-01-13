using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EstatEsfera {Neix,Creix,Repro,Mort}

public class ControlEsfera : MonoBehaviour {
    public int contador = 1;
    public Vector3 posicio;
    public GameObject esfera;
    public EstatEsfera estatesfera = EstatEsfera.Neix;

    void Start ()
    {
        esfera = Resources.Load<GameObject>("Sphere");
        GetComponent<Transform>().localScale = new Vector3(0f, 0f, 0f);
        //GetComponent<Rigidbody> ().velocity = new Vector2 (Random.Range(-5f,5f),Random.Range(-5f,5f));
	}
	
	void Update ()
    {
        //---------------------------------------------------------------------------------
        //                                      NEIXEMENT
        //---------------------------------------------------------------------------------
        if (estatesfera == EstatEsfera.Neix)
        {
            contador++;
            if (contador == 10)
            {
                GetComponent<Transform>().localScale = new Vector3(GetComponent<Transform>().localScale.x + 0.1f, GetComponent<Transform>().localScale.y + 0.1f, GetComponent<Transform>().localScale.z + 0.1f);

                if (GetComponent<Transform>().localScale.x > 0.9f)
                {
                    estatesfera = EstatEsfera.Creix;
                    GetComponent<Rigidbody> ().velocity = new Vector2 (Random.Range(-2f,2f),Random.Range(-2f,2f));
                }
                contador = 1;
            }
        }
        //---------------------------------------------------------------------------------
        //                                      CREIXEMENT
        //---------------------------------------------------------------------------------
       else if (estatesfera == EstatEsfera.Creix)
        {
            contador++;
            if (contador == 10)
            {
                GetComponent<Transform>().localScale = new Vector3(GetComponent<Transform>().localScale.x * 1.005f, GetComponent<Transform>().localScale.y * 1.005f, GetComponent<Transform>().localScale.z * 1.005f);
                if (GetComponent<Transform>().localScale.x > 1.5f)
                {
                    estatesfera = EstatEsfera.Repro;
                }
                contador = 1;
            }
        }
        //---------------------------------------------------------------------------------
        //                                      REPRODUCCIó
        //---------------------------------------------------------------------------------
        else if (estatesfera == EstatEsfera.Repro)
        {
                posicio = transform.position;
                posicio = new Vector3(posicio.x + 0.2f, posicio.y + 0.2f, posicio.z);
                Instantiate(esfera, posicio, Quaternion.identity);
                GetComponent<Transform>().localScale = new Vector3(1f, 1f, 1f);
                estatesfera = EstatEsfera.Creix;
        }
    }
}
