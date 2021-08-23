# Sparta Global Solo Project

17-08-2021 - Sprint 1 - Start

<u>Sprint Goal</u> - To build the main component to the Minimum Viable Product (MVP), the game with some extra features like a login page and creating an account page. [![img](https://github.com/OnlyBiscuitHere/SpartaGlobalSoloProject/raw/main/images/Screenshot_16.png)](https://github.com/OnlyBiscuitHere/SpartaGlobalSoloProject/blob/main/images/Screenshot_16.png) Wireframes designed within sprint 1 in Wireframes.png

17-08-21 - Sprint 1 - End [![img](https://github.com/OnlyBiscuitHere/SpartaGlobalSoloProject/raw/main/images/Screenshot_17.png)](https://github.com/OnlyBiscuitHere/SpartaGlobalSoloProject/blob/main/images/Screenshot_17.png) <u>Sprint review</u>: 

- Game has a login page, you can create a new user. Using user account, you can launch into a new game with the score updating each pipe that is passed. And game resets when user presses 'R'. 
- An admin account is added with their own screen through logging with specific field values but no further functionalities have been applied. Login page works by having an account in the Users database that is checks for existing users and opens the game window. The create account page works by checking if account is already in the database with those *exact* fields. 
- Once an account is created the Game works by loading in sprites for the bird, pipes and clouds, set variables like, score, gravity and the bird's hitbox. Using the System.Timers library, a timer is applied which is how the game updates with respect to the events happening in the window. The pace of the game is set by a value of how many times in milliseconds the event is updated. 
- When the user presses 'Spacebar' the bird tilts upwards and ascends up the screen and when released, the bird tilts downwards and falls due to the gravity value set. 
- When the game is over the score is updated in the Scores database and some conditional statements update the highest score the user has achieved if it is a score greater than the set highest score.

<u>Sprint Retrospective</u>: Sorted a non-functional requirement that would be detrimental to how the game would be played however, this set back ended up halting a lot of the work that would be needed for the MVP.

18-08-21 Sprint 2 - Start Sprint Goal - Reach the MVP which is a basic game with a leaderboard screen and a create account feature so that new users can play the game. [![img](https://github.com/OnlyBiscuitHere/SpartaGlobalSoloProject/raw/main/images/Screenshot_18.png)](https://github.com/OnlyBiscuitHere/SpartaGlobalSoloProject/blob/main/images/Screenshot_18.png) 18-08-21 Sprint 2 - End - MVP achieved [![img](https://github.com/OnlyBiscuitHere/SpartaGlobalSoloProject/raw/main/images/Screenshot_19.png)](https://github.com/OnlyBiscuitHere/SpartaGlobalSoloProject/blob/main/images/Screenshot_19.png) <u>Sprint review</u> - 

- Leaderboard screen is created and can be accessed when the user press 'L' to open a new window that shows other players and their highscore. 
- When a user finds the game too difficult they can lower the difficulty by pressing 'N' which will reload the game and apply the new game speed from the difficulty database which saves their option. 
- When a user finds the game too easy they can press 'Y' to increasing the difficulty by speeding up the rate at which the game updates. For the difficulty settings, they are specific the users when they last played and had the speed setting saved. The difficulty is achieved when the game reloads when they press 'Y' or 'N' and the rate at which the event method is being called is altered. 
- Admin account can access the leaderboard through their own screen. 
- The leaderboard screen works by joining the users table and the scores table to show the username, highscore and the date their account was made.

<u>Sprint Retrospective:</u> Overall this sprint went well with implementing a lot of the functionality that the game should have and approaches the MVP set out. 

19-08-21 Sprint 3 - Start 

<u>Sprint Goal</u> - Implement more functionality in the Admin feature as well as, implement a audio for when the user dies in the game.

![img](https://github.com/OnlyBiscuitHere/SpartaGlobalSoloProject/raw/main/images/Screenshot_20.png)

19-08-21 Sprint 3 - End

![img](https://github.com/OnlyBiscuitHere/SpartaGlobalSoloProject/raw/main/images/Screenshot_21.png)

<u>Sprint review</u> - 

- During this sprint, the already defined Admin feature gained further functionality from just initialising an empty table to initialising a table with all the users, their passwords and the date the account was made. Of which can be updated to have different details, in the fields, or the account can be deleted off the database. 
- With regards to the game, when the user dies from either falling off the screen or crashing into a pipe, a death theme song is played every times. Not to mention user tests have been made to make sure that the methods implemented are testable and return the right values.

<u>Sprint Retrospective</u>: Although not much was achieved this sprint the existing the items in the project backlog were not a necessity to the MVP and can remain in the backlog till later version.

<u>Overall project retrospective:</u> Overall the project has been quite successful with few blockers that have occurred however, there have been moments where the MVP had to be redefined to facilitate more functionalities that a MVP should have.
