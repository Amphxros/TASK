# **TASK**: Tool Assisted Superplay by Keycodes

TASK is a tool for testing the input of any game made in Unity,

### How to use

For the code that needs playback Input values needs methods via TASKManager rather than the unity Input:
Instead of "Input.GetButtonDown("key")" use myTASKManager.GetButtonDown("key") that's because we overrided the unity input system for being able to generate events based on time.

### TASKManager
This is the main class or core of the tool, think of it as a VHS player or an animation timeline.
The inputs that are recorded should be added in the inspector (buttons, axes, keys list ...) Mouse inputs (position and buttons states) can be recorded too if the bool is activated.

To start recording call Record or Record new. While recording the input values are saved to a Recording object each frame. If you want to save additional properties, call **SaveProperty()**, with a key and a string value.

For stopping the recording call **Stop()** or **Rewind()**

To start playing back a recording call **Play()** if there's no recording the last used recording will be used

### Recording

This is the VHS tape. It holds the recorded input values for each frame for the length of the recording. You shouldn't need to call any methods on this directly, although the Length property (in seconds) might be useful. This object can be passed around to be played back in other projects, or saved for later. If you want to save a Recording when playback ends, it must first be Serialized so it can be saved to disk. Call .ToJson() to get a json string. The TASKManager class also provides utility methods to save/load the current recording to and from disk

### InputTASKTextRecordingLoader
This is a helper class to automatically load and optionally start playing a Recording saved in Json form.

### InputTASKTransformSyncer
Helper to save the transform state of an object and to sync up. This is to prevent the drifts of GameObjects due to different frame times or physics

### KeycodeHelper
It's literally a switch with every input possible (except touch events) that returns a string with a identity.
