using UnityEngine;

public class SampleComp : MonoBehaviour
{
    public Transform targetPoint;

    private void Update()
    {
        if (targetPoint != null)
        {
            var distance = Mathf.Sqrt(Mathf.Pow(targetPoint.position.x - this.transform.position.x, 2)
                + Mathf.Pow(targetPoint.position.y - this.transform.position.y, 2));
            var vectorDist = Vector3.Distance(targetPoint.position, this.transform.position);
            Debug.Log($"Distance {distance:F2}, Vector (vectorDist)");
        }
    }
}
