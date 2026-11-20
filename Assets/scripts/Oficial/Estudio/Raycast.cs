using UnityEngine;

public class Raycast : MonoBehaviour
{
    Vector3 origin;
    public float distanciaMax = 10f;
    public bool canRaycast;
    public GameObject bola;
    public LayerMask layer;
    public GameObject objetoDetectado = null;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canRaycast = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canRaycast)
        {
            bola.SetActive(true);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, distanciaMax, layer))
            {
                objetoDetectado = hit.collider.gameObject;
                bola.transform.position = hit.point;
            }
            else
            {
                objetoDetectado = null;
            }
        }
        else
        {
            bola.SetActive(false);
        }
        
    }
}
