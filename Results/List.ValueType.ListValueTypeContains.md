## List.ValueType.ListValueTypeContains

### Source
[ListValueTypeContains.cs](../LinqBenchmarks/List/ValueType/ListValueTypeContains.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [](https://www.nuget.org/packages/LinqOptimizer.CSharp/)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.3.21202.5
  [Host] : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 5 : .NET 5.0.3 (5.0.321.7212), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.20104), X64 RyuJIT

EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  

```
|               Method |    Job |  Runtime | Count |     Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |---------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | .NET 5 | .NET 5.0 |  1000 | 6.595 μs | 0.0420 μs | 0.0351 μs |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 | 8.529 μs | 0.1674 μs | 0.2703 μs |  1.30 |    0.04 |      - |     - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |  1000 | 1.747 μs | 0.0059 μs | 0.0052 μs |  0.26 |    0.00 |      - |     - |     - |         - |
|           LinqFaster | .NET 5 | .NET 5.0 |  1000 | 1.872 μs | 0.0092 μs | 0.0082 μs |  0.28 |    0.00 |      - |     - |     - |         - |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 | 1.858 μs | 0.0061 μs | 0.0054 μs |  0.28 |    0.00 |      - |     - |     - |         - |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 | 4.029 μs | 0.0269 μs | 0.0210 μs |  0.61 |    0.01 | 0.0153 |     - |     - |      40 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 | 4.229 μs | 0.0172 μs | 0.0161 μs |  0.64 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 | 1.772 μs | 0.0064 μs | 0.0054 μs |  0.27 |    0.00 |      - |     - |     - |         - |
|                      |        |          |       |          |           |           |       |         |        |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 | 6.536 μs | 0.0261 μs | 0.0232 μs |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 | 8.255 μs | 0.1646 μs | 0.3681 μs |  1.22 |    0.04 |      - |     - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |  1000 | 1.858 μs | 0.0059 μs | 0.0049 μs |  0.28 |    0.00 |      - |     - |     - |         - |
|           LinqFaster | .NET 6 | .NET 6.0 |  1000 | 1.873 μs | 0.0134 μs | 0.0126 μs |  0.29 |    0.00 |      - |     - |     - |         - |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 | 1.866 μs | 0.0068 μs | 0.0057 μs |  0.29 |    0.00 |      - |     - |     - |         - |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 | 5.280 μs | 0.0178 μs | 0.0158 μs |  0.81 |    0.00 | 0.0153 |     - |     - |      40 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 | 5.016 μs | 0.0535 μs | 0.0475 μs |  0.77 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 | 1.867 μs | 0.0085 μs | 0.0071 μs |  0.29 |    0.00 |      - |     - |     - |         - |
