#!/bin/sh
mkdir -p ./build/xcode
cd ./build/xcode
cmake ../.. -G"Xcode"
cmake --build . --config Release
