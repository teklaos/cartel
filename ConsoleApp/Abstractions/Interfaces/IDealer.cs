namespace ConsoleApp.Abstractions.Interfaces;

public interface IDealer
{
    string Territory { get; }
    IList<string> CriminalRecord { get; }
}