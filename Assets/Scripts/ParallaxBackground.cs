using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour {
    private GameObject cam;
    [SerializeField] private float parallaxEffect;
    private float xPosition;

    void Start() {
        cam = GameObject.Find("Main Camera");
        xPosition = transform.position.x;
    }

    // Update is called once per frame
    void Update() {
        float distanceToMove = cam.transform.position.x * parallaxEffect;
        transform.position = new Vector3(xPosition + distanceToMove, transform.position.y);

    }
}


// To make endles background
/*
    float length = GetComponent<SpriteRenderer>().bounds.size.x;

        float distanceMoved = cam.transform.position.x * (1 - parallaxEffect);
        float distanceToMove = cam.transform.position.x * parallaxEffect;

        
        if(distanceMoved > xPosition + length) {
            xPosition = xPosition + length;
        } else if (distanceMoved < xPosition - length) {
            xPosition = xPosition - length;
        }
    }

*/
