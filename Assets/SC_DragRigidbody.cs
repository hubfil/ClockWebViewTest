using UnityEngine;
using System.Collections;

public class SC_DragRigidbody : MonoBehaviour
{
	public AlarmManagerTest ClockAnimator;
	
	public float forceAmount = 500;

	Rigidbody selectedRigidbody;
	Camera targetCamera;
	Vector3 originalScreenTargetPosition;
	Vector3 originalRigidbodyPos;
	float selectionDistance;

	// Start is called before the first frame update
	void Start()
	{
		targetCamera = GetComponent<Camera>();
	}

	void Update()
	{
		if (!targetCamera)
			return;

		if (Input.GetMouseButtonDown(0))
		{
			StopCoroutine(WaitForSecondsCoroutine());
			//Check if we are hovering over Rigidbody, if so, select it
			selectedRigidbody = GetRigidbodyFromMouseClick();
			if (selectedRigidbody != null)
				ClockAnimator.isGoing = false;
		}
		
		if (Input.GetMouseButtonUp(0) && selectedRigidbody)
		{
			selectedRigidbody = null;
			StartCoroutine(WaitForSecondsCoroutine());
			//Release selected Rigidbody if there any

		}
	}
	


    private IEnumerator WaitForSecondsCoroutine()
    {
	    yield return new WaitForSeconds(0.5f);
	    ClockAnimator.isGoing = true;
    }

	void FixedUpdate()
	{
		if (selectedRigidbody)
		{
			Vector3 mousePositionOffset = targetCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, selectionDistance)) - originalScreenTargetPosition;
			selectedRigidbody.velocity = (originalRigidbodyPos + mousePositionOffset - selectedRigidbody.transform.position) * forceAmount * Time.deltaTime;
		}
	}

	Rigidbody GetRigidbodyFromMouseClick()
	{
		RaycastHit hitInfo = new RaycastHit();
		Ray ray = targetCamera.ScreenPointToRay(Input.mousePosition);
		bool hit = Physics.Raycast(ray, out hitInfo);
		if (hit)
		{
			if (hitInfo.collider.gameObject.GetComponent<Rigidbody>())
			{
				selectionDistance = Vector3.Distance(ray.origin, hitInfo.point);
				originalScreenTargetPosition = targetCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, selectionDistance));
				originalRigidbodyPos = hitInfo.collider.transform.position;
				return hitInfo.collider.gameObject.GetComponent<Rigidbody>();
			}
		}

		return null;
	}
}
