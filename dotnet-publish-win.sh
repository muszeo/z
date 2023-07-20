#!/bin/bash

export SRC=./z
export APP=/z
export PUB_WIN_APP=publish-win

clear

cd "$SRC$APP"
echo "***************************************************************"
echo ""
echo " > > Directory: "$SRC$APP
echo ""
echo "***************************************************************"

ls

echo "***************************************************************"
echo " > > Publishing Application for Microsoft Windows x64..."
echo "***************************************************************"
dotnet publish -r win10-x64 -c Release -o $PUB_WIN_APP -p:IncludeNativeLibrariesForSelfExtract=true -p:IncludeNativeLibrariesInSingleFile=true --self-contained true

cd "$PUB_WIN_APP"
rm *.pdb
rm *.DS_Store