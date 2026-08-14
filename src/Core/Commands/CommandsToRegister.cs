using GameConsole;
using GameConsole.CommandTree;
using plog;

namespace UltrakULL;

public sealed class CommandToRegister : CommandRoot, IConsoleLogger
{
    public CommandToRegister(Console con) : base(con)
    {
    }

    public override string Name => "ultrakull";
    public override string Description => "tons of setting";

    public override Branch BuildTree(Console con)
    {
        return Branch(Name);
    }

    public Logger Log { get; } = new Logger("ultrakull");
}


