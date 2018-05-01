﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : MonoBehaviour
{
    [SerializeField] private MemoryCard originalCard;
    [SerializeField] private Sprite[] images;

    private MemoryCard _firstrevealed;
    private MemoryCard _secondrevealed;

    public bool canReveal
    {
        get { return _secondrevealed == null; }
    }

    public const int gridrows = 2;
    public const int gridCols = 4;
    public const float offsetX = 2.0f;
    public const float offsetY = 2.5f;

    private int _score = 0;

	// Use this for initialization

        public void CardRevealed(MemoryCard card)
    {
        if(_firstrevealed == null)
        {
            _firstrevealed = card;
        }
        else
        {
            _secondrevealed = card;
            StartCoroutine(CheckMatch());
            Debug.Log("Match: " + (_firstrevealed.id == _secondrevealed.id));
        }
    }
	void Start ()
    {
        Vector3 startPos = originalCard.transform.position;

        int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3 };
        numbers = ShuffleArray(numbers);

        for(int i =0; i<gridCols; i++)
        {
            for (int j=0; j<gridrows; j++)
            {
                MemoryCard card;
                if (i == 0 && j == 0)
                {
                    card = originalCard;
                }
                else
                {
                    card = Instantiate(originalCard) as MemoryCard;
                }

                int index = j * gridCols + i;
                int iden = numbers[index];
                card.SetCard(iden, images[iden]);

                float posX = (offsetX * i) + startPos.x;
                float posY = -(offsetY * j) + startPos.y;
                card.transform.position = new Vector3(posX, posY, startPos.z);
            }
        }

	}

    private int[] ShuffleArray(int[] numbers)
    {
        int[] newArray = numbers.Clone() as int[];
        for( int i=0; i<newArray.Length; i++)
        {
            int tmp = newArray[i];
            int r = Random.Range(i, newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = tmp;
        }
        return newArray;
    }

    private IEnumerator CheckMatch()
    {
        if (_firstrevealed.id == _secondrevealed.id)
        {
            _score++;
            Debug.Log("Score: " + _score);
        }
        else
        {
            yield return new WaitForSeconds(2.0f);
            _firstrevealed.Unreveal();
            _secondrevealed.Unreveal();
        }

        _firstrevealed = null;
        _secondrevealed = null;

    }
	
	// Update is called once per frame
	void Update ()
    {
	}
}
