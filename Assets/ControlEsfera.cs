using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EstatEsfera {Neix,Creix,Repro,Mort}

public class ControlEsfera : MonoBehaviour {
    public int contador = 0;
    public Vector3 posicio;
    public GameObject esfera;
    public bool part = false;
    public EstatEsfera estatesfera = EstatEsfera.Neix;

    void Start ()
    {
        esfera = Resources.Load<GameObject>("Sphere");
        GetComponent<Transform>().localScale = new Vector3(0f, 0f, 0f);
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
                float escala = 0.05f;
                GetComponent<Transform>().localScale = new Vector3(GetComponent<Transform>().localScale.x + escala, GetComponent<Transform>().localScale.y + escala, GetComponent<Transform>().localScale.z + escala);

                if (GetComponent<Transform>().localScale.x > 0.9f)
                {
                    estatesfera = EstatEsfera.Creix;
                    GetComponent<Rigidbody> ().velocity = new Vector2 (Random.Range(-2f,2f),Random.Range(-2f,2f));
                }
                contador = 0;
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
                if (GetComponent<Transform>().localScale.x > 1.5f && !part)
                {
                    estatesfera = EstatEsfera.Repro;
                }
                if (GetComponent<Transform>().localScale.x > 2.0f && part)
                {
                    estatesfera = EstatEsfera.Mort;
                }
                    contador = 0;
            }
        }
        //---------------------------------------------------------------------------------
        //                                      REPRODUCCIó
        //---------------------------------------------------------------------------------
        else if (estatesfera == EstatEsfera.Repro)
        {
            if (!part)
            {
               // GetComponent<Rigidbody>().velocity = new Vector2(0f,0f);
                posicio = transform.position;
               // posicio = new Vector3(posicio.x + 0.2f, posicio.y + 0.2f, posicio.z);
                part = true;
            }
            else
            {
                float escala = -0.01f;
                GetComponent<Transform>().localScale = new Vector3(GetComponent<Transform>().localScale.x + escala, GetComponent<Transform>().localScale.y + escala, GetComponent<Transform>().localScale.z + escala);
                if (GetComponent<Transform>().localScale.x<1.01f)
                {
                    Instantiate(esfera, posicio, Quaternion.identity);
                    //  GetComponent<Rigidbody>().velocity = new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f));
                    estatesfera = EstatEsfera.Creix;
                }
            }
        }else if (estatesfera==EstatEsfera.Mort)
        {
            contador++;
            if (contador==10)
            {
                Destroy(gameObject);
            }
        }
    }
}
