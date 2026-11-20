using UnityEngine;

public class PocionObjeto : MonoBehaviour
{
    public Pociones datosPocion;
    public int usosRestantes;

    private void Start()
    {
        usosRestantes = datosPocion.usosTotales;
    }

    public void QuitarUsos()
    {
        usosRestantes--;
    }
}
