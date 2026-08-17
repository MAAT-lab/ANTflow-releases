# ANTflow

Agentic Nodal Transfer Flow

Description:
Visual workflow AI automation framework for Grasshopper. It empowers designers to orchestrate generative AI services, external APIs, and data pipelines directly on the GH canvas, merging AI loops with parametric geometry. 


## Features: 
1. Asynchronous
2. Persistent memory for continuous conversations and outputs
3. "Permanent memory" implementation through TXT file
4. Media captures:
   - Viewport 
   - webcam 
6. Interactions:
   - LLM
   - text to image
   - image to image
   - Text to speech (TTS)
5. Current services:
   - ChatGPT
   - Gemini
   - DeepSeek
   - Nano Banana
   - OpenAI image


____________________________________________________________________

## Troubleshooting

### Deleting ANTflow to reinstall
To delete the plugin installed through by dragging and dropping a YAK file to the Rhino viewport, use the package manager:
- Open the package manager by typing "PackageManager" in the command line
- Search for "ANTflow"
- Hit "Uninstall"
- Restart Rhino
 
### To delete the plugin manually:
- Go to the following folder in Windows: %APPDATA%\McNeel\Rhinoceros\packages\
- Look for the folder called "ANTflow"
- Delete all contents within that folder

### Corrupted environment
If components show message that environment is corrupted:
- Type "ScriptEditor" into the command line
- Go to the "Tools" menu
- Hit "Reload Python 3..."
- Restart Rhino once reloaded
- If Tools menu contents are grayed out, create a Python file to get the UI going
   - Go to the "File" menu
   - Click on "New"
   - Select "New Python 3"
   - Go to "Tools" again and check if the menu contents are still grayed out
