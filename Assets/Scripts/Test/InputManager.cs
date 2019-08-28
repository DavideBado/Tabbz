using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public int WalkSpeed;
    public KeyCode LeftKey, RightKey, UpKey, DownKey;
    public bool OnTheRoad, OutsideTheDoor, InsideABuilding;
    public List<Camera> Cameras = new List<Camera>();
    private float OutsideSavedPosX;
    private void Update()
    {
        MoveOnTheRoad();
    }

    private void MoveOnTheRoad()
    {
        if (OnTheRoad) // Test temporaneo da sostituire con finitestatemachine
        {
            if (Input.GetKey(LeftKey) && !(Input.GetKey(RightKey) || Input.GetKey(UpKey) || Input.GetKey(DownKey)))
            {
                transform.Translate(Vector3.left * WalkSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(RightKey) && !(Input.GetKey(LeftKey) || Input.GetKey(UpKey) || Input.GetKey(DownKey)))
            {
                transform.Translate(Vector3.right * WalkSpeed * Time.deltaTime);
            }
            else if (Input.GetKeyDown(UpKey) && !(Input.GetKey(LeftKey) || Input.GetKey(RightKey) || Input.GetKey(DownKey)))
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, Vector3.forward, out hit, 5f))
                {
                    if (hit.transform.gameObject.tag == "Door" || hit.transform.gameObject.tag == "ToyMachine")
                    {
                        OnTheRoad = false;
                        Cameras[0].gameObject.SetActive(false);
                        Cameras[1].gameObject.SetActive(true);
                        OutsideTheDoor = true;
                    }
                }
            }
        }
        else if (OutsideTheDoor)
        {
            if (Input.GetKeyDown(DownKey) && !(Input.GetKey(LeftKey) || Input.GetKey(RightKey) || Input.GetKey(UpKey)))
            {
                OutsideTheDoor = false;
                Cameras[1].gameObject.SetActive(false);
                Cameras[0].gameObject.SetActive(true);
                OnTheRoad = true;
            }
            else if (Input.GetKeyDown(UpKey) && !(Input.GetKey(LeftKey) || Input.GetKey(RightKey) || Input.GetKey(DownKey)))
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, Vector3.forward, out hit, 5f))
                {
                    if (hit.transform.GetComponent<Door>() != null)
                    {
                        OutsideTheDoor = false;
                        OutsideSavedPosX = transform.position.x;
                        transform.position = new Vector3(hit.transform.GetComponent<Door>().InsidePosition.x, transform.position.y, hit.transform.GetComponent<Door>().InsidePosition.z);
                        InsideABuilding = true;
                    }
                }
            }
        }
        else if (InsideABuilding)
        {
            if (Input.GetKeyDown(DownKey) && !(Input.GetKey(LeftKey) || Input.GetKey(RightKey) || Input.GetKey(UpKey)))
            {
                InsideABuilding = false;
                transform.position = new Vector3(OutsideSavedPosX, transform.position.y, 1.5f);
                Cameras[1].gameObject.SetActive(false);
                Cameras[0].gameObject.SetActive(true);
                OnTheRoad = true;
            }            
        }
    }
}
