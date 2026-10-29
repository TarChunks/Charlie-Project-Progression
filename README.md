Charlie Project Progression README\
Written by: Charlie Burnham\
\
Part 1:\
\
  The game I've created for this project is simple in nature. You play as a UFO and your goal is to gather the coins that spawn around you in a small area and avoid stars that fall from the sky and explode. The player wins upon collecting 10 coins and loses upon touching either the stars or the explosions they create. The play area is restricted to a small grassy area surrounded by cliff faces. This was done for practicalities sake as I figured a small area would be much easier to apply shading and lighting to singlehandedly over a (relatively) brief period of time. The game also features a blue star that spawns later in the game and chases the player and a powerup that gives the player a shield, allowing them to survive a star hit.\
\
<img width="1094" height="604" alt="Screenshot 2026-10-28 200941" src="https://github.com/user-attachments/assets/365ebb43-8dfc-47f4-a050-f828e9202dda" />\
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
  The game has simple diffuse lighting in the form of the grass seen in the play area and around the cliffs. This is the only shader I chose to manually code rather than using Shadergraph. I vastly prefer Shadergraph as I find it more transparent and easier to understand what the individual building blocks of your shader does, but I figured it'd be for the best to demonstrate that I am capable of coding a shader if need be. Diffuse lighting with ambient lighting is also present for the cliff faces that border the play area and box the player in. Specular lighting also exists on the coins the player collects, which makes both logical and practical sense since it is best for the players objective to be shiny and eyecatching. Emissive lighting was also added for the stars that fall on the player for the same practical and logical reasons that coins were given the shiny lighting, the stars need to be eyecatching and stars glow so it only made sense.\
\
Part 3:\
  The game has a
\
Links:
