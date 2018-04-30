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
        int iden = Random.Range(0, images.Length);
        originalCard.SetCard(iden, images[iden]);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
