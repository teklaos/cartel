namespace ConsoleApp.Abstractions.Interfaces;

public interface IDealer {
    public string? Territory { get; }
    public IList<string>? CriminalRecord { get; }
}