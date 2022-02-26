using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  
    int numOfNotes;
    public List<string> noteList = new List<string>();
    public string[] noteArray = { "D", "A", "B", "G", "D", "A", "B", "G" };

    private void Awake()
    {
        setDifficulty((int)Difficulty.EASY);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setDifficulty(int difficultyNum)
    {
        switch (difficultyNum)
        {
            case (int)Difficulty.EASY:
                numOfNotes = 4;
                noteList.Capacity = numOfNotes;
                assignNotes();

                break;
            case (int)Difficulty.MEDIUM:
                numOfNotes = 6;
                noteList.Capacity = numOfNotes;
                assignNotes();

                break;
            case(int)Difficulty.HARD:
                numOfNotes = 8;
                noteList.Capacity = numOfNotes;
                assignNotes();

                break;
        }
    }

    void assignNotes()
    {
        for (int i = 0; i < noteList.Capacity; i++)
        {
            noteList.Add(noteArray[i]);
            Debug.Log(noteList[i]);
        }
    }
    
}



public enum Difficulty
{
    EASY,
    MEDIUM,
    HARD
}
