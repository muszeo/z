#!/bin/bash

#
# Absolute Paths
#
export SRC=/Users/muszeo/Development/martin/z

#
# Relative Paths
#
export APP=/z
export PUB_LINUX_APP=publish-linux
export PUB_MACOS_APP=publish-macos

clear

#
# Application: Windows
#
cd "$SRC$APP"
echo "***************************************************************"
echo ""
echo " > > Directory: "$SRC$APP
echo ""
echo "***************************************************************"
ls
echo "***************************************************************"
echo " > > Publishing Application for Mac OS x64..."
echo "***************************************************************"
dotnet publish -r osx.10.11-x64 -c Release -o $PUB_MACOS_APP -p:IncludeNativeLibrariesForSelfExtract=true -p:IncludeNativeLibrariesInSingleFile=true --self-contained true
echo "***************************************************************"
echo " > > Publishing Application for Linux..."
echo "***************************************************************"
dotnet publish -r linux-x64 -c Release -o $PUB_LINUX_APP -p:IncludeNativeLibrariesForSelfExtract=true -p:IncludeNativeLibrariesInSingleFile=true --self-contained true
cd "$SRC$APP/$PUB_LINUX_APP"
rm *.pdb
rm *.DS_Store
cd "$SRC$APP/$PUB_MACOS_APP"
rm *.pdb
rm *.DS_Store