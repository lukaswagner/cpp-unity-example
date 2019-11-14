mkdir .\build\vs
cd .\build\vs
cmake ..\.. -G"Visual Studio 15 2017 Win64"
cmake --build . --config Release
