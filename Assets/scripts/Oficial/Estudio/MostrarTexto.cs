using UnityEngine;
using TMPro;
using System.Collections;
public class MostrarTexto : MonoBehaviour
{
    public TextMeshProUGUI texto;
    public float duration = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    public void MostrarMensaje()
    {
        StartCoroutine(MostrarElTexto());
    }

    public IEnumerator MostrarElTexto()
    {
        texto.gameObject.SetActive(true);
        yield return new WaitForSeconds(duration);
        texto.gameObject.SetActive(false);
    }
}
