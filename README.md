# ECS_189L_Final_Project

This is the final project for Team **OverCode**.

# Main Role
* Animation and Visuals :     Ruike Qiu
* Game Logic :               Bingwei Wang
* User Interface :            Jinghan Zhang
* Input :                     Zheng Wang
* Movement/Physics :          Jason Zhou

# Sub-Role
* Gameplay Testing :          Zheng Wang
* Press Kit and Trailer :     Bingwei Wang
* Audio :                     Jinghan Zhang
* Narrative Design :          Ruike Qiu
* Game Feel :                 Jason Zhou

# Game Basic Information #

## Summary ##

    Due Tonight is an one-on-one fighting game based on two teams of professor and student. 
    Students need to fight with professor to get an extension for their homework, and 
    professors should avoid that happens. Characters have different attack skills which 
    may come from some personal characteristics in reality. 

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
            
* User Experience: Players should follow the steps of menu. Choosing one character from each team, and then choose a background to start fighting. Each round has 100 seconds to fight. If one of them dies, this round will end immediately. Players can decide whether play again or quit game.

# Main Roles #

Your goal is to relate the work of your role and sub-role in terms of the content of the course. Please look at the role sections below for specific instructions for each role.

Below is a template for you to highlight items of your work. These provide the evidence needed for your work to be evaluated. Try to have at least 4 such descriptions. They will be assessed on the quality of the underlying system and how they are linked to course content. 

*Short Description* - Long description of your work item that includes how it is relevant to topics discussed in class. [link to evidence in your repository](https://github.com/dr-jam/ECS189L/edit/project-description/ProjectDocumentTemplate.md)

Here is an example:  
*Procedural Terrain* - The background of the game consists of procedurally-generated terrain that is produced with Perlin noise. This terrain can be modified by the game at run-time via a call to its script methods. The intent is to allow the player to modify the terrain. This system is based on the component design pattern and the procedural content generation portions of the course. [The PCG terrain generation script](https://github.com/dr-jam/CameraControlExercise/blob/513b927e87fc686fe627bf7d4ff6ff841cf34e9f/Obscura/Assets/Scripts/TerrainGenerator.cs#L6).

You should replay any **bold text** with your relevant information. Liberally use the template when necessary and appropriate.

## User Interface

**Describe your user interface and how it relates to gameplay. This can be done via the template.**
* The user interface of Due Tonight is designded according to the basic game logic. The game is composed of six scenes that connected by scripts. Players need to choose their characters and background before the battle starts. The combat mode contains a timer and two healthbar of characters. After players make their choice, the healthbar will appear accordingly. 

## Movement/Physics

**Describe the basics of movement and physics in your game. Is it the standard physics model? What did you change or modify? Did you make your movement scripts that do not use the physics system?**

## Animation and Visuals

* The art of Due Tonight are designed and created by Jinghan Zhang.
* The overall visual feel of the game in 2D pixel style. The story of the game is happened in the campus of UC Davis, so the two backgrounds are inspired by the building of campus, the Memorial Union and the Shield's Library. And the four characters are based on McCoy, Zee, Butner, and one normal student. 

**Describe how your work intersects with game feel, graphic design, and world-building. Include your visual style guide if one exists.**

## Input

**Describe the default input configuration.**

**Add an entry for each platform or input style your project supports.**

## Game Logic

**Document what game states and game data you managed and what design patterns you used to complete your task.**

# Sub-Roles

## Audio

* The background music is a cyberpunk style clip. This clip contains strong rhythm and suitable for a fighting game atmosphere.
 (1) [ Amoebacrew - Cyberpunk https://youtu.be/Ju8z7Ecp1iY ]
* Special thanks to Professor McCoy and Zee for their contribution for recording audio. Those audios from McCoy and Zee are applied to opening animations and attack skills.
  Other audio sources for characters come from the website (2) [Free Sound Effects https://www.freesoundeffects.com]
* Implementation: Add audio listener to gameobjects and evoke specific audio clips when the game receive different inputs.
Save all the audio files in scripts as AudioSource, and the volume can be adjusted. The function from component can used to control the plat and stop of audio. If the audio will have a delay with the effect we need, we can make the audio play a little earlier to solve this problem. 

## Gameplay Testing

**Add a link to the full results of your gameplay tests.**

**Summarize the key findings from your gameplay tests.**

## Narrative Design

**Document how the narrative is present in the game via assets, gameplay systems, and gameplay.** 

## Press Kit and Trailer

**Include links to your presskit materials and trailer.**

**Describe how you showcased your work. How did you choose what to show in the trailer? Why did you choose your screenshots?**

## Game Feel

**Document what you added to and how you tweaked your game to improve its game feel.**
