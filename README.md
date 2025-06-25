## Overview
This marker-based AR app brings static images to life by detecting custom markers in the real world and spawning 3D content on top of them. Built with Unity’s AR Foundation and the ARCore XR Plugin, the app recognizes four distinct image targets—two tutorial markers plus a Pokémon card and a Paris postcard—and instantiates the matching prefab (a Pokémon character or the Eiffel Tower) at the marker’s exact position and orientation. Dynamic activation and deactivation ensure only the currently tracked content is visible, while real-time pose updates let you walk around and inspect each model from any angle. Tested on a Samsung Galaxy S7, the application gracefully handles permissions, marker loss, and build-time configuration issues to deliver a smooth AR experience.

## Various Interactions
- **Marker Recognition** – ARTrackedImageManager detects and differentiates four image targets at runtime.  
- **Prefab Instantiation** – Automatically spawns the corresponding 3D model when its marker enters the camera view.  
- **Real-Time Pose Anchoring** – Updates each prefab’s position and rotation to match the marker’s transform continuously.  
- **Dynamic Activation/Deactivation** – Activates the prefab on detection and hides it as soon as the marker is lost.  
- **Multi-Marker Support** – Simultaneously tracks multiple images and switches active content based on which marker is visible.  
- **Model Scaling** – Prefabs are pre-scaled to align with the physical size of each printed marker.  
- **User Movement** – Physically move around the marker to view the model from different angles, leveraging natural device motion.  
- **Permission Handling** – Requests camera access on first launch and gracefully recovers if permissions are denied.  
- **Configuration Recovery** – Detects and remedies common setup issues (e.g., enabling ARCore plugin, reference image library assignments) during development.  
- **Demo Recording** – Easily capture on-device video showcasing marker detection and model instantiation for presentations or reports.  
```
