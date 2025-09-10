using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZoneDetectorLose : MonoBehaviour
{
    public GameObject noGo;
    public GameObject warnUI;
    [SerializeField] private float warnDist;
    [SerializeField] private float killDist;
    [SerializeField] private float shakeInt;
    private float playerDist;
    private Vector3 originalPos;

    private void Start()
    {
        originalPos = noGo.transform.position;
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
            //Debug.Log("You died! Restarting scene");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (playerDist <= warnDist)
        {
            //Debug.Log("Too close to no-go zone");
            warnUI.SetActive(true);
            Shake();
            noGo.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            warnUI.SetActive(false);
            noGo.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
    
    private void Shake()
    {
        float randomDistX = Random.Range(-1f, 1f) * shakeInt;
        float randomDistY = Random.Range(-1f, 1f) * shakeInt;

        noGo.transform.position = new Vector3(
            originalPos.x + randomDistX,
            originalPos.y + randomDistY
        );
    }

}
