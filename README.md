# Snake Game

This project is a Snake game based on Windows Forms. This project features a unique mechanic: consuming a reward (apple) also creates an obstacle that is visually identical but game-ending. This adds a layer of risk and reward by forcing players to distinguish between safe and dangerous objects.

## Table of Contents

- [Project Features](#project-features)
- [Architecture](#architecture)
- [Technologies Used](#technologies-used)
- [Code Structure and Organization](#code-structure-and-organization)
- [Core Components](#core-components)
- [Business Logic](#business-logic)
- [Setup and Run Instructions](#setup-and-run-instructions)
- [Configuration and Settings](#configuration-and-settings)
- [Code Quality and Standards](#code-quality-and-standards)
- [Modification Guidelines](#modification-guidelines)
- [Project Rules](#project-rules)
- [License](#license)

## Project Features

- **Classic Snake Gameplay**: Control a snake to eat apples and grow longer.
- **Dynamic Difficulty**: Each apple eaten increases snake length and spawns a new "poisonous apple" (obstacle) on the map.
- **Risk-Reward Mechanic**: Poisonous apples are visually identical to normal apples, requiring players to remember their locations to avoid game over.
- **Score Tracking**: Player's score is tracked and displayed in real-time.
- **Collision Detection**: Game ends if snake hits walls or a poisonous apple.
- **Simple Interface**: Clean and intuitive user interface built with Windows Forms.
- **Background Music**: Includes background music that plays when the game starts.

## Architecture

The project follows a monolithic and event-driven architecture common for simple Windows Forms applications.

- **Presentation Layer**: All application logic resides in the `Form1.cs` class, which manages the user interface, game state, and user input.
- **Business Logic**: Game mechanics such as snake movement, apple consumption, obstacle creation, and collision checks are handled by methods within `Form1.cs`.
- **Data Layer**: No separate data layer; game state (snake position, score, etc.) is managed in memory.

## Technologies Used

- **Language**: C#
- **Framework**: .NET 6.0
- **Interface**: Windows Forms

## Code Structure and Organization

- **Directory Structure**:
    - `Form1.cs`: Main code file containing all core game logic (movement, collision, scoring, etc.).
    - `Form1.Designer.cs`: File where interface components are programmatically created and configured.
    - `Program.cs`: Application entry point that launches `Form1`.
    - `yılan oyunu.csproj`: C# project file containing project settings and dependencies.
    - `portal-2-end-credits-song-want-you-gone-by-jonathan-coulton-1080p-hd.wav`: Sound file that plays when the game starts.
    - `.vs/`, `bin/`, `obj/`: Standard directories created by Visual Studio and build processes.
- **File Naming**: Standard Visual Studio Windows Forms project naming conventions are used.
- **Code Style**: Method names are in Turkish (`elmaYeme`, `carpisma`). Variable names use a mix of abbreviated English (`locX`, `locY`) and Turkish (`yon`, `yilan`). Code follows a procedural structure within the `Form1` class.

## Core Components

- **Main Modules**:
    - `Form1`: The single and main class of the project.
    - `timer1_Tick`: The heart of the game. Triggered every 110 milliseconds to create the next frame of the game. This method triggers snake movement, apple eating check, and collision detection.
    - `Form1_KeyDown`: Listens to keyboard inputs to set snake direction (`yon` variable).
    - `label3_Click`: Method that starts the game when "START" label is clicked.
- **Data Models**:
    - `List<Panel> yilan`: A list of `Panel` objects representing each segment of the snake. Snake's head is `yilan[0]`.
    - `Panel elma`, `Panel odul`, `Panel duvar`, `Panel engel`: All other game objects (apple, reward, wall, obstacle) are also represented as `Panel` components.
    - Game state (score, direction) is stored in form-level variables (`label2.Text`, `yon`).

## Business Logic

- **Main Flows**:
    1. User clicks the "START" label.
    2. `label3_Click` method is triggered: Game area is cleared, start sound plays, snake is created, `timer1` starts, initial apples and walls are created.
    3. Each time `timer1` triggers (`timer1_Tick`):
        - New position of snake's head is calculated based on `yon` variable.
        - `hareket()` method makes the rest of snake's body follow the head.
        - `elmaYeme()` method checks if snake contacts an apple. On contact: Score increases, snake extends, and game area updates with new apples.
        - `engeller()` method adds an `engel` object to the game area that looks identical to apples (`Color.Red`) but ends the game when hit.
        - `carpisma()` method checks if snake has hit walls, itself, or previously created obstacles.
- **Data Processing**: All data processing is based on updating `Location` properties of `Panel` objects and modifying the score stored in `label2`'s `Text` property.

## Setup and Run Instructions

### Prerequisites

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Visual Studio](https://visualstudio.microsoft.com/) with **.NET desktop development** workload installed.

### Running the Project

1. **Clone the repository** or download the source code to your local machine.
2. **Open the solution file** (`yılan oyunu.sln`) in Visual Studio.
3. **Build the solution** by pressing `Ctrl+Shift+B` or selecting `Build > Build Solution` from the menu.
4. **Run the project** by pressing `F5` or clicking the "Start" button in the Visual Studio toolbar.
5. Click the "START" label to begin the game.

## Configuration and Settings

- **Config Files**: The project has no external configuration files.
- **Hardcoded Values**:
    - Game speed: `timer1.Interval = 110` (milliseconds).
    - Game area size: `panel1.Size = new System.Drawing.Size(600, 600)`.
    - Snake and apple piece size: `new Size(20, 20)`. These values are hardcoded in the source.

## Code Quality and Standards

- **Patterns Used**: Event-Driven Programming and Game Loop patterns are implemented.
- **Error Handling**: No explicit error handling mechanisms like `try-catch`. Game over is not an "error" but a state change, managed by `timer1.Stop()`.
- **Logging**: No logging structure exists in the project.

## Modification Guidelines

- **Adding New Features**: (Example: Adding a "golden apple")
    1. Add a new `Panel` object in `Form1.cs` (e.g., `private Panel goldenApple = new Panel();`).
    2. Write a method to create this apple (e.g., `createGoldenApple()`).
    3. Add logic in `timer1_Tick` or `elmaYeme` to check snake's collision with this new object.
    4. Code what happens on collision (e.g., extra points, speed boost, etc.).
- **Modifying Existing Features**: (Example: Increasing snake speed)
    - Decrease `timer1.Interval` value in `Form1.Designer.cs`.
- **Important Considerations**:
    - **Tight Coupling**: Game logic directly accesses and manipulates UI elements.
    - **Coordinate System**: Entire game is built on a 20x20 grid system.
    - **Single Responsibility Principle Violation**: `Form1` class manages interface, holds game state, and runs all game logic.

## Project Rules

- **Standards to Follow**: Must adhere to project's existing structure. New game objects should be created as `Panel`s, game logic should remain tied to `timer1_Tick` event.
- **Unchangeable Parts**: Core architectural decisions like using `timer1` as game loop and representing snake as `List<Panel>`.
- **Flexible Parts**: Scoring system, apple/obstacle count, colors, game speed parameters.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.