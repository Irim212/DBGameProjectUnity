using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour {

    public Transform[] background;
    private float[] parallaxScale;
    public float smoothing = 1f;

    private Transform cam;
    private Vector3 previousCam;

    void Awake()
    {
        cam = Camera.main.transform;
    }

    // Use this for initialization
    void Start () {
        previousCam = cam.position;
        parallaxScale = new float[background.Length];

        for (int i = 0; i<background.Length; i++)
        {
            parallaxScale[i] = background[i].position.z * -1;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
        for(int i = 0; i<background.Length; i++)
        {
            float parallax = (previousCam.x - cam.position.x) * parallaxScale[i];
            float backgroundTargedPosX = background[i].position.x + parallax;
            Vector3 backgroundTargetPos = new Vector3(backgroundTargedPosX, background[i].position.y, background[i].position.z);
            background[i].position = Vector3.Lerp(background[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }

        previousCam = cam.position;

    }
}
