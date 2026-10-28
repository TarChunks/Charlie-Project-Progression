Charlie Project Progression README\
Written by: Charlie Burnham\
\
Part 1:\
\
  The game I've created for this project is simple in nature. You play as a UFO and your goal is to gather the coins that spawn around you in a small area and avoid stars that fall from the sky and explode. The player wins upon collecting 10 coins and loses upon touching either the stars or the explosions they create. The play area is restricted to a small grassy area surrounded by cliff faces. This was done for practicalities sake as I figured a small area would be much easier to apply shading and lighting to singlehandedly over a (relatively) brief period of time.\
\
Part 2:\
  The game has simple diffuse lighting in the form of the grass seen in the play area and around the cliffs. This is the only shader I chose to manually code rather than using Shadergraph. I vastly prefer Shadergraph as I find it more transparent and easier to understand what the individual building blocks of your shader does, but I figured it'd be for the best to demonstrate that I am capable of coding a shader if need be. Diffuse lighting with ambient lighting is also present for the cliff faces that border the play area and box the player in. Specular lighting also exists on the coins the player collects, which makes both logical and practical sense since it is best for the players objective to be shiny and eyecatching. Emissive lighting was also added for the stars that fall on the player for the same practical and logical reasons that coins were given the shiny lighting, the stars need to be eyecatching and stars glow so it only made sense.\
