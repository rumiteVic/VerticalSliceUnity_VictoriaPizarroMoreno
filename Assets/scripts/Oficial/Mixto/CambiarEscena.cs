using UnityEngine;
using UnityEngine.SceneManagement;
public class CambiarEscena : MonoBehaviour
{
    BoxCollider box;
    public bool isEstudio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        box = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (isEstudio)
            {
                SceneManager.LoadScene("Reino1");
            }
            else
            {
                SceneManager.LoadScene("Estudio");
            }
        }
    }
}
