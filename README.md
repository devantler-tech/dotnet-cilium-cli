# 🕸️ .NET Cilium CLI

[![License](https://img.shields.io/badge/License-Apache_2.0-blue.svg)](https://opensource.org/licenses/Apache-2.0)
[![Test](https://github.com/devantler-tech/dotnet-cilium-cli/actions/workflows/test.yaml/badge.svg)](https://github.com/devantler-tech/dotnet-cilium-cli/actions/workflows/test.yaml)
[![codecov](https://codecov.io/gh/devantler-tech/dotnet-cilium-cli/graph/badge.svg?token=RhQPb4fE7z)](https://codecov.io/gh/devantler-tech/dotnet-cilium-cli)

<details>
  <summary>Show/hide folder structure</summary>

<!-- readme-tree start -->
```
.
├── .github
│   ├── scripts
│   └── workflows
├── src
│   └── Devantler.CiliumCLI
│       └── runtimes
│           ├── linux-arm64
│           │   └── native
│           ├── linux-x64
│           │   └── native
│           ├── osx-arm64
│           │   └── native
│           ├── osx-x64
│           │   └── native
│           ├── win-arm64
│           │   └── native
│           └── win-x64
│               └── native
└── tests
    └── Devantler.CiliumCLI.Tests
        └── CiliumTests

22 directories
```
<!-- readme-tree end -->

</details>

A simple .NET library that embeds the Cilium CLI.

## 🚀 Getting Started

To get started, you can install the package from NuGet.

```bash
dotnet add package Devantler.CiliumCLI
```

## 📝 Usage

You can execute the Cilium CLI commands using the `Cilium` class.

```csharp
using Devantler.CiliumCLI;

var (exitCode, output) = await Cilium.RunAsync(["arg1", "arg2"]);
```
