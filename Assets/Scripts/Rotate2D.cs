using UnityEngine;

public class Rotate2D : MonoBehaviour {
    public Vector3 rotateAmount;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(-rotateAmount * Time.deltaTime);
    }
}
