# Reconstructing the Unity examples

This repository contains script extracts, not complete Unity projects. Scenes,
prefabs, original art/audio and project metadata were not included. Use a new
Unity 3D project as a reconstruction workspace; do not claim it is the original
submitted game. Run `python tools/check_repository.py` for metadata, privacy and
MonoBehaviour class/filename checks. No Unity editor or gameplay test runs in CI.

For trench-run, install the Input System package matching the generated source
(1.14.0), enable it in Player Settings, and import GameInputActions.inputactions.
That asset was recovered from the exact embedded JSON in the existing generated
GameInputActions.cs, retaining its original bindings. Keep the existing generated
class or regenerate the same class name, not both. Attach PlayerController,
PlayerLooper and CameraFollow to appropriate objects and assign the serialized
prefab/player references in ObstacleSpawner. Obstacle.cs now matches its public
MonoBehaviour class so Unity can attach it correctly.

For procedural-grid, attach GridGenerator to an empty object and assign its
prefab and grid dimensions in the inspector. For ghost-treasure-hunt, create a
Player-tagged player, wire FirstPersonController movement/look inputs and camera,
and assign GameManager/Treasure/GhostAI dependencies. FollowPlayer.cs now matches
its component class. Use your own or appropriately licensed art/audio and inspect
every serialized field before play mode. These are setup steps; they do not
substitute for missing original scenes or verify game balance and collisions.
