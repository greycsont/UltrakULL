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
        return Branch(Name,
            Leaf("migrate", () =>
            {
                var result = LegacyLanguageMigrator.Migrate();
                Log.Info($"Migrated {result.MigratedLanguages} legacy language package(s).");
                foreach (string warning in result.Warnings)
                    Log.Warning(warning);
                if (result.SkippedLanguages > 0)
                    Log.Warning($"Skipped {result.SkippedLanguages} language package(s). See messages above.");
                if (result.MigratedLanguages > 0)
                    Log.Info($"A copy of every migrated file was kept in \"{result.BackupDirectory}\".");
                Log.Info("Restart the game before editing or removing the backup.");
            }));
    }

    public Logger Log { get; } = new Logger("ultrakull");
}


