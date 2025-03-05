using System.Runtime.InteropServices;

namespace Devantler.CiliumCLI.Tests.CiliumTests;

/// <summary>
/// Tests for the RunAsync method.
/// </summary>
public class RunAsyncTests
{
  /// <summary>
  /// Tests that the binary can return the version of the cilium CLI command.
  /// </summary>
  /// <returns></returns>
  [Fact]
  public async Task RunAsync_Version_ReturnsVersion()
  {
    //TODO: Support MacOS and Windows, when dind is supported in GitHub Actions Runners on those platforms
    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
    {
      return;
    }

    // Act
    var (exitCode, output) = await Cilium.RunAsync(["version", "--client"]);

    // Assert
    Assert.Equal(0, exitCode);
    // Client Version: v1.32.0
    Assert.Matches(@"^cilium-cli: v\d+\.\d+\.\d+", output.Split("\n").First());
  }
}
