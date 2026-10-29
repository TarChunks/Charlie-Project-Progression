Charlie Project Progression README\
Written by: Charlie Burnham\
\
Part 1:\
  The game I've created for this project is simple in nature. You play as a UFO and your goal is to gather the coins that spawn around you in a small area and avoid stars that fall from the sky and explode. The player wins upon collecting 10 coins and loses upon touching either the stars or the explosions they create. The play area is restricted to a small grassy area surrounded by cliff faces. This was done for practicalities sake as I figured a small area would be much easier to apply shading and lighting to singlehandedly over a (relatively) brief period of time. The game also features a blue star that spawns later in the game and chases the player and a powerup that gives the player a shield, allowing them to survive a star hit.\
\
<img width="1093" height="604" alt="Screenshot 2026-10-28 210334" src="https://github.com/user-attachments/assets/cda6092b-cc80-4f9b-9b9b-14178836b076" />\
An image of the final play area, note the player character in the centre of the screen.\
\
<img width="255" height="292" alt="Screenshot 2026-10-28 201307" src="https://github.com/user-attachments/assets/5856d464-8753-4588-9875-a7f312c0b5ed" />\
<img width="503" height="93" alt="Screenshot 2026-10-28 201322" src="https://github.com/user-attachments/assets/1cdcce3a-0898-48da-97cf-6c0eba377ea9" />\
These images depict the code for movement in the game. Pressing the WASD keys would affect the xforce and zforce values which were then added to the final force on a fixedupdate. Due to the game only having two axes of movement.\
\
<img width="476" height="358" alt="Screenshot 2026-10-28 202307" src="https://github.com/user-attachments/assets/2b6e1a73-ccd3-4658-a267-9feca336a973" />\
<img width="628" height="431" alt="Screenshot 2026-10-28 201821" src="https://github.com/user-attachments/assets/fd4fc2e7-e8c2-471a-9670-0f8b0969303e" />\
This is the code for spawning in the coins players collect. There are 4 possible spawn locations and for every coin spawned an unoccupied space is chosen for it (the number of coins on the field being capped at 4). The "ResetSpawn()" function serves to reset the coin spawns whenever the player picks up a coin from a spawn location so that it can be used again. Coins typically on 5 second intervals, however if there are no coins on the field (ie the coincount is equal to zero) a coin is immediately spawned to keep the player from waiting.\
\
<img width="619" height="451" alt="Screenshot 2026-10-28 202541" src="https://github.com/user-attachments/assets/ff74a1ef-e142-4e52-9b5b-7707bfc77e18" />\
The "StarSpawner" actual handles spawning 3 different things so I'll explain this one in two parts. The image above shows the timer for the Power up being randomised between 10 and 30 seconds. After that 3 different spawn timers are updated during the update function and then each object the spawner handles is checked to see if enough time has passed to spawn and for the power up and the blue "timer star", whether they've already spawned in or not as those both can spawn only once during gameplay.\
\
<img width="702" height="556" alt="Screenshot 2026-10-28 203100" src="https://github.com/user-attachments/assets/c602dc18-a2aa-4ee7-83b1-97340f39fe6e" />\
These are all just the functions for spawning the objects the spawner is in charge of. Nothing fancy here just some randomized x and z positions to decide spawn positions and some quaternions to handle the rotations of the spawned objects.\
\
<img width="1060" height="606" alt="Screenshot 2026-10-28 203417" src="https://github.com/user-attachments/assets/07fd9ad1-3b0f-47fa-8cad-f5ad1a245f5b" />\
This snippet of code handles the explosions of the stars. During the start function each star has it's only child object (it's explosion hitbox) set as what will be used for the explosion. After this a timer is used to determine how long the explosion should expand for and at what point it should despawn.\
\
<img width="967" height="439" alt="Screenshot 2026-10-28 203651" src="https://github.com/user-attachments/assets/eaac1036-60fd-4fa1-9225-23755bb6d753" />\
This code is what makes the coins rotate. When they spawn they find their position from the CoinSpawner code found on the CoinManager.\
\
<img width="1062" height="255" alt="Screenshot 2026-10-28 204100" src="https://github.com/user-attachments/assets/c7cfee1c-006a-4adb-af23-849e7641da03" />\
This code controls the movement of the timer start. On spawn it finds the player and then uses the players position to move towards them at a set speed.\
\
<img width="459" height="460" alt="Screenshot 2026-10-28 204350" src="https://github.com/user-attachments/assets/f641f211-a461-467a-a7cc-b8b13de64619" />\
This code in the PlayerMovement script controls dying, winning and how the shield works. Upon death and victory the timescale is set to zero and a coloured tint is activated. There is another timer in this script in the form of the invulnerability period you get after losing a shield, which makes sure the player won't get hit by the same explosion they just blocked on the next frame.\
\
<img width="429" height="558" alt="Screenshot 2026-10-28 204715" src="https://github.com/user-attachments/assets/1920a04d-d9db-4612-b0b1-246806a51e1d" />\
This is the collision code for everything in the game. Upon colliding with the trigger of an explosion of the collider of a star the player will die. Upon touching a shield power up, the player will gain a shield (assuming they don't already have one) and the power up will be destroyed. Coins are also destroyed on contact along with increasing the number of coins the player has allowing them to eventually win.\
\
Part 2:\
  The game has simple diffuse lighting in the form of the grass seen in the play area and around the cliffs. This is the only shader I chose to manually code rather than using Shadergraph. I vastly prefer Shadergraph as I find it more transparent and easier to understand what the individual building blocks of your shader does, but I figured it'd be for the best to demonstrate that I am capable of coding a shader if need be. Diffuse lighting with ambient lighting is also present for the cliff faces that border the play area and box the player in. Specular lighting also exists on the coins the player collects, which makes both logical and practical sense since it is best for the players objective to be shiny and eyecatching. Emissive lighting was also added for the stars that fall on the player for the same practical and logical reasons that coins were given the shiny lighting, the stars need to be eyecatching and stars glow so it only made sense. The UFO body of the player has Fresnel lighting on it giving it a light blue outline (the dome on the other hand is another use of emissive lighting).\
\
<img width="414" height="668" alt="Screenshot 2026-10-28 205854" src="https://github.com/user-attachments/assets/d911d1bd-79c3-44e6-a98c-6e04aaaff495" />\
The code for the diffuse lighting shader is shown above. Not much to see here considering it composes the most basic of lighting methods required for this project but even then the fact everything has to be manually typed out makes creating and bugfixing it a bit of a slog. This was coded around the time I was getting a bit sick of ShaderGraph and it did wonders for making me appreciate ShaderGraph's simplicity and readability.\
\
<img width="768" height="581" alt="Screenshot 2026-10-28 230744" src="https://github.com/user-attachments/assets/5df1dcb1-77bd-4954-956d-eab8e3810cf7" />\
ADDENDUM:\
Because I couldn't get the shader to function in my final build I had to replace it with a very basic shadergraph.\
\
<img width="1093" height="604" alt="Screenshot 2026-10-28 210334" src="https://github.com/user-attachments/assets/8d6aca41-c0d7-4ccf-b988-1895128d818a" />\
<img width="734" height="512" alt="Screenshot 2026-10-28 210258" src="https://github.com/user-attachments/assets/09e75ec1-90cf-4805-8d07-49e34ace9e69" />\
Images of the ambient diffuse lighting shader made in shadergraph alongside the brown cliffsides it was applied to.\
\
<img width="763" height="466" alt="Screenshot 2026-10-28 210539" src="https://github.com/user-attachments/assets/5c60748a-cf8e-4c16-a1db-ed4e5df34cc0" />\
<img width="490" height="434" alt="Screenshot 2026-10-28 210559" src="https://github.com/user-attachments/assets/cc1f3271-a7cd-46da-b3e1-e90a82130118" />\
This shows off the specular lighting shader and the coin model it is attached to. Fun fact, I chose to make the coin models spin in game because I thought it would make the specular lighting on them more noticeable from a distance.\
\
<img width="533" height="472" alt="Screenshot 2026-10-28 210902" src="https://github.com/user-attachments/assets/6a2f1317-851e-4234-a7dd-1ccd8b747e76" />\
<img width="566" height="523" alt="Screenshot 2026-10-28 210851" src="https://github.com/user-attachments/assets/3b7a399c-79e3-495b-a8ac-0f636e160f26" />\
<img width="678" height="416" alt="Screenshot 2026-10-28 210827" src="https://github.com/user-attachments/assets/71249c00-6c59-499c-8669-7ee5e5660aa2" />\
This is the emissive or "star" lighting I made for the stars. Simply put they needed to be bright and easy to notice so what better way is there to make them easy to see than making them bright and shining?\
\
<img width="587" height="512" alt="Screenshot 2026-10-28 211205" src="https://github.com/user-attachments/assets/07e90838-3543-4778-8d3a-37b83892b4c8" />\
<img width="715" height="488" alt="Screenshot 2026-10-28 211132" src="https://github.com/user-attachments/assets/289df6ac-3f05-4eea-b444-9d8f534de773" />\
The final lighting shader made for this project was the fresnel shader used on the outside rim of the UFO's body. Here's a close look at it so you can see it for yourself.\
\
<img width="576" height="642" alt="Screenshot 2026-10-28 212127" src="https://github.com/user-attachments/assets/031cfb9a-0451-4c39-b280-f3637927dbda" />\
<img width="270" height="247" alt="Screenshot 2026-10-28 212200" src="https://github.com/user-attachments/assets/fcf005d9-ae91-4f92-9c38-92b27b83613e" />\
This code shows how lighting can be toggled on and off using the number keys 1, 3, and 4.\
\
Part 3:\
  The game has one simple example of color grading, this is in the form of a contrast color adjustment to make he games colours pop a little more. I spent roughly 2 hours trying to get a LUT working in Unity but alas no matter what I did to the image Unity would always reject it.\
\
<img width="1090" height="597" alt="Screenshot 2026-10-28 211550" src="https://github.com/user-attachments/assets/849e4e96-201f-48c1-8b94-2fd6904e2a6c" />\
<img width="1092" height="604" alt="Screenshot 2026-10-28 211537" src="https://github.com/user-attachments/assets/1f3c50fd-f28a-4625-a401-160d9645cf81" />\
Two screenshots of the game with the contrast adjustment off (top) and on (bottom).\
<img width="512" height="32" alt="Big LUT" src="https://github.com/user-attachments/assets/f0a77d3e-ff59-427a-99a2-880867b345bd" />\
While it was never properly implemented I do have one of the LUT pngs I attempted to use for this project. Disappointing that I never got it working, I thought the colours I chose for it were quite nice.\
\
Part 4:\
Two different shaders were made for this game. The first of the two was a scrolling offset shader used on the games powerup to create a spinning animation along the horizontal axis. The second of these shaders was a transparent shader made for the shield that can surround the player so you are able to see them inside the shield.\
\
<img width="763" height="413" alt="Screenshot 2026-10-28 212823" src="https://github.com/user-attachments/assets/159ed82f-0bc3-4cf3-9db4-7ff6513a00c7" />\
<img width="1024" height="1024" alt="PowerUp Texture" src="https://github.com/user-attachments/assets/ed7a9f81-1769-4458-bd7f-fa7961b75bfe" />\
<img width="485" height="378" alt="Screenshot 2026-10-28 212847" src="https://github.com/user-attachments/assets/0319fdfa-38a2-4931-8107-c643241cf436" />\
Here is a screenshot of the Offset shader made in ShaderGraph alongside the texture used on the final power up. I also included a screenshot of the object with the shader applied so you can see it in motion...\
\
any second now...\
\
<img width="1075" height="444" alt="Screenshot 2026-10-28 213231" src="https://github.com/user-attachments/assets/ac5b45cb-d34d-4ee3-bf21-65144fec2dea" />\
<img width="285" height="290" alt="Screenshot 2026-10-28 213214" src="https://github.com/user-attachments/assets/cfd15a81-0e11-477c-b8ad-df4fd5c1bce9" />\
A screenshot of the transparent shader along with the shield it's applied to. As you can clearly see the shield is partially transparent and you can see the UFO inside of it.\
\
Project Proposal:\
\
	This game was conceived of as a method for filling out as many of the requirements of this project as possible. The game has a limited map size and scale which means it does not take as many resources or uniquely modeled objects to make it feel populated. The win condition of the game was created for entirely pragmatic reasons as coins could be given a lighting shader and would prove simple to code. The losing condition of stars falling on the player was in part inspired by Terraria where enemies can be instantly killed if fallen stars happen to land on top of them. All in all this project was entirely conceived of for utilitarian purposes.\
\
Reflection:\
\
	I was surprised at how many of the requirements I was able to complete for this assignment. I had assumed that with the short time period I had I was going to have to make major cuts on what  could be implemented but besides the LUT requirement I was able to get a majority of what was expected of the project. Another surprise to me is how much I ended up enjoying the creation of this game. Yes there were times where I was deeply frustrated (again, the LUT’s) but overall it felt quite enjoyable. A majority of my original vision for the game remained the same but a few things had to be dropped in the name of time. Besides the aforementioned LUT’s I had originally planned to implement a pause menu into the game where you could activate cheat codes that would have altered the games physics, spawn rates, etc, but it was ultimately cut for time (oh how naive I was 12 hours ago).\
\
Extension Reflection:\
\
	The reason no work was done before Tuesday of this week is because of a failure in communication both on myself and my team members along with a mismatch of personal expectations. I had gone into my group expecting that there would be some form of delegation of responsibilities so I spent much of my time asking the rest of the group for things to do (also in part because the project seemed to be over a year old and I figured that the rest of my team would know what to do best). The group on the other hand had an independent structure where team members were expected to choose what to work on on their own time. This discrepancy in expectations may have been solved had both parties not failed to communicate what they thought I was expected to do which led to extended periods where nothing was accomplished as I waited for instructions which would never arrive. This failure in communication also led to me being removed from the team without any previous notice or warning.\
\
Links:\
\
