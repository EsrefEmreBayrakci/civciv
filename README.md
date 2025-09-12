# 🐣 CivCiv - Unity 3D Adventure Game

<div align="center">
  <img src="https://img.shields.io/badge/Unity-2022.3+-blue.svg" alt="Unity Version">
  <img src="https://img.shields.io/badge/Platform-Windows-lightgrey.svg" alt="Platform">
  <img src="https://img.shields.io/badge/Genre-3D%20Adventure-green.svg" alt="Genre">
  <img src="https://img.shields.io/badge/Status-In%20Development-orange.svg" alt="Status">
</div>

## 🎮 Game Overview

**CivCiv** is an exciting 3D adventure game built with Unity where players control a character in a dynamic world filled with collectibles, power-ups, and challenging obstacles. The game features a unique cat AI that pursues the player, creating thrilling chase sequences and strategic gameplay.

### 🎯 Game Objective
Collect all 5 eggs scattered throughout the level while avoiding the persistent cat enemy and managing various power-ups and obstacles.

## ✨ Key Features

### 🏃‍♂️ **Dynamic Player Movement**
- **Smooth 3D Movement**: WASD controls for fluid character movement
- **Advanced Jumping System**: Space bar for jumping with cooldown mechanics
- **Sliding Mechanics**: Q key for sliding with enhanced speed and drag
- **State-Based Animation**: Seamless transitions between idle, walking, jumping, and sliding states

### 🐱 **Intelligent Cat AI**
- **Multi-State Behavior**: Idle, Walking, Running, and Attacking states
- **Dynamic Pursuit**: Cat chases player when on ground, becomes passive when player is airborne
- **Smart Pathfinding**: Uses Unity NavMesh for realistic movement patterns
- **Attack System**: Close-range attack mechanics with proper range detection

### 🥚 **Collectible System**
- **Egg Collection**: Primary objective - collect all 5 eggs to win
- **Wheat Power-ups**: Three different types of wheat with unique effects:
  - 🌾 **Gold Wheat**: Increases movement speed temporarily
  - ✨ **Holy Wheat**: Enhances jump force for better mobility
  - 🍂 **Rotten Wheat**: Decreases movement speed (negative effect)
- **Visual Feedback**: Real-time UI updates and camera shake effects

### 🎨 **Rich Visual Experience**
- **Stylized Water System**: Beautiful water effects using Bitgem StylisedWater
- **Particle Effects**: Enhanced visual feedback for interactions
- **Smooth Animations**: DOTween integration for polished UI and object animations
- **Camera Shake**: Cinemachine-powered camera effects for impact feedback

### 🎵 **Audio System**
- **Comprehensive Sound Design**: 15 different sound types including:
  - Jump sounds, pickup effects, win/lose music
  - Cat sounds, interaction feedback, UI button sounds
- **Background Music**: Dynamic music system with play/pause functionality
- **Audio Management**: Centralized audio system with proper volume controls

### 🎮 **User Interface**
- **Real-time Player State UI**: Visual representation of current player state
- **Booster Status Display**: Shows active power-up effects with animations
- **Win/Lose Screens**: Complete game over screens with timer display
- **Settings Menu**: Music and sound controls with pause functionality
- **Timer System**: Tracks completion time for performance measurement

## 🎮 Controls

| Action | Key | Description |
|--------|-----|-------------|
| **Movement** | `WASD` | Move character in 3D space |
| **Jump** | `Space` | Jump with cooldown system |
| **Slide** | `Q` | Slide for increased speed |
| **Pause** | `ESC` | Open settings menu |

## 🛠️ Technical Features

### **Unity Technologies Used**
- **Unity 2022.3+** - Latest Unity LTS version
- **Cinemachine** - Advanced camera system
- **DOTween** - Smooth animations and transitions
- **Unity Input System** - Modern input handling
- **NavMesh** - AI pathfinding
- **TextMeshPro** - High-quality text rendering

### **Code Architecture**
- **State Machine Pattern** - Clean player and AI state management
- **Event-Driven System** - Decoupled communication between systems
- **Scriptable Objects** - Data-driven design for collectibles
- **Interface-Based Design** - Modular collectible and boostable systems
- **Singleton Pattern** - Centralized managers for game state and audio

### **Performance Optimizations**
- **Object Pooling** - Efficient collectible respawning
- **LOD System** - Level of detail for distant objects
- **Efficient State Management** - Minimal computational overhead
- **Memory Management** - Proper cleanup and resource management

## 📁 Project Structure

```
Assets/
├── _GameAssets/
│   ├── Scripts/
│   │   ├── Managers/          # Game management systems
│   │   ├── Player/            # Player controller and states
│   │   ├── Cat/              # AI cat behavior
│   │   ├── Collectibles/     # Collectible items system
│   │   ├── UI/               # User interface components
│   │   ├── Water/            # Water system integration
│   │   └── Enums/            # Game state definitions
│   ├── Scenes/               # Game scenes
│   └── [Other Assets]        # Models, textures, audio
├── Plugins/                  # Third-party plugins
└── Settings/                 # Unity project settings
```

## 🚀 Getting Started

### Prerequisites
- Unity 2022.3 LTS or later
- Windows 10/11 (64-bit)
- Visual Studio 2022 (recommended)

### Installation
1. Clone the repository:
   ```bash
   git clone [repository-url]
   cd civciv
   ```

2. Open the project in Unity Hub
3. Wait for Unity to import all assets and compile scripts
4. Open the `GameScene` from the Scenes folder
5. Press Play to start the game

### Building the Game
1. Go to `File > Build Settings`
2. Select your target platform
3. Click `Build` or `Build and Run`




---

<div align="center">
  <p>Made with ❤️ using Unity</p>
  <p>© 2024 CivCiv Game Project. All rights reserved.</p>
</div>
