# advanced-tools-collision-eval

# Unity Collider Performance Evaluation

This project investigates how different Unity collider types affect performance as object count increases. It uses scripted test scenes to automatically spawn objects, log average FPS, and evaluate trends across multiple configurations. The goal is to understand the cost of each collider type and how static vs dynamic setup impacts performance.

## Project Overview

- Engine: **Unity 6000.0.35f1**
- Tested collider types: **Box, Sphere, Capsule, Mesh**
- Includes static vs dynamic test.
- Includes a full report with analysis, charts, and profiler data.

## How It Works

- `Spawner.cs`: Instantiates objects using the selected collider and static ratio.
- `Logger.cs`: Logs average FPS over 30 seconds to a CSV file for charting.
- Unity Profiler was used to capture CPU usage and collision overhead during each test.
- Trendlines and R² values were generated in Excel for performance curve analysis.

## Report

 See the full analysis on the Wiki section, including:
- Performance charts for each collider type
- Static vs dynamic performance comparison
- Profiler screenshots and CSV logs

## Credits

- [Low poly model](https://assetstore.unity.com/packages/3d/vegetation/trees/low-poly-tree-pack-57866) by Broken Vector
