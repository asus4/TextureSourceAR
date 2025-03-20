#!/bin/bash -e

# Switchs between Local and NPM in manifest.json

MANIFEST="Packages/manifest.json"

function print_usage() {
    echo "Usage: $0 <version> OR $0 local"
    echo "Example: $0 1.2.3"
    echo "Example: $0 local"
}

function switch_to_local() {
    sed -i '' 's|"'"$1"'": "[^"]*"|"'"$1"'": "file:../../TextureSource/Packages/'"$1"'"|' $MANIFEST
}

function switch_to_npm() {
    sed -i '' 's|"'"$1"'": "[^"]*"|"'"$1"'": "'"$2"'"|' $MANIFEST
}

# Validate input format
if [[ $1 =~ ^[0-9]+\.[0-9]+\.[0-9]+$ ]]; then
    switch_to_npm "com.github.asus4.texture-source" $1
elif [[ $1 == "local" ]]; then
    switch_to_local "com.github.asus4.texture-source"
else
    print_usage
    exit 1
fi

echo "Done."
exit 0
