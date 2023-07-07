
using UnityEngine;

public class LockFrameRate : MonoBehaviour
{
	public int targetFrameRate = 30;
    // Start is called before the first frame update
    void Start()
    {
	    // Limit the framerate to 60
	    Application.targetFrameRate = targetFrameRate;

    }


}
