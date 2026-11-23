using UnityEngine;

public class RotaMaquetas : MonoBehaviour
{
    public float speedRotation = 3f;
    float anguloY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anguloY = transform.rotation.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        anguloY += Time.deltaTime * speedRotation;
        transform.rotation = Quaternion.Euler(0, anguloY, 0);
    }
}
