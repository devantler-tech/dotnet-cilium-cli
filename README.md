# 🕸️ .NET Cilium CLI

[![License](https://img.shields.io/badge/License-Apache_2.0-blue.svg)](https://opensource.org/licenses/Apache-2.0)
[![Test](https://github.com/devantler-tech/dotnet-cilium-cli/actions/workflows/test.yaml/badge.svg)](https://github.com/devantler-tech/dotnet-cilium-cli/actions/workflows/test.yaml)
[![codecov](https://codecov.io/gh/devantler-tech/dotnet-cilium-cli/graph/badge.svg?token=RhQPb4fE7z)](https://codecov.io/gh/devantler-tech/dotnet-cilium-cli)

A simple .NET library that embeds the Cilium CLI.

## 🚀 Getting Started

### Prerequisites

- .NET 9.0 or later
- [Cilium CLI](https://docs.cilium.io/en/stable/gettingstarted/k8s-install-default/#install-the-cilium-cli) installed and available in your system's PATH

### Installation

To get started, you can install the package from NuGet.

```bash
dotnet add package DevantlerTech.CiliumCLI
```

## 📝 Usage

You can execute the Cilium CLI commands using the `Cilium` class.

```csharp
using DevantlerTech.CiliumCLI;

var (exitCode, output) = await Cilium.RunAsync(["arg1", "arg2"]);
```
