# cpp-unity-example
Example for building a C++ plugin for Unity using CMake

You can use the appropriate build script to easily build the library:
- `build_make.sh` for Linux using Makefiles
- `build_vs.bat` for Windows using Visual Studio 2019
- `build_xcode.sh` for macOS using Xcode

The resulting library file needs to be copied to the `unity/Assets` directory. Note: Unity keeps a lock on the lib after the first run. You may have to close Unity if you want to update the lib.
