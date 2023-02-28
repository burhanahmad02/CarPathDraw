using UnityEngine;

public class GUIVehicleSelector : MonoBehaviour
{
	public GameObject policeCar;
	public GameObject redCar;
	public GameObject grayCar;
	private GameObject currentCar;
		
	private void Start()
	{
		redCar.GetComponent<AudioSource>().enabled = false;
		grayCar.GetComponent<AudioSource>().enabled = false;
		redCar.GetComponent<VehicleSimpleControl>().enabled = false;
		grayCar.GetComponent<VehicleSimpleControl>().enabled = false;
		currentCar = policeCar;
		GetComponent<CameraControl>().target = currentCar.transform;
	}
	
	private void OnGUI()
	{
		if (GUI.Button(new Rect(10f, 10f, 100f, 50f), "Police Car"))
		{
			redCar.GetComponent<AudioSource>().enabled = false;
			grayCar.GetComponent<AudioSource>().enabled = false;
			policeCar.GetComponent<AudioSource>().enabled = true;
			redCar.GetComponent<VehicleSimpleControl>().enabled = false;
			grayCar.GetComponent<VehicleSimpleControl>().enabled = false;
			policeCar.GetComponent<VehicleSimpleControl>().enabled = true;
			currentCar = policeCar;
			GetComponent<CameraControl>().target = currentCar.transform;
		}
		if (GUI.Button(new Rect(10f, 110f, 100f, 50f), "Red Car"))
		{
			redCar.GetComponent<AudioSource>().enabled = true;
			grayCar.GetComponent<AudioSource>().enabled = false;
			policeCar.GetComponent<AudioSource>().enabled = false;
			redCar.GetComponent<VehicleSimpleControl>().enabled = true;
			grayCar.GetComponent<VehicleSimpleControl>().enabled = false;
			policeCar.GetComponent<VehicleSimpleControl>().enabled = false;
			currentCar = redCar;
			GetComponent<CameraControl>().target = currentCar.transform;
		}
		if (!GUI.Button(new Rect(10f, 220f, 100f, 50f), "Gray Car"))
			return;
			redCar.GetComponent<AudioSource>().enabled = false;
			grayCar.GetComponent<AudioSource>().enabled = true;
			policeCar.GetComponent<AudioSource>().enabled = false;
			redCar.GetComponent<VehicleSimpleControl>().enabled = false;
			grayCar.GetComponent<VehicleSimpleControl>().enabled = true;
			policeCar.GetComponent<VehicleSimpleControl>().enabled = false;
			currentCar = grayCar;
			GetComponent<CameraControl>().target = currentCar.transform;
	}
}
