# Game Basic Information #

## Summary ##

    Due Tonight is an one-on-one fighting game based on two teams of professor and student. 
    Students from UC Davis are under great pressure, so they want to fight with professor 
    to get an extension for their homework. But professors should avoid that happens. Characters
    have different attack skills which may come from some personal characteristics in reality. 

## Gameplay explanation ##

**In this section, explain how the game should be played. Treat this as a manual within a game. It is encouraged to explain the button mappings and the most optimal gameplay strategy.**

* Core game mechanice: This game needs two players for each round. The basic action includes attacking, protecting, jumping.
* Goals: Players who choose student team need to defeat professor team to win an extension for homework. 
* Controls:

    Xbox Controller(recommend):
    
        Left Stick, Left bumper, Right bumper for movement.
        
        'A' for shield skills, 'Y' and 'B' for two attack skills.
        
        'X' for extra attack skills(only available to certain characters).
    
    Keyboard:
    
        Left Player:
        
            'W''A''S''D' for movement.
            
            Left Shift and Control for two attack skills.
            
            Option for shield skills.
            
            Space for extra attack skill.
            
        Right Player:
        
            '⬆️''⬇️''⬅️''➡️' for movement.
            
            'J' and 'K' for two attack skills.
            
            'L' for shield skills.
            
* User Experience: Players should follow the steps of menu. Choosing one character from each team, and then choose a background to start fighting. Each round has 100 seconds to fight. If one of them dies, this round will end immediately. Players can decide whether to play again or quit game.

# Main Roles #

* Animation and Visuals :     Ruike Qiu
* Game Logic :               Bingwei Wang
* User Interface :            Jinghan Zhang
* Input :                     Zheng Wang
* Movement/Physics :          Jason Zhou

Your goal is to relate the work of your role and sub-role in terms of the content of the course. Please look at the role sections below for specific instructions for each role.

Below is a template for you to highlight items of your work. These provide the evidence needed for your work to be evaluated. Try to have at least 4 such descriptions. They will be assessed on the quality of the underlying system and how they are linked to course content. 

