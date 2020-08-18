## Array.Int32.ArrayInt32SkipTakeWhere

### Source
[ArrayInt32SkipTakeWhere.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeWhere.cs)

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
|               Method | Skip | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |   104.3 ns |  0.14 ns |  0.11 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 3,114.0 ns | 20.14 ns | 16.81 ns | 29.85 |    0.16 | 0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |   100 | 1,503.8 ns |  5.36 ns |  5.02 ns | 14.42 |    0.05 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |   100 |   427.4 ns |  5.55 ns |  4.64 ns |  4.09 |    0.04 | 0.7153 |     - |     - |    1496 B |
|               LinqAF | 1000 |   100 | 3,059.6 ns |  4.65 ns |  4.12 ns | 29.33 |    0.05 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 | 1,362.6 ns | 25.09 ns | 23.47 ns | 13.11 |    0.22 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |   100 | 1,158.3 ns |  2.87 ns |  2.39 ns | 11.10 |    0.03 | 0.0458 |     - |     - |      96 B |
|            Hyperlinq | 1000 |   100 |   357.2 ns |  0.61 ns |  0.54 ns |  3.42 |    0.01 |      - |     - |     - |         - |
