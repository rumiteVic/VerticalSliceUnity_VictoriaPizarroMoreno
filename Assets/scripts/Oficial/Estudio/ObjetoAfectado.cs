using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class ObjetoAfectado : MonoBehaviour
{

    public List<Pociones.TipoPociones> efectosPermitidos;
    public MostrarTexto leTexto;
    float duracion = 2f;
    Vector3 escalaMax;
    Vector3 escalaMin;
    Vector3 escalaInicio;
    Vector3 escalaObjetivo;
    public BoxCollider coll;
    bool esSaltarin = false;


    public string identificador;
    public bool esMaqueta;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        escalaInicio = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        escalaMin = new Vector3(transform.localScale.x * 0.5f, transform.localScale.y * 0.5f, transform.localScale.z * 0.5f);
        escalaMax = new Vector3(transform.localScale.x * 2, transform.localScale.y * 2, transform.localScale.z * 2);
        escalaObjetivo = escalaInicio;
        coll = coll.GetComponent<BoxCollider>();
        if (ConexionConMaqueta.Instance != null)
        {
            List<Pociones.TipoPociones> efectos =
                ConexionConMaqueta.Instance.ObtenerCambios(identificador);
            foreach (Pociones.TipoPociones efecto in efectos)
            {
                AplicarEfectosAutomaticos(efecto);
            }
        }
        
    }

    public void AplicarEfecto(Pociones.TipoPociones efectos)
    {
        if (!efectosPermitidos.Contains(efectos))
        {
            if (leTexto != null) leTexto.MostrarMensaje();
            Debug.Log("Este objeto no permite esa poción");
            return;
        }

        switch (efectos)
        {
            case Pociones.TipoPociones.Congelar:
                coll.isTrigger = false;
                break;

            case Pociones.TipoPociones.Crecer:
                if (escalaObjetivo == escalaMin)
                    escalaObjetivo = escalaInicio;   
                else
                    escalaObjetivo = escalaMax;
                StartCoroutine(ChangeScale(escalaObjetivo));
                break;

            case Pociones.TipoPociones.Menguar:
                if (escalaObjetivo == escalaMax)
                    escalaObjetivo = escalaInicio;
                else
                    escalaObjetivo = escalaMin;
                StartCoroutine(ChangeScale(escalaObjetivo));
                break;

            case Pociones.TipoPociones.Saltarin:
                esSaltarin = true;
                break;
        }

        if (esMaqueta && ConexionConMaqueta.Instance != null)
        {
            ConexionConMaqueta.Instance.GuardarCambio(identificador, efectos);
        }
    }

    public IEnumerator ChangeScale(Vector3 escala)
    {
        Vector3 escalaInicial = transform.localScale;
        float tiempo = 0f;
        escala.x = Mathf.Clamp(escala.x, escalaMin.x, escalaMax.x);
        escala.y = Mathf.Clamp(escala.y, escalaMin.y, escalaMax.y);
        escala.z = Mathf.Clamp(escala.z, escalaMin.z, escalaMax.z);
        while (tiempo < duracion)
        {
            tiempo += Time.deltaTime;
            float progreso = tiempo / duracion;
            transform.localScale = Vector3.Lerp(escalaInicial, escala, progreso);
            yield return null;
        }
        transform.localScale = escala;
    }
    public void AplicarEfectosAutomaticos(Pociones.TipoPociones efectos)
    {
        switch (efectos)
        {
            case Pociones.TipoPociones.Congelar:
                coll.isTrigger = false;
                break;

            case Pociones.TipoPociones.Crecer:
                escalaObjetivo = escalaMax;
                transform.localScale = escalaMax;
                break;

            case Pociones.TipoPociones.Menguar:
                escalaObjetivo = escalaMin;
                transform.localScale = escalaMin;
                break;

            case Pociones.TipoPociones.Saltarin:
                esSaltarin = true;
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (esSaltarin)
            {
                Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
                rb.AddForce(Vector3.up * 10f, ForceMode.Impulse);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pocion"))
        {
            PocionObjeto dato = other.GetComponent<PocionObjeto>();
            if (dato != null)
            {
                AplicarEfecto(dato.datosPocion.efectos);
                Destroy(other.gameObject);
            }
        }
    }
}