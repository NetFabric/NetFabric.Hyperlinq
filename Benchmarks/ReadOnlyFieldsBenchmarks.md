## ReadOnlyFieldsBenchmarks

### Source
[ReadOnlyFieldsBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ReadOnlyFieldsBenchmarks.cs)

### References:
- Linq: 6.0.0-preview.5.21301.5
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.13.0.1555-nightly, OS=Windows 10.0.19043.1055 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.5.21302.13
  [Host]     : .NET 6.0.0 (6.0.21.30105), X64 RyuJIT
  Job-UNTOJZ : .NET 6.0.0 (6.0.21.30105), X64 RyuJIT

Runtime=.NET 6.0  

```
|          Method | Count |     Mean |   Error |  StdDev | Ratio | Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |------ |---------:|--------:|--------:|------:|------:|------:|------:|----------:|
|        Baseline |  1000 | 545.7 ns | 1.41 ns | 1.25 ns |  1.00 |     - |     - |     - |         - |
| ReadOnlyCurrent |  1000 | 545.6 ns | 1.20 ns | 1.12 ns |  1.00 |     - |     - |     - |         - |
|   ReadOnlyField |  1000 | 545.9 ns | 1.41 ns | 1.32 ns |  1.00 |     - |     - |     - |         - |
