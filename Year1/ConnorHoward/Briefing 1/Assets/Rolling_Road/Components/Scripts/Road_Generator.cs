


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road_Generator : MonoBehaviour
{

    public GameObject[] Road; //Arrays of all the section prefabs you want to use in the generator

    public Camera Gamecamera; //main camera

    public static float roadGeneratorSpeed; // speed variable controlled in the SpeedAndDistance script of the RoadGenerator game object

	public static float roadGeneratorDistance; // distance variable controlled in the SpeedAndDistance script of the RoadGenerator game object

	public Transform checkingPoint; // your section prefabs will need a child gameobject that sits on the far end of the prefab that acts as a 
	//detection point for the camera for when it needs to instantiate a new section as the current is coming to an end, this is a reference to that object

	public Transform spawnPoint; // your section prefabs will also need a child gameobject that will need to be positioned beyond the gameobject so that the next section will
	//be instantiated with their centre point at the same position as this object, make sure only the z axis values are adjusted, this is a reference to that object

	int index; // the value that gets used as the element number to be instantiated 

	bool inView = false; // sets true when a new section needs to be instantiated

    bool hasSpawned = false;  // sets true when a new section has been instantiated

	private Rigidbody rb; //creates a reference to the rigidbody component



    // Start is called before the first frame update
    void Start()
    {
        Gamecamera = GameObject.FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
		// updates newly instantiated prefabs with a reference to the camera
		Gamecamera = GameObject.FindObjectOfType<Camera>(); 

		//gets the rigidbody component and moves it along the z axis at the speed set in the inspector of the "RoadGenerator" 
		rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, -roadGeneratorSpeed) * Time.deltaTime;

		//sets the value of index to be randomly generated between any of the elements of prefabs
        index = Random.Range(0, Road.Length);
		//constantly runs this method
        CameraDetection();

		//instantiates a new section on the spawnPoint gameobjects position if the bools have been set to true, then destroys the spawnpoint on that gameobject to stop multiple objects instantiating
        if (inView && hasSpawned)
        {
            hasSpawned = false;
            print("Ready to spawn new section");
            if (spawnPoint != null)
            {
                Instantiate(Road[index], spawnPoint.position, Quaternion.identity);
                Destroy(spawnPoint.gameObject);
                spawnPoint = null;
            }
        }
       
    }



    void CameraDetection()
    {
		// Uses the cameras view point to detect the checkingpoint's transform position
        Vector3 screenPoint = Gamecamera.WorldToViewportPoint(checkingPoint.position);

		//sets bools to true if the z axis is lower than the cameras furthest reach
        if (screenPoint.z <= roadGeneratorDistance)
        {
            inView = true;
            hasSpawned = true;
           
        }

		//destorys the prefabs that have gone past the cameras view point
		if (screenPoint.z <= -58)
		{
			Destroy(gameObject);
		}
      

    } 

}
