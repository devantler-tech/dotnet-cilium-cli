#!/bin/bash
set -e

get() {
  local url=$1
  local binary=$2
  local target_dir=$3
  local target_name=$4
  local archiveType=$5

  echo "Downloading $target_name from $url"
  if [ "$archiveType" = "tar" ]; then
    curl -LJ "$url" | tar xvz -C "$target_dir" "$binary"
    mv "$target_dir/$binary" "${target_dir}/$target_name"
  elif [ "$archiveType" = "zip" ]; then
    curl -LJ "$url" -o "$target_dir/$target_name.zip"
    unzip -o "$target_dir/$target_name.zip" -d "$target_dir"
    mv "$target_dir/$binary" "${target_dir}/$target_name"
    rm "$target_dir/$target_name.zip"
  elif [ "$archiveType" = false ]; then
    curl -LJ "$url" -o "$target_dir/$target_name"
  fi
  chmod +x "$target_dir/$target_name"
}

get "https://getbin.io/cilium/cilium-cli?os=darwin&arch=amd64" "cilium" "src/Devantler.CiliumCLI/runtimes/osx-x64/native" "cilium-osx-x64" "tar"
get "https://getbin.io/cilium/cilium-cli?os=darwin&arch=arm64" "cilium" "src/Devantler.CiliumCLI/runtimes/osx-arm64/native" "cilium-osx-arm64" "tar"
get "https://getbin.io/cilium/cilium-cli?os=linux&arch=amd64" "cilium" "src/Devantler.CiliumCLI/runtimes/linux-x64/native" "cilium-linux-x64" "tar"
get "https://getbin.io/cilium/cilium-cli?os=linux&arch=arm64" "cilium" "src/Devantler.CiliumCLI/runtimes/linux-arm64/native" "cilium-linux-arm64" "tar"
get "https://getbin.io/cilium/cilium-cli?os=windows&arch=amd64" "cilium.exe" "src/Devantler.CiliumCLI/runtimes/win-x64/native" "cilium-win-x64.exe" "zip"
get "https://getbin.io/cilium/cilium-cli?os=windows&arch=arm64" "cilium.exe" "src/Devantler.CiliumCLI/runtimes/win-arm64/native" "cilium-win-arm64.exe" "zip"
