using UnityEngine;

[CreateAssetMenu(fileName = "NuevoItem", menuName = "Item")]
public class ItemGeneral : ScriptableObject
{

    //Info objeto
    public string itemName;
    public string description;
    public Sprite icon;
    public GameObject prefab;
}
