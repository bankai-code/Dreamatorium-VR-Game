# Dreamatorium VR Game

Dreamatorium is an immersive VR experience designed for Google Cardboard on Android, allowing players to interact in a game room setting with multiplayer and voice chat capabilities. This project includes various mini-games and customizable interactions to create a dynamic and engaging virtual environment.

## Features

- **Video Playback**: Watch synchronized video content with playback controls (Play, Pause, Stop).
- **Ambient Music**: Select and synchronize background music among players for a cohesive atmosphere.
- **Lighting Customization**: Adjust lighting scenes (Morning, Evening, Night) with real-time multiplayer synchronization.
- **Dartboard Game**: Full gameplay with scoring, difficulty levels, and multiplayer support.
- **Kitchen Interactions**: Realistic audio-visual feedback when interacting with kitchen items.
- **Player Stats**: Track stamina and hydration levels, affecting gameplay and requiring interaction with consumables.
- **3D Humanoid Avatar**: Customizable avatars for each player, adding to the immersive experience.
- **Multiplayer & Voice Chat**: Real-time multiplayer interactions and voice communication using Photon.
- **Basketball Game**: Pick up and shoot basketballs with physics-based scoring.

## Technical Overview

### Video and Music Synchronization

Photon networked events enable real-time video and music synchronization, allowing all players to experience media playback simultaneously.

### Interaction Techniques

Using raycasting for interaction, players can select objects in the environment by moving their heads and using a Bluetooth joystick. Interactions include:
- **Analog Joystick**: Navigate the environment.
- **B Button**: Trigger UI actions.
- **X Button**: Interact with objects (TV, dartboard, appliances).
- **B Button**: Throw darts/basketball and consume food.

### Multiplayer & Voice Chat

Photon’s networking API handles multiplayer room creation, player movement synchronization, and voice streaming for seamless communication between players.

### Scene and Object Interaction

Scenes and object states are synchronized across players to ensure a cohesive multiplayer experience, with real-time updates for any changes in the environment (lighting, music, etc.).

## Installation & Setup

1. Clone the repository:  
   ```bash
   git clone https://github.com/bankai-code/Dreamatorium-VR-Game.git
