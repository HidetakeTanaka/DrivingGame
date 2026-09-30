# Driving Game

A 3D driving game developed in **Unity** as a university team project.

The project focuses on arcade-style vehicle handling, driving feedback, and gameplay systems such as vehicle physics, braking, power-ups, damage, and dynamic vehicle audio.

## Overview

This project was created as part of the *Innovative Technologies* course at Rhine-Waal University of Applied Sciences.

The game includes a controllable vehicle using Unity's `WheelCollider` system, manual and automatic gear shifting, braking, vehicle damage, nitrous boosting, and audio feedback that reacts dynamically to the vehicle's movement.

## Features

- 3D vehicle driving using Unity `WheelCollider`
- Front-wheel, rear-wheel, and all-wheel-drive configurations
- Manual and automatic transmission modes
- Speed-dependent steering behavior
- Vehicle braking system
- Nitrous boost system
- Collision and terrain damage
- Vehicle health system
- Dynamic engine sound
- Brake screech sound
- UI and gameplay-related supporting systems

## My Contributions

My main responsibility in the project was improving the **vehicle audio and driving feedback systems**.

### Dynamic Engine Sound

I developed `EngineSoundManager.cs`, which creates a dynamic engine sound system using multiple layered audio sources.

Each engine audio layer has its own:

- minimum and maximum speed range
- minimum and maximum pitch
- audio source

The system reads the current vehicle speed from `CarController.carSpeed` and dynamically adjusts the pitch and volume of each audio layer.

Smooth interpolation using `Mathf.Lerp` is used to prevent sudden changes in pitch and volume while accelerating or decelerating.

This allows several engine sound samples to work together and creates a more responsive engine sound compared with using a single looping audio clip.

```text
Vehicle Speed
      ↓
EngineSoundManager
      ↓
Select / Blend Audio Layers
      ↓
Adjust Pitch + Volume
      ↓
Dynamic Engine Sound
```

The system was designed so that its parameters can be configured directly from the Unity Inspector.

**Sound Demo** : Watch the gameplay video on YouTube to hear the dynamic engine and driving sounds in action: https://youtu.be/R-b1arRIxhk?si=f2qQbB_v57Rv4PRG

### Brake Screech Sound

I also implemented `BrakeSoundPlayer.cs`.

The script plays a tire screech sound when:

1. the player presses the brake key, and
2. the vehicle is moving above a defined speed threshold.

When either condition is no longer satisfied, the sound stops.

This provides immediate audio feedback when the player brakes at speed.

The speed threshold and audio clip can be adjusted through the Unity Inspector.

## Vehicle Controller

The main vehicle system is implemented in `CarController.cs`.

It handles several gameplay systems including:

- acceleration
- braking
- steering
- wheel movement
- vehicle speed calculation
- automatic and manual gear shifting
- front-, rear-, and all-wheel drive
- vehicle health
- collision damage
- nitrous boosting

The audio systems interact with this controller by reading the vehicle's current speed.

## Technologies

- **Unity 6**
- **C#**
- Unity Physics
- `WheelCollider`
- Unity Audio System
- Git / GitHub

## Project Structure

```text
DrivingGame/
├── Assets/
│   ├── Scripts/
│   │   ├── CarController.cs
│   │   ├── EngineSoundManager.cs
│   │   ├── BrakeSoundPlayer.cs
│   │   ├── BasicTerrain.cs
│   │   ├── CarStatsModifier.cs
│   │   └── ...
│   ├── Scenes/
│   └── ...
├── Packages/
└── ProjectSettings/
```

## Running the Project

1. Clone the repository:

```bash
git clone https://github.com/HidetakeTanaka/DrivingGame.git
```

2. Open the project using a compatible version of Unity.

The project was developed with:

```text
Unity 6000.0.42f1
```

3. Open one of the available scenes in `Assets/Scenes`.

4. Enter Play Mode in Unity.

## Controls

The vehicle controller uses Unity's standard input system.

Typical controls include:

| Action | Input |
|---|---|
| Accelerate / Reverse | W / S or Arrow Keys |
| Steering | A / D or Arrow Keys |
| Brake | Space |
| Shift Up | Q |
| Shift Down | E |
| Nitrous | P |
| Reset Scene | R |

Some controls depend on the transmission and vehicle configuration selected in the Unity Inspector.

## What I Learned

Through this project, I gained practical experience with:

- C# scripting in Unity
- component-based game architecture
- communication between multiple Unity scripts
- vehicle physics and `WheelCollider`
- real-time audio control
- speed-dependent gameplay feedback
- audio pitch and volume interpolation
- debugging Unity components
- Git-based team development

One of the main challenges was connecting vehicle state information with audio feedback while keeping transitions natural. Implementing the engine audio system helped me understand how gameplay parameters can be transformed into responsive real-time feedback for the player.

## Repository

GitHub:  
https://github.com/HidetakeTanaka/DrivingGame

## Author

**Hidetake Tanaka**

B.Sc. Infotronic Systems Engineering  
Rhine-Waal University of Applied Sciences
