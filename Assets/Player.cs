using UnityEngine;
using System.Collections;

public class Player : Photon.MonoBehaviour {
    CharacterController controller;
	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (photonView.isMine)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            if (v != 0)
            {
                controller.Move(transform.forward * v * 5f * Time.deltaTime);
            }
            if (h != 0)
            {
                transform.Rotate(Vector3.up * h);
            }
            controller.Move(Physics.gravity * Time.deltaTime);
        }
	}

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        Vector3 pos = transform.position;
        Quaternion rot = transform.rotation;
        stream.Serialize(ref pos);
        stream.Serialize(ref rot);
        if (stream.isReading)
        {
            transform.position = pos;
            transform.rotation = rot;
        }
    }
}
