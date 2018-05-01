using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCard : MonoBehaviour
{
    [SerializeField] private GameObject cardBack;
    [SerializeField] private ScreenController controller;

    private int _id;
    public int id
    {
        get { return _id; }
    }

    public void OnMouseDown()
    {
        if (cardBack.activeSelf && controller.canReveal)
        {
            cardBack.SetActive(false);
            controller.CardRevealed(this);
        }
    }

    public void SetCard( int ident, Sprite image)
    {
        _id = ident;
        GetComponent<SpriteRenderer>().sprite = image;
    }

    public void Unreveal()
    {
        cardBack.SetActive(true);
    }

    // Use this for initialization
    void Start ()
    {

		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
