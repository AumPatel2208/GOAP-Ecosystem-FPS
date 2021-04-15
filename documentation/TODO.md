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
      - Detect when a plan fails whether the plan that was generated was a partial plan. If so, then multiply the cost for that by an arbritrary amount, in this case 10, and perform the action

## CODE
- [x] Roam action
- [x] Enemy Damage
- [x] Death for enemy
  - [x] particles for eating
  - [x] death for sloth
  - [x] STOP THE AI WHEN IT DIES
- [ ] Death for player
- [ ] Eat when there is a ready food until the food is gone
- [ ] ranged weapon
  - [ ] Model
  - [ ] Animation
  - [ ] 
- [ ] VISIBILITY
  - [ ] areas where there is low visibility
  - [ ] refine the find food to only find food based on the visibility
- [x] ranged weapon
  - [ ] Charge the cross bow
  - [ ] 
- [ ] dark souls like death system
- [ ] 