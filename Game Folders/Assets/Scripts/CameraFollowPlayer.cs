using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    float FollowSpeed = 2f;
    private GameObject Frog;
    // Start is called before the first frame update
    void Start()
    {
        Frog = GameObject.Find("Frog");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 newPos = new Vector3(Frog.transform.position.x, Frog.transform.position.y,-10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed*Time.deltaTime);
        float rotate = Frog.GetComponent<Rigidbody2D>().rotation;
        if (rotate == 0)
        {
            rotate = 0;
        }
        else rotate *= -1;
        transform.rotation = new Quaternion(0,0,0,0);
    }
}
