#!/bin/sh
echo -ne '\033c\033]0;Brackeys tutorial\a'
base_path="$(dirname "$(realpath "$0")")"
"$base_path/Brackeys tutorial.x86_64" "$@"
