# Jump Jump!

A simple game developed with Unity Engine.

## Authors

* nickyc975

* Mark-Fenng

## Game Introductions

### Conceptions

* Energy

  * The energy level is shown as an orange bar.

  * The more energy the player has, the faster it can run.

  * When the energy level is higher than 50%, the health level will increase gradually;

  * Every coin will supply 20% energy until the energy level is 100%;

  * Energy level will decrease gradually;

* Health

  * The health level is shown as a red bar.

  * The game will end when the health level of the player is 0;

* Saw

  * The Saw will chase the player in a fixed speed. 

  * If the player runs too slow, the saw will catch up and end the game.

* Spike

  * If the player hit spikes, the health level will decrease, 10% for each hit.

* Energy Coin

  * Each coin will supply 20% energy.

  * Each coin will also add 5000 points to the score.

### Operations

* Press `space` key for a normal jump.

* Press `up arrow` key for a high jump.

### Levels

There are 3 levels in the game, level 1, level 2 and level 3. Level 1 is the easiest and level 3 is the most difficult. The difficulty comes from less distance between spikes and more complexity of terrain.

User can choose the level he or she wants in the first scene.

### Score and Ranking

* The score is calculated by the following formula:

  $$score = distance + numberOfCoins * 5,000$$

  Here the $distance$ is the distance that the player ran through and the $numberOfCoins$ is the number of coins that the player got.

  If the player arrives at the chest at the end of the ground, additional $50,000$ points will be added.

* The ranking is base on the score and different levels hve different rankings.

### Audio

The volume of the background music can be adjusted in the first scene.

## Difficulties Encountered

* Sometimes press space key or up arrow key will not result in player jumping.
  
  The reason is that we put the key pressing detection in the FixedUpdate function. It should be put in the Update function and save the detection result so that the FixedUpdate function can know.

* The player stumbles after hitting some barriers and after that it will run in some strange poses.
  
  Set the `freezeRotation` property of the Rigidbody2D component of the player to true to avoid rotation.

## Contributions

* nickyc975
  
  * Made a basic version of the game which implemented all the game conceptions and operations above. But there were no different levels, no complicated terrains, no score and ranking in that version.
  
  * Added different levels.
  
  * Added background music to the game.

* Mark-Fenng
  
  * Created all the complicated terrain templates.
  
  * Added score and ranking.
  
  * Looked for resources (pictures, animations and so on) to build the game.