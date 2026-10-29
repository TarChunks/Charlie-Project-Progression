Charlie Project Progression README\
Written by: Charlie Burnham\
\
Part 1:\
\
  The game I've created for this project is simple in nature. You play as a UFO and your goal is to gather the coins that spawn around you in a small area and avoid stars that fall from the sky and explode. The player wins upon collecting 10 coins and loses upon touching either the stars or the explosions they create. The play area is restricted to a small grassy area surrounded by cliff faces. This was done for practicalities sake as I figured a small area would be much easier to apply shading and lighting to singlehandedly over a (relatively) brief period of time.\
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
\
This is the code for spawning in the coins players collect. There are 4 possible spawn locations and for every coin spawned an unoccupied space is chosen for it (the number of coins on the field being capped at 4). The "ResetSpawn()" function serves to reset the coin spawns whenever the player picks up a coin from a spawn location so that it can be used again. Coins typically on 5 second intervals, however if there are no coins on the field (ie the coincount is equal to zero) a coin is immediately spawned to keep the player from waiting.\
\
Part 2:\
  The game has simple diffuse lighting in the form of the grass seen in the play area and around the cliffs. This is the only shader I chose to manually code rather than using Shadergraph. I vastly prefer Shadergraph as I find it more transparent and easier to understand what the individual building blocks of your shader does, but I figured it'd be for the best to demonstrate that I am capable of coding a shader if need be. Diffuse lighting with ambient lighting is also present for the cliff faces that border the play area and box the player in. Specular lighting also exists on the coins the player collects, which makes both logical and practical sense since it is best for the players objective to be shiny and eyecatching. Emissive lighting was also added for the stars that fall on the player for the same practical and logical reasons that coins were given the shiny lighting, the stars need to be eyecatching and stars glow so it only made sense.\
\
Part 3:\
  The game has a
\
Links:
