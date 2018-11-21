using Engine;
using UnityEngine;
using Engine.Core.StaticData;

public class Albeoris : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
        StreamingAssets.LoadStaticData();

        Character[] characters = new Character[4];

	    for (int c = 0; c < 4; c++)
	    {
	        Item[] items = new Item[4];

	        for (int i = 0; i < 4; i++)
	        {
	            ItemStaticData data = StreamingAssets.Items.Find(Random.Range(1, StreamingAssets.Items.Count - 1));
	            items[i] = new Item(data);
	        }

	        Character character = new Character();
	        character.Items = items;
	        characters[c] = character;
	    }

	    Team team = new Team();
	    team.Characters = characters;
        
	    Game game = new Game();
	    game.Team = team;

	    CurrentGame.Initialize(game);

	    //CurrentGame.Team = new Team();

	    //ItemStaticData data = StreamingAssets.Items.Find(1);
	    //Item item = new Item(data);
	    //item.Start();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
