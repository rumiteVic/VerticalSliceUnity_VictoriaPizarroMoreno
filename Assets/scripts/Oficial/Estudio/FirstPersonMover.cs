using UnityEngine;

public class FirstPersonMover : MonoBehaviour
{
    private InputSystem_Actions input;
    public float speed = 3f;
    public Rigidbody rb;

    public LayerMask layerMask;
    public bool grounded = false;

    public Vector3 offset;
    public float radius;
    public float distance;

    Vector2 move;
    public Raycast cast;
    public RotationCamera rotCam;

    bool canF = false;
    bool isWatching = false;
    bool hasPocion = true;

    public PocionObjeto pocion;
    //Se dibujan 2 esferas, la segunda detectará si hay suelo o no
    private void OnDrawGizmos()
    {
        //Inicial
        Gizmos.DrawWireSphere(transform.position + offset, radius);

        //Final
        Gizmos.DrawWireSphere((transform.position + offset) + Vector3.down * distance, radius);
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
        input = new InputSystem_Actions();
        input.Player.Enable();
        rb = GetComponent<Rigidbody>();
        canF = false;
        isWatching = false;
        hasPocion = true;
    }


    void FixedUpdate()
    {
        //Miramos a que dirección va y la normalizamos ya que la velocidad es lo que hace que vaya más rápido
        Vector3 dirMov = (transform.forward * move.y + transform.right * move.x).normalized;

        //Creamos un raycast hit para mirar si la esfera detecta el suelo o algo en donde esta
        RaycastHit hit;
        if (Physics.SphereCast(transform.position + offset, radius, Vector3.down, out hit, distance))
        {
            //Si lo detecta es que tocamos suelo y dependiendo de la dirección que vayamos tendrá una velocidad multiplicada u otra
            grounded = true;
            rb.MovePosition(transform.position + dirMov * Time.fixedDeltaTime * speed);
        }//Si no toca el suelo no podrá sprintar y todas sus velocidades se reducirán a la mitad en todas direcciones y dirá que no está tocando el suelo
        else
        {
            grounded = false;
        }
    }
    // Update is called once per frame

    void Update()
    {
        // Entrar en la maqueta
        if (canF && !isWatching && input.Player.Interact.WasPressedThisFrame())
        {
            rotCam.miraMaqueta = true;
            isWatching = true;

            if (hasPocion)
            {
                cast.canRaycast = true;
            }
        }
        // Salir de la maqueta
        else if (isWatching && input.Player.Interact.WasPressedThisFrame())
        {
            rotCam.miraMaqueta = false;
            isWatching = false;

            cast.canRaycast = false;
        }

        // Movimiento del jugador
        if (!isWatching)
        {
            move = input.Player.Move.ReadValue<Vector2>();
        }
        else
        {
            move = Vector2.zero;
        }

        if (input.Player.Attack.WasPressedThisFrame() && hasPocion && isWatching)
        {
            if (cast.objetoDetectado && pocion != null)
            {
                Vector3 bolaPosition = new Vector3(cast.bola.transform.position.x, cast.bola.transform.position.y + 3f, cast.bola.transform.position.z);
                GameObject nuevaBola = Instantiate(pocion.datosPocion.prefab, bolaPosition, transform.rotation);
                pocion.QuitarUsos();

                if(pocion.usosRestantes <= 0)
                {
                    Destroy(pocion.gameObject);
                    pocion = null;
                    hasPocion = false;
                    cast.canRaycast = false;
                }
            }
        }
        if (input.Player.Next.WasPressedThisFrame())
        {
            hasPocion = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Maqueta"))
        {
            canF = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Maqueta"))
        {
            canF = false;
        }
    }
}
