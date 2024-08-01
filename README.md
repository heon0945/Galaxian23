# Galaxian23
The project is a mobile version of a 2D shooter game by Namco called "Galaxian," which was released in 1979.
The game will retain the iconic Galaxian space theme and color-coded enemy plane imagery, but will add new attack styles, abilities, and item elements to the game. 

## Control
- Left and Right arrow key
- Avoiding Enemy Attacks
- Attacking enemies
- Acquiring Items

## Rule
- End Conditions
	- Players have 3 lives
	- Player loses lives when colliding with enemies or being attacked by enemies
	 -Game ends when all 3 lives are lost
- Winning Conditions
	- Earn points for each enemy killed
	- Survive to the end and make the final kill on the boss to win
- Fever Time
	- Become invincible for a short period of time to attack enemies
	- Gain a stronger bullet attack

## Elements
### Enemies
Enemies move from top to bottom on the y-axis, with the same color-coded images as in traditional Galaxian, and attack the player. 
Whereas in the original Galaxian, you could tell from the formation of the enemies how many or what type of plane they were going to attack from the start, in this game, enemies are generated from random locations and enter the screen. Also, whereas in the original Galaxian, the curved flight of the enemies allowed for a variety of attack patterns, this game varies the types of attacks and behaviors of the enemies, which adds to the gameplay.
- Red
	- A plane that travels in a straight line at high speeds and loses life if the player collides with it. They are immune to the player's attacks, so the player must quickly dodge them.
- Green
	- An airplane moving toward the player, which loses life if the player collides with it. The player can attack them to shoot them down or avoid colliding with them.
- Purple
	- A plane that travels in a straight line and shoots bullets, and loses life when the player is hit by its bullets or collides with it. Players can attack them to shoot them down or avoid colliding with them.
- Yellow
	- A plane that moves forward and shoots bullets at the player, losing life if the player is hit by its bullets or collides with it. The player can attack them to shoot them down or avoid colliding with them.
- Blue
	- An airplane that moves forward toward the player and has 3 lives. The player loses a life if they collide with it. The player can attack it 3 times to shoot it down or avoid colliding with it.

### Items
They are randomly generated and appear and move down the screen based on gameplay time. When the player acquires an item, it increases their speed and makes them immune to enemy airplane attacks for a period of time. During this time, a large number of enemy airplanes will also appear, giving the player a chance to score significant points without the risk of being attacked.

### Boss
Unlike other enemy planes, the boss does not move downward, but instead moves randomly from side to side and fires bullets in a straight line. 
The boss has HP, and the player must consistently attack the boss while dodging its attacks to reduce its HP. The player can only attack the wings and head of the boss at first, and these parts are destroyed after taking a certain amount of damage. 
Once all three parts are destroyed, the player can begin attacking the body of the boss, and when the total damage is accumulated and the boss loses all of its HP, the boss is destroyed and the player wins. As the boss' HP decreases, its attacks become more spaced out and it moves from side to side more often. Also, the bullet pattern changes when both wings and head are destroyed and only the torso remains.


The project includes a detailed code description file and a playthrough video.
