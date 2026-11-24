using UnityEngine;

public class DarPocion : MonoBehaviour
{

    public Pociones pocionDelCubo;

    public void OnTriggerEnter(Collider other)
    {
        FirstPersonMover player = other.GetComponent<FirstPersonMover>();
        if (player != null)
        {
            player.CanCogerPocionYObtenerPocion(pocionDelCubo);

        }
    }
}
