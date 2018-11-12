using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public int currentPerspective;
    public Vector2[] perspectives = { new Vector2(-0.01f, 0), new Vector2(18, 10), new Vector2(18, 89.99f) };
    float distanceFromPlayer;
    float verticalRotation;
    float horizontalRotation;
    Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        ChangePerspective(currentPerspective);
    }

    private void ChangePerspective(int perspective)
    {
        currentPerspective = perspective;
        currentPerspective %= perspectives.Length;
        distanceFromPlayer = perspectives[currentPerspective].x;
        verticalRotation = perspectives[currentPerspective].y;
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


    /*
    public Transform target;
    private Vector3 offset;
    private Vector3 rotationOffset;

    Transform myTransform;

    private void Awake()
    {
        myTransform = this.GetComponent<Transform>();
        //myTransform = transform;
        offset = LevelHandler.cameraPositions[0];
        rotationOffset = LevelHandler.cameraRotations[0];
        myTransform.position = offset;
        myTransform.eulerAngles = rotationOffset;
    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown("h"))
        {
            LevelHandler.levelNum = 1;
        }
        //SetOffset();
        myTransform.position = offset;
        myTransform.eulerAngles = rotationOffset;
    }
    public void SetOffset()
    {
        offset = LevelHandler.cameraPositions[LevelHandler.levelNum];
        rotationOffset = LevelHandler.cameraRotations[LevelHandler.levelNum];
        //    offset = Vector3.Lerp(offset, (LevelHandler.cameraPositions[LevelHandler.levelNum] - LevelHandler.playerData[0]), 0.1f); new Vector3(0, 20, 0) - new Vector3(0, 0.8f, 0);
        //    rotationOffset = Vector3.Lerp(offset, (LevelHandler.cameraRotations[LevelHandler.levelNum] - LevelHandler.playerData[1]), 0.1f);
    }
    */


    //private void OnEnable()
    //{
    //    LevelHandler.OnLevelChange += SetOffset;
    //}

    //private void OnDisable()
    //{
    //    LevelHandler.OnLevelChange -= SetOffset;
    //}
    //float distanceDamp = 10f;
    //float rotationalDamp = 10f;
    /*
    private Vector3 velocity = Vector3.zero;
    private Vector3 acceleration = Vector3.zero;

    private void FixedUpdate()
    {
        
    }

    private void LateUpdate()
    {
        //transform.position += velocity * Time.deltaTime;
        //velocity += acceleration * Time.deltaTime;
        //StartCoroutine(Hesitate(2));


    }*/
    /*IEnumerator Hesitate(float wait)
    {
        yield return new WaitForSeconds(wait);
    //    velocity = player.GetComponent<Rigidbody>().velocity;
        
    //}*/

    ////public Transform target;

    //public float smoothSpeed = 5f;
    ////public Vector3 offset;
    //Vector3 velocity = Vector3.one;

    //void FixedUpdate()
    //{
    //    Vector3 desiredPosition = target.position + offset;
    //    Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
    //    transform.position = smoothedPosition;

    //    transform.LookAt(target);
    //}
}
