using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZoneDetectorLose : MonoBehaviour
{
    public GameObject noGo;
    [SerializeField] private float warnDist;
    [SerializeField] private float killDist;
    private float playerDist;
    private float ogPosx, ogPosy;

    private void Start()
    {
        ogPosx = noGo.transform.position.x;
        ogPosy = noGo.transform.position.y;
    }

    private void Update()
    {
        if (noGo != null)
        {
            playerDist = Mathf.Sqrt(Mathf.Pow(noGo.transform.position.x - this.transform.position.x, 2)
                + Mathf.Pow(noGo.transform.position.y - this.transform.position.y, 2));
            var vectorDist = Vector3.Distance(noGo.transform.position, this.transform.position);
            //Debug.Log($"Distance {playerDist:F2}, Vector (vectorDist)");
        }

        // Losing Function
        if (playerDist <= killDist)
        {
            Debug.Log("You died! Restarting scene");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (playerDist <= warnDist)
        {
            Debug.Log("Too close to no-go zone");
            noGo.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            noGo.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }


}
