# 5250Constellation
Constellation (Team 10) Game Project repository for CPSC 5250 22WQ Mobile Software Development

This is a program built using Xamarin and C# with Visual Studio Enterprise for Windows and Android. It was developed over a 10 week quarter, utilzing Agile development methods with a team of 3 developers and 2 artists. Its purpose was to demonstrate cross-platform application development, with an emphasis on software class design and requirement developement, and to give developers experience working with artists and other functional team members.


---

# Battle for the Cosmos
## Game Overview
The battle for the Cosmos is a role-playing game in which a team of 6 agents in black fights against six constellations of the Western zodiac disguised as ordinary citizens. You, as the leader of the men in black team, will try to claim as many resources as possible along your teleportation between cities in the US to stop the evasion of the constellations before they can contact the other six constellations that already successfully integrated into the human society and create an asteroid attack that is powerful enough to crush the entire earth.

## Overall Game Mechanics
### Game Mechanics
The player will lead six characters of choice to fight against six constellations. The player could arrange the characters across the board grid in their portion of territory that is half of the game board once when at turn. The player will roll the 20-sided dice to perform character evasion. When all the mobs and the boss in a round are killed, the player will receive randomized items at the end of the round. The player will win when all the six constellation bosses are killed.  

### Experience Points
When the Characters defeat a Monster, Monsters give Characters Experience Points. Experience earned by each Character is proportionate to the amount of damage they have delivered to the given Monster.

*Example:* The Monster Giant Fish has 10 Heath. The Character Steve does 8 damage to the Giant Fish, and the Character Barry does 2 damage to the same Monster. The Monster Giant Fish gives 2500 Experience Points when defeated. Steve gains 2000 Experience Points from dealing 80% of the damage to Giant Fish, while Barry gains 500 Experience Points from dealing 20% of the damage.

If the proportioned Experience shared with a Character is fractional, the Experienced earned is rounded up to the next whole number.

### Leveling Up
When the Experience Points are greater than the Experience required for the next Level, the Character’s Level will increase. The Character can Level Up during the battle, because the amount of Character Experience Points are checked at the end of a Character’s turn. A Character can Level Up multiple levels in one turn if the amount of Experience Points earned is great enough.

*Example:* The Character Steve defeats a Monster Giant Fish. Steve is at level 2 and currently has 500 Experience Points. The Giant Fish is at level 5 and gives 2500 Experience Points when defeated. At the end of Steve’s turn, Steve Levels Up to Level 4 because Steve has 3000 Total Experience Points.  

A Character’s Maximum Level is 20. Character’s abilities change with each Level increase. When a Character’s Level increases, its Maximum Health increases by the roll of a ten-sided die (d10).

### Attack Hits and Misses
The player will roll a twenty-sided die (d20) to determine their attack hits/misses. If the player rolls a 1, that would be an auto miss. If the player rolls a 2, that would be an auto-hit. Otherwise, the attack hit, or miss will be determined by the roll number adding with the character's level adding with the player level attack's damage. The player's level damage is 1/4 of the player level rounded up to the nearest integer. If the final adding of the stats is greater than the target defense adding the target level, then it is a hit. Else, it is a miss, and the character's turn is over.    

### Damage
The player will roll a twenty-sided die (d20) to determine their attack damage. The attack damage is calculated by adding the weapon damage with the character's damage. The character's attack damage will be specified during the character selection at the beginning of the round. The target health is reduced by the attack damage as whole number.
 
## Character
### Character Overview
 
There are seven characters in this game. Every character has the ability to hit the opponent to gain experience points. The characters are agents trying to protect the earth from invading Constellation aliens. 

If the experience of each character earned is greater than the next level, the character levels up. Leveling up will allow the character to increase his max health. For every level, the max health is determined by a random dice roll which gets added to his current max health value. If a character’s current health is less than 0, the character dies.

### Character Jobs
Characters in this game can have one of three different jobs: Defender, Striker, or Support. These Jobs grant the Character special abilities and bonuses. The abilities and bonus are as follows:


**Defender**

Defender Characters are the protectors of the Agents. They have high Defense but move slower than other Characters.
Defender Characters have the following features:
-	+4 bonus to the Character’s Defense Attribute
-	-2 penalty to the Character’s Speed Attribute

Defender Characters have the following Job Abilities:
-	Block: The Defender Character enters a defensive stance to block the next attack from a Monster. The Defender’s Defense Attribute increases by 2 points until their next turn.
-	Guard: The Defender Character protects an adjacent Character. The Defender Character takes the place of the Character being Guarded on the next attack from a Monster.


**Striker**

Striker Characters are the rogues, assassins, and brawlers of the Agents. They have high Attack and Speed but have lower Defense than other Characters.
Striker Characters have the following features:
-	+2 bonus to the Character’s Attack Attribute
-	+2 bonus to the Character’s Speed Attribute
-	-2 penalty to the Character’s Defense Attribute

Striker Characters have the following Job Abilities:
-	Dodge: The Striker Character nimbly evades the next Monster’s attack The Defender’s The Monster’s attack is an automatic miss.
-	Double Strike: The Striker Character can attack twice in one turn, but the next Monster attack on them is an automatic hit


**Support**

Support Characters are the medics, mechanics, and scientists of the Agents. They have no bonuses or penalties to their Attributes, but they can heal other Characters without using Items and give buffs to other Characters
Support Characters have the following Job Abilities:

