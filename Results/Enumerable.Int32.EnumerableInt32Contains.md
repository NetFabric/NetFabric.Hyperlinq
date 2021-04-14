## Enumerable.Int32.EnumerableInt32Contains

### Source
[EnumerableInt32Contains.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Contains.cs)

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
|               Method |    Job |  Runtime | Count |     Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |---------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 | 4.767 μs | 0.0209 μs | 0.0185 μs |  1.00 | 0.0153 |     - |     - |      40 B |
|                 Linq | .NET 5 | .NET 5.0 |  1000 | 5.042 μs | 0.0189 μs | 0.0168 μs |  1.06 | 0.0153 |     - |     - |      40 B |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 | 6.118 μs | 0.0498 μs | 0.0442 μs |  1.28 | 0.0153 |     - |     - |      40 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 | 4.552 μs | 0.0273 μs | 0.0242 μs |  0.95 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 | 4.537 μs | 0.0269 μs | 0.0238 μs |  0.95 | 0.0153 |     - |     - |      40 B |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 | 5.433 μs | 0.0372 μs | 0.0310 μs |  1.14 | 0.0153 |     - |     - |      40 B |
|                      |        |          |       |          |           |           |       |        |       |       |           |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 | 2.153 μs | 0.0147 μs | 0.0138 μs |  1.00 | 0.0191 |     - |     - |      40 B |
|                 Linq | .NET 6 | .NET 6.0 |  1000 | 2.670 μs | 0.0144 μs | 0.0127 μs |  1.24 | 0.0191 |     - |     - |      40 B |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 | 3.579 μs | 0.0283 μs | 0.0250 μs |  1.66 | 0.0191 |     - |     - |      40 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 | 3.475 μs | 0.0177 μs | 0.0157 μs |  1.61 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 | 3.198 μs | 0.0120 μs | 0.0107 μs |  1.49 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 | 3.311 μs | 0.0236 μs | 0.0221 μs |  1.54 | 0.0191 |     - |     - |      40 B |
