using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamOrbit : MonoBehaviour
{
    public CinemachineOrbitalTransposer orbital;
    public float modifer;
    public float orbvalue;
    public bool isTurning;

    /*
    TODO://
    - add zoom function clamped between 4 and 8
    - add camera sees through walls
    */

    // Start is called before the first frame update
    void Awake()
    {
        var vCam = GetComponent<CinemachineVirtualCamera>();
        if(vCam != null){
            orbital = vCam.GetCinemachineComponent<CinemachineOrbitalTransposer>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        float orbitVal = Input.GetAxisRaw("CamOrb");
        orbvalue = orbital.m_XAxis.m_InputAxisValue;
        if(orbital != null){
            if(orbitVal != 0){
                isTurning = true;
                orbital.m_XAxis.m_InputAxisValue = orbitVal * modifer * Time.deltaTime;
            }else if(orbitVal == 0){
                    isTurning = false;
                    orbital.m_XAxis.m_InputAxisValue = 0;
            }
        }
    }
}
