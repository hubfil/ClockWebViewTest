using UnityEngine;
using EasyButtons;

public class AutoCameraSize : MonoBehaviour
{
	private Camera mainCamera;

	void Start()
	{
		mainCamera = Camera.main;
		AdjustCameraSize();
	}
	[Button]
	void AdjustCameraSize()
	{
		MeshRenderer[] meshRenderers = FindObjectsOfType<MeshRenderer>();

		Bounds bounds = CalculateObjectBounds(meshRenderers);
		float objectSize = Mathf.Max(bounds.size.x, bounds.size.y, bounds.size.z);
		float padding = 2f; // optional padding around the objects

		float targetCameraSize = (objectSize / 2f) + padding;
		mainCamera.orthographicSize = targetCameraSize;
	}

	Bounds CalculateObjectBounds(MeshRenderer[] meshRenderers)
	{
		Bounds bounds = new Bounds();

		foreach (MeshRenderer renderer in meshRenderers)
		{
			if (bounds.size == Vector3.zero)
				bounds = renderer.bounds;
			else
				bounds.Encapsulate(renderer.bounds);
		}

		return bounds;
	}
}