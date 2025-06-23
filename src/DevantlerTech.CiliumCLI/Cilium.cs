using CliWrap;
using CliWrap.Buffered;

namespace DevantlerTech.CiliumCLI;

/// <summary>
/// A class to run Cilium CLI commands.
/// </summary>
public static class Cilium
{
  /// <summary>
  /// The Cilium CLI command.
  /// </summary>
  public static Command Command
  {
    get
    {
      string binaryName = "cilium";
      string? pathEnv = Environment.GetEnvironmentVariable("PATH");

      if (!string.IsNullOrEmpty(pathEnv))
      {
        string[] paths = pathEnv.Split(Path.PathSeparator);
        foreach (string dir in paths)
        {
          string fullPath = Path.Combine(dir, binaryName);
          if (File.Exists(fullPath))
          {
            return Cli.Wrap(fullPath);
          }
        }
      }

      throw new FileNotFoundException($"The '{binaryName}' CLI was not found in PATH.");
    }
  }

  /// <summary>
  /// Runs the cilium CLI command with the given arguments.
  /// </summary>
  /// <param name="arguments"></param>
  /// <param name="validation"></param>
  /// <param name="input"></param>
  /// <param name="silent"></param>
  /// <param name="cancellationToken"></param>
  /// <returns></returns>
  public static async Task<(int ExitCode, string Message)> RunAsync(
    string[] arguments,
    CommandResultValidation validation = CommandResultValidation.ZeroExitCode,
    bool input = false,
    bool silent = false,
    CancellationToken cancellationToken = default)
  {
    using var stdInConsole = input ? Stream.Null : Console.OpenStandardInput();
    using var stdOutConsole = silent ? Stream.Null : Console.OpenStandardOutput();
    using var stdErrConsole = silent ? Stream.Null : Console.OpenStandardError();
    var command = Command.WithArguments(arguments)
      .WithValidation(validation)
      .WithStandardInputPipe(PipeSource.FromStream(stdInConsole))
      .WithStandardOutputPipe(PipeTarget.ToStream(stdOutConsole))
      .WithStandardErrorPipe(PipeTarget.ToStream(stdErrConsole));
    var result = await command.ExecuteBufferedAsync(cancellationToken);
    return (result.ExitCode, result.StandardOutput.ToString() + result.StandardError.ToString());
  }
}
