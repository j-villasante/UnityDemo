using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {
    public Button leftButton;
    public Button middleButton;
    public Button rightButton;
    public Text text;
    public System.Random rnd;

    private Answer[] availableAnswers;
    private Button[] buttons;
    private int correctPosition;

	// Use this for initialization
	void Start () {
        rnd = new System.Random();
        buttons = new Button[3] { leftButton, middleButton, rightButton };

        availableAnswers = new Answer[5] {
            new Answer("cell", "cell"),
            new Answer("clip", "clip"),
            new Answer("paper", "paper"),
            new Answer("pen", "pen"),
            new Answer("speaker", "speaker")};

        this.Next();        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Next()
    {
        List<Answer> answers = getRandomUnreapeatedAnswers();
        for (int i  = 0; i < 3; i++)
        {
            buttons[i].image.sprite = Resources.Load<Sprite>(answers[i].image);
        }
        correctPosition = rnd.Next(3);
        text.text = answers[correctPosition].name;
    }

    private List<Answer> getRandomUnreapeatedAnswers ()
    {
        List<Answer> result = new List<Answer>();
        do
        {
            int r = rnd.Next(5);
            Answer answer = availableAnswers[r];
            if (!result.Contains(answer)) result.Add(answer);

        } while (result.Count < 3);
        return result;
    }

    public void OnLeftClick()
    {
        if (correctPosition == 0) this.Next();
    }

    public void OnMiddleClick()
    {
        if (correctPosition == 1) this.Next();
    }

    public void OnRightClick()
    {
        if (correctPosition == 2) this.Next();
    }

    private class Answer
    {
        public string image;
        public string name;

        public Answer(string image, string name)
        {
            this.image = image;
            this.name = name;
        }
    }
}
