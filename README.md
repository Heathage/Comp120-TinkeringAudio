# Comp120-TinkeringAudio
https://github.com/GamesDevDave/Comp120-TinkeringAudio
## Contract #1 - Sound Effect Generation (Diegetic Audio)
Author - [James Heath](https://github.com/Heathage)

### Brief Expectations
1. Create a tool which will generate sound effects.
      - Consisting of sequences of tone as well as sample manipulations.
2. The sound effects should clearly define player actions, such as;
      - Picking up an item
      - Attacking
      - Walking over traps
      - As well as other player actions found in games.
3. Tone variations are expected by method of procedual generation.

### How to use:-
When you open the unity project you may find that the correct scene has not been loaded. Please open the Audio scene and then play the scene. You will need to use headphones. WASD for movement. 

### Done
1. Created a playable area for a user to explore the different sound effects.
2. Tones now player dependant on the player actions.
      - A tone, with a random frequency between two values, will play when a player picks up a pink cube. (Signifying picking up that item)
      - A tone will play when a player picks up a red cube. (Signifying the player walking into a trap)
      - A tone, with a random frequency between two values, will play when the "Obstacle Cubes" hit the ground. (Signifying the trap closing on the player)
      - A tone will play when the player picks up the gold cube. (Signifying the player winning)

## Contract #4 - User Interface Audio (Non-Diegetic Audio)
Author - [David Brown](https://github.com/GamesDevDave)
### Requirements of the brief:-
1. Create sounds to be used on a user interface.
      - This includes sounds such as button clicks, hovering over buttons etc.
2. The sounds must be generated by code.
      - Repurpose the algorithms used in the presentations.
3. Make the sounds configurable by designers.
4. Tones and Samples should be modified in a systematic way in order to indicate success or failure.
### How to use:-
In order to use the program, clone the repository from Github. After this, simply navigate to Project 4 within the file structure and open it as a Unity Project. Navigate to the "Scenes" folder within the Project Hierarchy and open the "StartMenu" scene. Press Play and everything should work as intended. Frequency, Duration, Sample Rate and Volume are all editable. If the UI on the tone generation page does not fit then please change the resolution of the Game Mode view to 1920 x 1080.
### Licensing information:-
For this piece of work we have opted to use the MIT license. Due to the nature of this project, MIT is appropriate as this software will likely never be commercialised therefore there is no need to keep source code locked away and unamendable. Similarly, having the code open to modification allows for easier improvement of the code. Within the MIT license it states that you can "copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the software". Allowing anyone to have this ability means that it is more likely that the program will improve as more people are likely to work on it thus more ideas will be generated. 
