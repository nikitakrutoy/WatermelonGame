# Watermelon Wonderland

[WebGL version on Unity Play](https://play.unity.com/mg/other/watermelon-wonderland)

[Rainbow version on itch.io](https://dilika.itch.io/watermelonwonder)

[Video](https://www.youtube.com/watch?v=x8_XlGubKa0&feature=youtu.be&ab_channel=volvvictory)

## Case:

**Children Pain Distraction challenge for Helsinki University Hospital.** In other words, a game that helps children with pain during medical procedures.

## Problem:

We gave our friends and family a survey with questions about their most painful experience from childhood and we received about 30 answers, from which we pick a major theme: **fear of dentistry procedures**. So we decided to solve this case.

## Solution:

### Controller

Everybody agrees that sensory items help people to relax. We decided to combine a popular squish toy with an input device to make a controller for our game character!
Research on VR shows, that the more you are engaged, the less you concentrate on the pain and anxiety. [1] Our groundbreaking idea is that you both squish a toy to relax and control the same toy in the game! This helps the player to feel related to the character and therefore to be more engaged in a game.
We were inspired by the OriOri controller from orioritech. It is a squish based controller to play AR games. We put a lot of effort to decide how are we going to achieve the same effect, and our current implementation uses a controller based on Muscle Sensor, Bluetooth and Arduino Uno. It's a draft version to demonstrate squish based mechanics, as using Muscle Sensor may be inconvenient during the real procedure.

### VR

Relevant researches confirm that clinical use of virtual reality can provide a good level of distraction from pain in dental procedures. [2] We took into consideration that the patient can't rotate his head during such a procedure, that's why we chose mobile VR for its price and simplicity.

### Gameplay

Our game is an infinite runner. You play as cure watermelon Mel with a jetpack, who try to collect as many seed coins as he can. Evil vegetables confront our hero and want to steal all his seeds coins. With our unique squeeze controller, you can affect how high watermelon is flying and dodge vegetable attacks. It is quite enjoyable to play with gravity using squeezing and stretching. We see great potential in the VR and custom controller combination.

### Results

- custom squeeze toy controller based on Arduino Uno + MyoWare Muscle Sensor + Bluetooth
- endless runner level made in Unity with enemies and obstacles to avoid and seedcoins to collect
- cute models of main character and enemies made in Blender
- custom animations for the characters made in Unity and Blender
- procedural generated enviroment optimized for mobile devices
- you play as a watermelon with a jetback who can fly!

## Real-world impact:

The painful experience during procedures in childhood impacts how people perceive dental treatment in adulthood. Many of those interviewed said that they think negatively of a visit to the dentist and often delay it. We think that making kids' dentist experience more positive will help them when they are adults.

## Technologies:

Unity — just because it's a good tool for mobile game development
Arduino Uno + MyoWare Muscle Sensor + Bluetooth — as a temporary solution, which is easy to implement
Mobile VR — best price on VR market
IOS/Android — multiplatform solution
Blender — for 3D content creation

## Plans:

1. Squeeze controller will be inside the toy and will be made absolutely invisible, comfortable, and safe to use
2. The doctor will be able to set up the difficulty of the game and game pace inside their own app
3. Lots of other characters to control! We want our player to pick their favorite fruit to get the most fun from the game
4. New locations and challenges (e.g.: winter wonderland, sweet candyland)
5. Mini games with different mechanics (e.g.: squeeze controller to crack a real watermelon and get a bonus)
6. More content with other characters and levels! More appealing graphic and polished gameplay based on user feedback
