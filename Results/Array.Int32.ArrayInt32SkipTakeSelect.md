## Array.Int32.ArrayInt32SkipTakeSelect

### Source
[ArrayInt32SkipTakeSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta26](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta26)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=macOS Catalina 10.15.6 (19G73) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Skip | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |    63.13 ns |  0.083 ns |  0.073 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 2,980.01 ns | 20.284 ns | 18.974 ns | 47.16 |    0.27 | 0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |   100 | 1,250.32 ns |  2.294 ns |  1.916 ns | 19.81 |    0.03 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |   100 |   404.30 ns |  0.778 ns |  0.649 ns |  6.40 |    0.01 | 0.6080 |     - |     - |    1272 B |
|               LinqAF | 1000 |   100 | 3,060.73 ns |  4.900 ns |  4.583 ns | 48.48 |    0.09 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 | 1,236.80 ns |  1.295 ns |  1.081 ns | 19.59 |    0.03 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |   100 | 1,069.93 ns |  2.978 ns |  2.487 ns | 16.95 |    0.04 | 0.0458 |     - |     - |      96 B |
|    Hyperlinq_Foreach | 1000 |   100 |   271.26 ns |  0.767 ns |  0.717 ns |  4.30 |    0.01 |      - |     - |     - |         - |
|        Hyperlinq_For | 1000 |   100 |   273.48 ns |  0.385 ns |  0.322 ns |  4.33 |    0.01 |      - |     - |     - |         - |
