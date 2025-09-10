using UnityEngine;
using TMPro;

public class ZoneDetectorWin : MonoBehaviour
{
    public GameObject finishZone;
    public GameObject[] winUI;
    [SerializeField] private float winDist;
    private float playerDist;

    private void Update()
    {

        if (finishZone != null)
        {
            playerDist = Mathf.Sqrt(Mathf.Pow(finishZone.transform.position.x - this.transform.position.x, 2)
                + Mathf.Pow(finishZone.transform.position.y - this.transform.position.y, 2));
            var vectorDist = Vector3.Distance(finishZone.transform.position, this.transform.position);
            //Debug.Log($"Distance {playerDist:F2}, Vector (vectorDist)");
        }

        // Winning Function
        if (playerDist <= winDist)
        {
            //Debug.Log("You freaking win");
            foreach (GameObject text in winUI)
            {
                text.SetActive(true);
            }
        }
    }

}
