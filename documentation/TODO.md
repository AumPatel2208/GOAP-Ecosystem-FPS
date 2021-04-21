# TODO

## PROJECT
- [ ] When talking about design patterns, mention how unity uses an Entity Component System.
  - [ ] Talk about how I refactored the creature class and created the BaseAIGoap t0 refactor the Debugging Log
- [ ] Milestone 2:
  - [ ] Talk about refactoring the AI system a little
    - As it currently stood, the AI will only execute a plan of actions if those actions fulfilled **all** the goal conditions
    - However this is not desirable as if there are no actions available, it is better to do something that will fulfil one goal over doing nothing. 
    - This will allow the actions to be more loosely coupled as in the first build, I had to have a series of actions 'connected' together through post-effects.
      - eg. Find food would not be executed if the creature was hungry and had not found food, so it would just go hungry; in the first build I also added an effect to findFood that was 'isHungry: false', which would fulfil the all 2 conditions 'foodTargetNull: false, isHungry: false', however the action find food does not directly fill the hunger of the creature so providing it with this effect is not truthful, therefore refactoring the system seems to be the best option over providing false effects to actions. 
      - This will make it so when the system gets more complicated than 2 goals and 2 actions, it will still be 'simple' to manage.
    - SOLUTION:
      - Detect when a plan fails whether the plan that was generated was a partial plan. If so, then multiply the cost for that by an arbitrary amount, in this case 10, and perform the action
- [ ] Change all references to self to make them sound more formal, try to avoid the author however remove I
- [ ] Mention Turbosquid as the location for 3d assets

## CODE
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
- [ ] Health recovery by using hunger
  - [ ] That way a special health resource is not required
  - [ ] any excess hunger is replaced as health
- [ ] HUD for player health and the hunger
- [ ] Short Level
- [ ] Death for player
  - [ ] Just reset the scene???
- [ ] Flee action when Threatened 
  - STRETCH