using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public int WalkSpeed;
    public KeyCode LeftKey, RightKey, UpKey, DownKey, SubmitKey;
    public bool OnTheRoad, OutsideTheDoor, InsideABuilding;
    public bool InfrontOfTheGashaponMachine, InGashaponBoxView, InGashaponView;
    public List<Camera> Cameras = new List<Camera>();
    private float OutsideSavedPosX;
    public GameObject GashaponBox;
    public List<Material> GashaponBox_Materials = new List<Material>();
    public float GashaponRotationSpeed;
    private GameObject NewGashapon;
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
                    if (hit.transform.gameObject.tag == "Door")
                    {
                        OnTheRoad = false;
                        Cameras[0].gameObject.SetActive(false);
                        Cameras[1].gameObject.SetActive(true);
                        OutsideTheDoor = true;
                    }
                    else if(hit.transform.GetComponent<GashaponMachine>()!= null)
                    {

                        OnTheRoad = false;
                        Cameras[0].gameObject.SetActive(false);
                        Cameras[1].gameObject.SetActive(true);
                        InfrontOfTheGashaponMachine = true;
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
        else if (InfrontOfTheGashaponMachine)
        {
            if (Input.GetKeyDown(DownKey) && !(Input.GetKey(LeftKey) || Input.GetKey(RightKey) || Input.GetKey(UpKey)))
            {
                InfrontOfTheGashaponMachine = false;
                Cameras[0].gameObject.SetActive(true);
                Cameras[1].gameObject.SetActive(false);
                Cameras[2].gameObject.SetActive(false);
                OnTheRoad = true;
            }
            else if (Input.GetKeyDown(UpKey) && !(Input.GetKey(LeftKey) || Input.GetKey(RightKey) || Input.GetKey(DownKey)))
            {
                InfrontOfTheGashaponMachine = false;
                Cameras[0].gameObject.SetActive(false);
                Cameras[1].gameObject.SetActive(false);
                Cameras[2].gameObject.SetActive(true);
                GashaponBox.SetActive(true);
                GashaponBox.GetComponent<MeshRenderer>().enabled = true;
                GashaponBox.GetComponent<MeshRenderer>().material = GashaponBox_Materials[Random.Range(0, GashaponBox_Materials.Count)];
                InGashaponBoxView = true;
            }
        }
        else if (InGashaponBoxView)
        {            
            if (Input.GetKey(DownKey))
            {
                GashaponBox.transform.Rotate(Vector3.down * GashaponRotationSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(UpKey))
            {
                GashaponBox.transform.Rotate(Vector3.up * GashaponRotationSpeed * Time.deltaTime);
            }
            if (Input.GetKey(LeftKey))
            {
                GashaponBox.transform.Rotate(Vector3.left * GashaponRotationSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(RightKey))
            {
                GashaponBox.transform.Rotate(Vector3.right * GashaponRotationSpeed * Time.deltaTime);
            }
            if (Input.GetKeyDown(SubmitKey))
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, Vector3.forward, out hit, 5f))
                {
                    if (hit.transform.GetComponent<GashaponMachine>() != null)
                    {
                        InGashaponBoxView = false;
                        NewGashapon = GameObject.Instantiate(hit.transform.GetComponent<GashaponMachine>().BuyOne());
                        NewGashapon.transform.parent = GashaponBox.transform;
                        NewGashapon.transform.SetPositionAndRotation(GashaponBox.transform.position, Quaternion.identity);
                        GashaponBox.GetComponent<MeshRenderer>().enabled = false;
                        InGashaponView = true;
                    }
                }               
            }
        }
        else if (InGashaponView)
        {            
            if (Input.GetKey(DownKey))
            {
                GashaponBox.transform.Rotate(Vector3.down * GashaponRotationSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(UpKey))
            {
                GashaponBox.transform.Rotate(Vector3.up * GashaponRotationSpeed * Time.deltaTime);
            }
            if (Input.GetKey(LeftKey))
            {
                GashaponBox.transform.Rotate(Vector3.left * GashaponRotationSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(RightKey))
            {
                GashaponBox.transform.Rotate(Vector3.right * GashaponRotationSpeed * Time.deltaTime);
            }
            if (Input.GetKeyDown(SubmitKey))
            {
                Destroy(NewGashapon);
                InGashaponView = false;
                Cameras[0].gameObject.SetActive(false);
                Cameras[1].gameObject.SetActive(true);
                InfrontOfTheGashaponMachine = true;
            }
        }
    }
}