#!/bin/sh
mkdir -p ./build/make
cd ./build/make
cmake ../.. -G"Unix Makefiles" -DCMAKE_BUILD_TYPE=Release
cmake --build .
