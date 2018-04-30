using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : MonoBehaviour
{
    [SerializeField] private MemoryCard originalCard;
    [SerializeField] private Sprite[] images;
	// Use this for initialization
	void Start ()
    {
        int id = Random.Range(0, images.Length);
        originalCard.SetCard(id, images[id]);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
