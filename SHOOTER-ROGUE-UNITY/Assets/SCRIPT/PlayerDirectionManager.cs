using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirectionManager : MonoBehaviour
{
    PlayerInputReader inputReader;
    PlayerForceReceiver forceReceiver;

    public bool normalDir, rightDir, upDir, leftDir;
    public Vector3 autoDir;
    // Start is called before the first frame update
    void Start()
    {
        inputReader = GetComponent<PlayerInputReader>();
        forceReceiver = GetComponent<PlayerForceReceiver>();
        normalDir = true;
    }

    // Update is called once per frame
    void Update()
    {


        if (normalDir)
        {
            inputReader.dir = new Vector3(inputReader.dirX, 0, 0);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (rightDir)
        {

            inputReader.dir = new Vector3(0, inputReader.dirX, 0);
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }


        if (upDir)
        {

            inputReader.dir = new Vector3(inputReader.dirX, 0, 0);
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }




        if (leftDir)
        {

            inputReader.dir = new Vector3(0, -inputReader.dirX, 0);
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }
    }
}
