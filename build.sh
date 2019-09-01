#!/bin/bash

OUTDIR="$PWD/Bin"
WINDIR="$OUTDIR/Windows"
OSXDIR="$OUTDIR/OS X"
LINUXDIR="$OUTDIR/Linux"

# Is Self Contained..?
IsSC=false

# Colors
RED='\033[0;31m'
GREEN='\033[0;32m'
BLUE='\033[0;34m'
NC='\033[0m' # No Color

set -e
trap 'echo -e "${RED}-------------------------\nBuild Failed\n-------------------------${NC}"' ERR

if [ -d "$OUTDIR" ]; then
    echo -e "${RED} - Cleaning Old Output Files${NC}"
    rm -rf "$OUTDIR"
fi

for file in $(find "$PWD" -name '*.csproj'); do
    filename=$(basename "$file")
    echo -e "${GREEN} - Found Project ${filename}${NC}"
    echo -e "${BLUE}   Building for Windows${NC}"
    dotnet publish -r win-x86 -c Release --self-contained $IsSC -o "$WINDIR/x86" "$file" 2>&1 > /dev/null
    dotnet publish -r win-x64 -c Release --self-contained $IsSC -o "$WINDIR/x64" "$file" 2>&1 > /dev/null
    echo -e "${BLUE}   Building for Linux x64${NC}"
    dotnet publish -r linux-x64 -c Release --self-contained $IsSC -o "$LINUXDIR" "$file" 2>&1 > /dev/null
    echo -e "${BLUE}   Building for OS X 10.10 x64${NC}"
    dotnet publish -r osx.10.10-x64 -c Release --self-contained $IsSC -o "$OSXDIR" "$file" 2>&1 > /dev/null
done

echo -e "${GREEN} - Build completed successfully.${NC}"
