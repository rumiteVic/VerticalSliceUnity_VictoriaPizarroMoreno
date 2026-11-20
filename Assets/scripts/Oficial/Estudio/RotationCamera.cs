using UnityEngine;
using UnityEngine.InputSystem;
public class RotationCamera : MonoBehaviour
{

    public GameObject pivot;
    public Camera cam;
    private InputSystem_Actions input;

    Vector2 mos_pos;

    public float sensibility = 50f;
    float limitMax = 60f;
    float limitMin = -70f;
    float rotacionActual;

    public bool miraMaqueta;

    public GameObject where;
    public Vector3 positionMaqueta;
    float speed = 3.0f;

    float newLimitMax = 90f;
    float newLimitMin = -50f;

    //Creamos para usar el input system y cogemos de referencia la camara y su rotacion en x
    void Awake()
    {
        input = new InputSystem_Actions();
        input.Player.Enable();
        cam = Camera.main;
        rotacionActual = cam.transform.rotation.x;
        miraMaqueta = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Cogemos el valor de la posición del ratón
        mos_pos = Mouse.current.delta.ReadValue();

        //Rotamos al jugador entero para que rote sobre si mismo
        transform.RotateAround(pivot.transform.position, Vector3.up, mos_pos.x * sensibility);

        //Cogemos la rotación en eje x de la cámara y le restamos el mos_pos de mirar arriba y abajo para que mire hacia arriba si subimos el mos_pos arriba
        rotacionActual -= mos_pos.y * sensibility;


        if (!miraMaqueta)
        {
            cam.transform.position = Vector3.Lerp(transform.position, where.transform.position, speed);
            rotacionActual = Mathf.Clamp(rotacionActual, limitMin, limitMax);
            //Cambiamos la rotación local de la cámara con los quaternion
            cam.transform.localRotation = Quaternion.Euler(rotacionActual, 0, 0);
        }

        if (miraMaqueta)
        {
            cam.transform.position = Vector3.Lerp(transform.position, positionMaqueta, speed);
            rotacionActual = Mathf.Clamp(rotacionActual, newLimitMin, newLimitMax);
            //Cambiamos la rotación local de la cámara con los quaternion
            cam.transform.localRotation = Quaternion.Euler(rotacionActual, 0, 0);
        }
    }
}