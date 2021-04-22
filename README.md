# L-etat-c-est-moi

The code is structured in the following way:
Data: The data structures on which the game is built. 
Managers: Handle the logic and initilization of the data structures
Links: Link the visuals to the data and contains temporary or frequently changing data (Such as grid position) to keep the data structures short and clean
Handlers: The monobehavior scripts attached to the game objects and initiliazes variables useful for debugging 

Currently included:

An expandable grid system
An expandable Entity system
A basic movement system
A basic brain
A basic player interaction (Build cubes when you click on a tile)

Near future To-Do:
An expandable behavior framework for the brain built on scriptable objects
Pathfinding
