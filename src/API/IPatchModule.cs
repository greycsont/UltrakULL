namespace UltrakULL.API;

public interface IPatchModule
{
    string Name { get; }

    void PatchAll();

    void UnpatchAll();
}
