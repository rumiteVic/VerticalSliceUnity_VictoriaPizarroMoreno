using UnityEngine;


[CreateAssetMenu(fileName = "NuevasPociones", menuName = "Alquimia")]
public class Pociones : ScriptableObject
{

    public string nombre;
    public GameObject prefab;
    public GameObject prefabBotella;


    public string description;

    public TipoPociones efectos;
    public int usosTotales;
    public enum TipoPociones
    {
        Congelar,
        Crecer,
        Menguar,
        Saltarin
    }   
}
