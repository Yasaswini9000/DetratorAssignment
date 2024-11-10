# Root Folder Monitor

This project restricts users from copying and pasting files from a specific "root" folder to any location outside of it. The system monitors clipboard activity and file system operations to enforce this restriction.

## Prerequisites

- Windows 11
- .NET Framework (C#)

## Setup

1. Clone this repository.
2. Open the solution in Visual Studio.
3. Replace the `rootFolder` path in `Program.cs` with your target folder.
4. Build and run the application.

## How It Works

- **Clipboard Monitoring**: The application listens for clipboard changes. If a user copies a file from the root folder and tries to paste it outside, the clipboard is cleared.
- **File System Monitoring**: The application monitors file operations in the root folder. If an attempt to paste a file outside of the root folder is detected, the action is blocked (you can customize this further).

## Running the Application

- Once started, the application runs in the background, monitoring clipboard and file system events.
- If a restricted operation is detected, a message will be shown, and the clipboard will be cleared.

