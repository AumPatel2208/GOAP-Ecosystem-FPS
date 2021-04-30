# TODO

## PROJECT

- [x] ~~When talking about design patterns, mention how unity uses an Entity Component System.~~
  - [x] ~~Talk about how I refactored the creature class and created the BaseAIGoap to refactor the Debugging Log~~
- [x] ~~Talk about refactoring the AI system a little~~
  - <del>
    - As it currently stood, the AI will only execute a plan of actions if those actions fulfilled **all** the goal conditions
    - However this is not desirable as if there are no actions available, it is better to do something that will fulfil one goal over doing nothing. 
    - This will allow the actions to be more loosely coupled as in the first build, I had to have a series of actions 'connected' together through post-effects.
      - eg. Find food would not be executed if the creature was hungry and had not found food, so it would just go hungry; in the first build I also added an effect to findFood that was 'isHungry: false', which would fulfil the all 2 conditions 'foodTargetNull: false, isHungry: false', however the action find food does not directly fill the hunger of the creature so providing it with this effect is not truthful, therefore refactoring the system seems to be the best option over providing false effects to actions. 
      - This will make it so when the system gets more complicated than 2 goals and 2 actions, it will still be 'simple' to manage.
    - SOLUTION:
      - Detect when a plan fails whether the plan that was generated was a partial plan. If so, then multiply the cost for that by an arbitrary amount, in this case 10, and perform the action. </del>
- [ ] Change all references to self to make them sound more formal, try to avoid the author however remove I
- [ ] Food Chain explanation, write about bi-directional dictionaries.
  - Explain how I required the use of a dictionary where I could use the values as keys as well, and the simplest solution I found was to create two dictionaries. 
  - Later when writing the report, I found this article that explains that that data structure is called a bi-direction dictionary
    - https://erdiizgi.com/data-structures-for-games-bidirectional-dictionary-for-unity-in-c/
- [x] Explain the GOAP library properly
- [ ] Expand upon Animator
  - How it is built into unity 
- [ ] intro explains what I was hoping to achieve.
- [ ] Write about the changes from the PDD
- [ ] add intros to sections like Main Product.
- [ ] Larger images in appendix as well
- [x] Player
  - [x] Player Movement, and mouse look
    - [x] Add images
  - [x] Player Eat food
- [ ] Remove Negative things about the project
- [x] Explain when adding the stamina, Sword does 50 damage but costs stamina, but ranged wepon does 10 damage without costing stamina, and you can fire from range, so there is that **trade-off**
- [x] Excess Hunger refills health
- [ ] More about learning Unity
  - [ ] Scenes
  - [ ] Prefabs
  - [ ] Importing Assets
  - [ ] Attaching Components
  - [ ] Mono Behavoiurs
  - [ ] 

## Appendix
- [ ] Snapshot of git version history
- [ ] Tests
- [ ] Mention Turbosquid as the location for 3d assets
- [ ] Explain the Unity Asset store
- [ ] Layers and tags in Unity **GLOSSARY** with images in appendix
- [ ] Test cases
- [ ] Installation document
- [ ] Known Bugs
  - [ ] Sword
  - [ ] Two Agents going for the same target may overlap each other as the pathfinding system will give them both the same path.

## Glossary
- In-Fighting
- Goap
- AI
  - refering to Game AI
- GameObject
- Rigidbody
- Entity Component System
- PDD
- the author

## Testing
1 day
  - [ ] creating use cases
  - [ ] verifying the use cases with evidence
- Player Controller
  - Player's gravity builds up when on objects that are not tagged as ground, not big issue and does not need refinement to the player controller
- Creature would lock onto one target and not change the target
  - Added a Randomly find new food component to the creatures that calls the perform method in the find food action, basically interrupting the planning system,
  - the change works enough to be functional
- Finding a target
  - Would find target normally
  - the creature would not find a target after it was already hungry
  - this lead to implementing partial goal completion.
- Partial Goal completion
  - Multiplier scale was too low at 3, so was upped to 10.
  
## Asset Listing
- https://assetstore.unity.com/packages/2d/textures-materials/gridbox-prototype-materials-129127
- Stealth game enemy detection Unity
  - https://www.youtube.com/watch?v=mBGUY7EUxXQ
- https://arongranberg.com/astar/
- https://rkuhlf-assets.itch.io/ice-age

## CODE NO MORE
- [x] Roam action
- [x] Enemy Damage
- [x] Death for enemy
  - [x] particles for eating
  - [x] death for sloth
  - [x] STOP THE AI WHEN IT DIES
- [x] Eat when there is a ready food until the food is gone
- [x] ranged weapon
  - [x] Model
  - [x] Code
- [x] ranged weapon
  - [x] Charge the cross bow
- [x] Sabertooth can attack sabertooths

- [ ] VISIBILITY
  - [x] Vision Cone
  - [ ] Target is lost if it enters a grass element
- [ ] Enemy copy of Sabertooth however has a ranged attack
- [x] Health recovery by using hunger
  - That way a special health resource is not required
  - [x] any excess hunger is replaced as health
- [x] HUD for player health and the hunger
- [x] Stamina
- [ ] Short Level
- [x] Death for player
  - [x] Just reset the scene???
- [ ] Flee action when Threatened 
  - STRETCH







## TOOLS
UML generator
https://github.com/pierre3/PlantUmlClassDiagramGenerator
then compiled using plant uml


## Video
- Emphasise the positives
- Code walkthrough
  - just all the processes for everything

## Pre-Submission
- Rebuild and test the builds



## GIT TOKEN
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