*Short Description* - Long description of your work item that includes how it is relevant to topics discussed in class. [link to evidence in your repository](https://github.com/dr-jam/ECS189L/edit/project-description/ProjectDocumentTemplate.md)

Here is an example:  
*Procedural Terrain* - The background of the game consists of procedurally-generated terrain that is produced with Perlin noise. This terrain can be modified by the game at run-time via a call to its script methods. The intent is to allow the player to modify the terrain. This system is based on the component design pattern and the procedural content generation portions of the course. [The PCG terrain generation script](https://github.com/dr-jam/CameraControlExercise/blob/513b927e87fc686fe627bf7d4ff6ff841cf34e9f/Obscura/Assets/Scripts/TerrainGenerator.cs#L6).

You should replay any **bold text** with your relevant information. Liberally use the template when necessary and appropriate.

## User Interface

The user interface of Due Tonight is designded according to the basic game logic. The game is composed of six scenes that connected by scripts. 
 - Scene1: Main Menu: contains Start , Quit, Overcode, Controller & Keyboard four buttons.
 'Start' is the link to next game scene which allow players to choose two characters.
 'Controller & Keyboard' can link to the controller and keyboard guide scene.
 'Overcode' can link to team roles page.
 'Quit' is to quit game.
 Each button has different colors and effects.
 - Scene2: Choose two characters, and go to next scene.
 - Scene3: Choose background, and go to next scene. 
 - Scene4: Game, connected with Scene3. There is a timer and two healthbar for this scene. Healthbars and characters will appear according to players' choices. We used images to make the color of healthbar and it will change according to characters' health remain. After one round ends, this scene also can link to Scene2 for players to play again, or back to Scene1 Main Menu and quit the game. If one player is die before the timer stops, this round will end immediately with a big K.O image. And we also included a 'draw' image for different cases. 
 - Scene5: Team credit page, connected with Main Menu.
 - Scene6: 'Controller & Keyboard', connected with Main Menu.
 
 [UI script example](https://github.com/M2neko/ECS_189L_Final_Project/blob/5e299246b82745e5bb877facb62f7c7dab997bbf/Overcodeeeeeeee/Assets/Script/UI_Script/Game.cs#L1-L126)
 
 The free font we used for our game: [Noise Machine by Darrell Flood](https://www.fontspace.com/category/electric)
 
 [Contributer: Jinghan Zhang, Zheng Wang]
 
## Movement/Physics

**Describe the basics of movement and physics in your game. Is it the standard physics model? What did you change or modify? Did you make your movement scripts that do not use the physics system?**

 [Contributer: Jason Zhou, Bingwei Wang]
 
## Animation and Visuals

* We chose to use 2D pixel art for our game and it has a simple, retro type of feel for video game. The overall scene with graphic design elements is interact with players efficiently. According to narrative design, the story of this game is happened in the campus of UC Davis, so the two backgrounds are inspired by the buildings of campus, Memorial Union and the Shield's Library. The four characters are based on McCoy, Zee, Butner, and one normal student. All characters have different animation controllers in Unity due to large amount of actions and movements.
* The art of Due Tonight are designed and created by Jinghan Zhang.

**Describe how your work intersects with game feel, graphic design, and world-building.**

[Contributer: Ruike Qiu, Jason Zhou, Jinghan Zhang]

## Input

**Describe the default input configuration.**

**Add an entry for each platform or input style your project supports.**

 [Contributer: Zheng Wang, Bingwei Wang]
 
## Game Logic

 [Contributer: Bingwei Wang, Ruike Qiu]
**Document what game states and game data you managed and what design patterns you used to complete your task.**

# Sub-Roles

* Gameplay Testing :          Zheng Wang
* Press Kit and Trailer :     Bingwei Wang
* Audio :                     Jinghan Zhang
* Narrative Design :          Ruike Qiu
* Game Feel :                 Jason Zhou

## Audio

* The background music is a cyberpunk style clip. This clip contains strong rhythm and suitable for a fighting game atmosphere.
 (1) [ Amoebacrew - Cyberpunk https://youtu.be/Ju8z7Ecp1iY ]
* Special thanks to Professor McCoy and Zee for their contribution for recording audio. Those audios from McCoy and Zee are applied to opening animations and attack skills.
  Other audio sources for characters come from the website (2) [Free Sound Effects https://www.freesoundeffects.com]
* Implementation: Add audio listener to gameobjects and evoke specific audio clips when the game receive different inputs.
Save all the audio files in scripts as AudioSource, and the volume can be adjusted. The function from component can used to control the plat and stop of audio. If the audio will have a delay with the effect we need, we can make the audio play a little earlier to solve this problem. For the background music, because it will not stop unless players quit game, I used [DontDestroyOnLoad](https://github.com/M2neko/ECS_189L_Final_Project/blob/5e299246b82745e5bb877facb62f7c7dab997bbf/Overcodeeeeeeee/Assets/Script/UI_Script/BgMusic.cs#L30) to make the music keeps playing.

## Gameplay Testing

**Add a link to the full results of your gameplay tests.**

**Summarize the key findings from your gameplay tests.**

## Narrative Design

**Document how the narrative is present in the game via assets, gameplay systems, and gameplay.** 

## Press Kit and Trailer
* Press Kit materials:
* Link to trailer: [Due Tonight Trailer](https://www.youtube.com/watch?v=FFGYx54-IqI)
* Because Due Tonight is a fighting game, the trailer shows the fundamental gameplay scenes. And I also chose to include
unique attack skills in the trailer. I used screenrecording to record the battle and cutted those clips using Adobe Premiere.
The background music of the trailer is the same with the background music of our game, which I think is very appealing. Thanks for all the audio contributers for our game.

## Game Feel

**Document what you added to and how you tweaked your game to improve its game feel.**
