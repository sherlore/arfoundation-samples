using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTranslate : MonoBehaviour
{
	public float speed;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
    }
}
