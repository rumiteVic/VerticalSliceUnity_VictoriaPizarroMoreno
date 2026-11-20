using UnityEngine;
using System.Collections.Generic;
public class ConexionConMaqueta : MonoBehaviour
{

    public static ConexionConMaqueta Instance;
    public Dictionary<string, List<Pociones.TipoPociones>> cambios = new Dictionary<string, List<Pociones.TipoPociones>>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public void GuardarCambio(string identificador, Pociones.TipoPociones efecto)
    {
        if (!cambios.ContainsKey(identificador))
        {
            cambios[identificador] = new List<Pociones.TipoPociones>();
        }

        List<Pociones.TipoPociones> lista = cambios[identificador];

        switch (efecto)
        {
            case Pociones.TipoPociones.Crecer:
                if (lista.Contains(Pociones.TipoPociones.Menguar))
                {
                    lista.Remove(Pociones.TipoPociones.Menguar);
                }
                else
                {
                    lista.Add(Pociones.TipoPociones.Crecer);
                }
                break;

            case Pociones.TipoPociones.Menguar:
                if (lista.Contains(Pociones.TipoPociones.Crecer))
                {
                    lista.Remove(Pociones.TipoPociones.Crecer);
                }  
                else
                {
                    lista.Add(Pociones.TipoPociones.Menguar);
                }  
                break;

            default:
                if (!lista.Contains(efecto))
                    lista.Add(efecto);
                break;
        }
    }
    public List<Pociones.TipoPociones> ObtenerCambios(string identificador)
    {
        if (cambios.ContainsKey(identificador))
        {
            return new List<Pociones.TipoPociones>(cambios[identificador]);
        }

        return new List<Pociones.TipoPociones>();
    }
}