//script choice of person

var LastPerson =15;  
var Persons : GameObject[];
var i : int;

function Start() {
i=0;
Get();
}


function OnGUI() {

        if(GUI.Button(new Rect(Screen.width/1.4f,Screen.height/2,35,35),">")){//как видишь, это обычный знак ">"
             
             var go = GameObject.FindWithTag("Player");
                 Destroy (go);
                         
                         i++;
                                         
                     Get();
                         
                         if (i == LastPerson)       //if number of person > max - return to the first person
                 i = -1;
             
        }



        if(GUI.Button(new Rect(Screen.width/3.8f,Screen.height/2,35,35),"<")){//как видишь, это обычный знак ">"

              var go2 = GameObject.FindWithTag("Player");
   
                 Destroy (go2);
             i--;
                         Get();
                         
                 if (i == -1)           //if number of person < 0 - return to the last person
                    i = LastPerson;

        }

}

function Get(){
	var inst : GameObject;
	var Person : GameObject = Persons[i];

	yield WaitForSeconds (0.2);
	 inst = Instantiate(Person, transform.position, transform.rotation) as GameObject;
	                                        inst.tag = "Player";
} 