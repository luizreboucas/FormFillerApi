using System;

namespace FormFiller.Domain.Generators;

public interface IGen
{
    public string Name { get; }
    public List<string>? Params { get; }
    public string Generate();
}
