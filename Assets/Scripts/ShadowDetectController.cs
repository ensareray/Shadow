using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowDetectController : MonoBehaviour
{
	[SerializeField] Transform target;
	[SerializeField] uint rayDistance;
	float fieldOfWiewAngle;
	
	void Start()
	{
		fieldOfWiewAngle = GetComponent<Light>().spotAngle;
	}

	//Oyuncu gölgede mi ışıkta mı onu anlamaya çalışıyoruz.
	//Şu anda direk gövdeye bağlı ama kafaya yönelmeli.	
    void Update()
    {
		Vector3 dir = target.position - transform.position;
		float angle = Vector3.Angle(dir, transform.forward);
		if(angle < fieldOfWiewAngle * 0.5f)
		{
			RaycastHit hit;
			if(Physics.Raycast(transform.position, dir, out hit, rayDistance ))
			{
				if(hit.transform.CompareTag("Player"))
				{
					//End Game - Player Dies
					Debug.DrawRay(transform.position, dir,Color.red);
				}
			}
		}
    }
}
