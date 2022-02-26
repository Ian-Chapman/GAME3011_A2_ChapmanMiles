using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  
    int numOfNotes;
    public List<string> noteList = new List<string>();
    public string[] easyNoteArray = { "D", "A", "B", "G" };
    public string[] mediumNoteArray = { "E", "E", "F", "G", "G", "F", "E", "D" };
    public string[] hardNoteArray = { "E", "D", "C", "D", "E", "E", "E", "D", "D", "D", "G", "G", "G" };

    private void Awake()
    {
        setDifficulty((int)Difficulty.MEDIUM);
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
                numOfNotes = easyNoteArray.Length;
                noteList.Capacity = numOfNotes;

                for (int i = 0; i < noteList.Capacity; i++)
                {
                    noteList.Add(easyNoteArray[i]);
                    Debug.Log(noteList[i]);
                }

                break;
            case (int)Difficulty.MEDIUM:
                numOfNotes = mediumNoteArray.Length;
                noteList.Capacity = numOfNotes;

                for (int i = 0; i < noteList.Capacity; i++)
                {
                    noteList.Add(mediumNoteArray[i]);
                    Debug.Log(noteList[i]);
                }

                break;
            case(int)Difficulty.HARD:
                numOfNotes = hardNoteArray.Length;
                noteList.Capacity = numOfNotes;

                for (int i = 0; i < noteList.Capacity; i++)
                {
                    noteList.Add(hardNoteArray[i]);
                    Debug.Log(noteList[i]);
                }

                break;
        }
    }

    void assignNotes()
    {

    }
    
}



public enum Difficulty
{
    EASY,
    MEDIUM,
    HARD
}