-	Heal: The Support Character restores health to an adjacent Character
-	Boost Attack: The Support Character gives a buff of +2 Attack to an adjacent Character 
-	Boost Defense: The Support Character gives a buff of +2 Defense to an adjacent Character
-	Boost Speed: The Support Character gives a buff of +2 Speed to an adjacent Character
 
## Monsters
There are six monsters in this game. Monsters are aliens invading earth to cause harm. These monsters are zodiac constellations such as Capricorn, Taurus, Leo, Cancer, Virgo, and Libra with special powers to injure characters. Monsters are further divided into attackers, defenders, and healers. The attackers cause more damage when they hit a character but have lower experience points. The defenders use items to defend themselves from attacks and have higher experience points. The healers have the power to heal themselves and other monsters when hit with moderate experience points.

Each monster has experience points that it gives. When a monster is hit, its experience points decrease in proportion to the damage caused by the character. Every time it loses experience points, its health decreases. Once the health of the monster is less than 0, it dies.

## Items
Items are game objects that can be held by Characters and are dropped by Monsters as rewards during battles. An item provides a boon or a bane to one attribute of the Character that has it equipped. Boons and banes for the same attribute from multiple different items add together and stack, to the player's benefit.

A Character can only have one item per location. Characters have seven (7) total locations to equip items: head, necklace, primary hand, off hand, left finger, right finger, and feet. Items must be able to be equipped in only one location.

During battle, the player may have multiple items of the same name and benefit equipped by their Characters. When a Monster drops an item when it dies, the Characters can have the item automatically equipped if the Character does not have an item in currently equipped in the same location as the new item. If the Character has an item in the same location as the new item, it can be swapped if the new item's benefit is better than the one currently equipped by the Character. If an item is not equipped after it is dropped by a Monster, it is sent to the item pool for the player. Items stored in the item pool become available for allocation at the end of the turn.

Characters that have not killed a Monster and do not have an item equipped in any location, are automatically assigned an item from the available item pool at the end of the turn. When a Character dies, their equipped items are added to the existing pool of items. Items remaining in the item pool at the end of a battle that have not been equipped to Characters are lost.

## Game Play
Upon starting a new game, the player is presented with a screen displaying all game Characters from which they choose their starting party of six (6) Characters. After selecting the Party, the player selects the Begin button on the screen to initiate the delve run and subsequent battles.

At the beginning of each battle, the game picks six (6) random Monsters from all the Monsters available to fight against the player. The player is shown the images of their Party along with the images of the Monsters chosen for the battle, and the player selects the Start Battle button to continue. On the next screen, the player is shown the name, level, and maximum health of each of their Characters in their Party. The name, level, and maximum health of each Monster the player's Party will be battling is also displayed on the same screen.

During an attack, the player is shown a status screen that displays all the living Characters in the Party and all the living Monsters in the current battle. Only living Characters and Monsters can participate in turn or be active targets. Once the player has selected the Next Attack button, the Character or Monster that is next in the initiative order proceeds with attacking a living Character or Monster.

Initiative is determined by the Speed Attribute of the Character or Monster. Initiative ties are handled by comparing highest level, highest amount of experience points, prioritizing Characters before Monsters, alphabetical order of Name attribute, then the position in the Party list.

The winner of the initiative check is then able to attack their enemy. The attack to hit is calculated by rolling a twenty-sided die (d20) and comparing the result to the defender's defense attribute. Success is determined when the Attack roll plus the attacker's level and attack modifiers are greater than the defender's defense value and their level.  

- Attack = d20 Roll + Attacker Level + Attack attribute + Attack modifiers 
- Defense = Defense attribute + Defense modifiers + Defender Level 
- Success = Attack > Defense
  
*Example:* The Character Steve is attacking a Monster Giant Fish. Steve is at level 2, their attack attribute is 10, and they have items that give them a +2 to attack. The Giant Fish is at level 5, their defense attribute is 15, and they have no modifiers to defense.  Steve's total attack modifier is +14, while the Giant Fish's Defense is 20. Steve needs to roll a 7 or better to successfully attack the Giant Fish. Steve rolls an 11 on the d20. Steve's total attack is 25 against the Giant Fish's defense of 20. Steve successfully hits the Giant Fish.

For die rolls, if the die value is 1 the attack automatically misses while if the value is 20 the attack automatically hits regardless of the defender's defense value. 

After a successful attack hit, damage to the defender is calculated by rolling a die or dice for weapon damage and adding level damage. Level damage is determined by multiplying the attacker's level by ¼, rounding up to the nearest integer. The defender has their current health reduced by the amount of damage done as a whole number.

*Example:* The Character Steve successfully hit the Monster Giant Fish. Steve does not have a weapon currently. The weapon damage for Steve is 0, while their level damage is 1, since ¼ * 2 = 0.5 rounded up to 1. The Giant Fish takes 1 damage from Steve, and the Monster's current health is decremented by 1. 

Attacks continues between the Characters and Monsters by following the above rules until all Characters or Monsters have had a turn or are dead. Characters or Monsters are dead when their current health is zero (0) or less. The next turn starts by recalculating initiative for the remaining Characters and Monsters.

If all the Monsters are dead, the living Characters collect any Items dropped then continue to the next new battle. The living Characters can equip or swap out any Items automatically prior to the next battle. The game repeats the setup for the beginning of a battle. The game continues until all Characters are dead.

Once all the characters are dead, the game is over and the run ends.

When game is over, results from the run are displayed to the player. The player is shown the score for the last game, and other statistics such as number and list of the Monsters slain, and data related to each Character's death. The player may choose to play again or return to the home screen.
