using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    public Vector3 movementVector;
    [SerializeField][Range(0,1)] float movementFactor;
    public float period = 2f;

    void Start()
    {
        int oscillationRange = Random.Range(0, 3);
        movementVector.y = oscillationRange;
        //parent control
        if (transform.parent != null)
            startingPosition = transform.localPosition;
        else
            startingPosition = transform.position;
    }

    void Update()
    {
        if (period < Mathf.Epsilon) return;
        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2;
        float rawSinValue = Mathf.Sin(cycles * tau);
        movementFactor = (rawSinValue + 1f) / 2f;
        Vector3 offset = movementVector * movementFactor;

        if (transform.parent != null)
            transform.localPosition = startingPosition + offset;
        else
            transform.position = startingPosition + offset;
    }
}
