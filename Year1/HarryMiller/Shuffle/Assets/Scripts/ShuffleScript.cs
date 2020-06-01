using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ShuffleScript : MonoBehaviour
{

    //PASS IN ALL OF THE THINGS TO BE SHUFFLED TO THIS
    public string[] tracklist;
    
    List<string> unshuffledTracks = new List<string>();
    List <string> shuffledTracks = new List<string>();
    int length = 0;
    bool shuffling = false;

    string previousLast = "";
    bool firstLoop = true;

    public List<string> Shuffle()
    {

        shuffledTracks.Clear();

        foreach(string t in tracklist)
        {
            //Add all the tracks to a list that can be modified
            unshuffledTracks.Add(t);
            length++;
        }

        shuffling = true;

        while(shuffling)
        {
            int index = Random.Range(0, length);

            //If the first item is the same as the previous shuffle's last item, redo the first item
            if(firstLoop)
            {
                while(unshuffledTracks[index].Equals(previousLast))
                {
                    print("redoing first");
                    index = Random.Range(0, length);
                }
                firstLoop = false;
            }

            shuffledTracks.Add(unshuffledTracks[index]);

            if(length == 1) previousLast = unshuffledTracks[index];
            unshuffledTracks.RemoveAt(index);

            length--;
            if(length <= 0) shuffling = false;
        }

        firstLoop = true;

        return(shuffledTracks);
    }

    // Start is called before the first frame update
    void Start()
    {
        //Shuffle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
