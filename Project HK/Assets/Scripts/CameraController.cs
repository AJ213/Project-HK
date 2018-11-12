using UnityEngine;

public class CameraController : MonoBehaviour
{
    public int currentPerspective;
    public Vector2[] perspectives = { new Vector2(-0.01f, 0), new Vector2(18, 10), new Vector2(18, 89.99f) };
    private float distanceFromPlayer;
    private float horizontalRotation;
    private Transform player;
    private float verticalRotation;
    private void ChangePerspective(int perspective)
    {
        currentPerspective = perspective;
        currentPerspective %= perspectives.Length;
        distanceFromPlayer = perspectives[currentPerspective].x;
        verticalRotation = perspectives[currentPerspective].y;
    }
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        ChangePerspective(currentPerspective);
    }
    private void Update()
    {
        ChangePerspective(currentPerspective);
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ChangePerspective(currentPerspective + 1);
        }
        horizontalRotation = player.eulerAngles.y;
        this.gameObject.transform.position = player.position;
        this.gameObject.transform.position += Mathf.Cos(Mathf.Deg2Rad * verticalRotation) * distanceFromPlayer * new Vector3(-Mathf.Cos(Mathf.Deg2Rad * horizontalRotation), 0, Mathf.Sin(Mathf.Deg2Rad * horizontalRotation));
        this.gameObject.transform.position += distanceFromPlayer * new Vector3(0, Mathf.Sin(Mathf.Deg2Rad * verticalRotation), 0);
        this.gameObject.transform.LookAt(player);
    }
}