# 🥁 Drum Repertoire Assistant

![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white) ![.NET](https://img.shields.io/badge/.NET-5C2D91.svg?style=for-the-badge&logo=dotnet&logoColor=white) ![Console](https://img.shields.io/badge/Console-App-black?style=for-the-badge)

A robust and efficient C# console application built to help drummers manage, filter, and organize their repertoire. Designed with data integrity and fault tolerance in mind.

## ✨ Motivation
When preparing for drum sessions or tutoring students, managing tracks by tempo (BPM) and difficulty becomes challenging. I built this tool to solve that real-world problem, transitioning from volatile memory storage to persistent local databases while ensuring the application remains crash-resistant.

## 🚀 Key Features

*   💾 **Persistent Data (File I/O):** Automatically saves your repertoire to `repertuvar.txt`. Your data is always safely loaded when the application starts.
*   🛡️ **Fault Tolerance & Validation:** Implements `TryParse` and data-structure checks. If the local `.txt` file is manually corrupted or tampered with, the program safely skips the corrupted lines without crashing.
*   🔍 **Smart Search Engine:** Case-insensitive search using `ToLower()` and `Contains()`. Finding a song by a partial name is seamless.
*   🎛️ **BPM Filtering:** Instantly lists tracks above a targeted tempo threshold for focused practice sessions.
*   🔄 **Parallel Data Management:** Safely synchronizes track names, BPM values, and difficulty tiers across parallel lists.

## 💻 Tech Stack & Concepts

*   **Language:** C# (.NET)
*   **Core Concepts:** File I/O (`System.IO`), String Manipulation, Exception Handling Strategy, Null-Coalescing Operators (`??`), Control Flow.

## ⚙️ How to Run

1. Make sure you have the .NET SDK installed.
2. Clone this repository:
   ```bash
   git clone [https://github.com/YOUR-USERNAME/drum-repertoire-assistant.git](https://github.com/YOUR-USERNAME/drum-repertoire-assistant.git)
