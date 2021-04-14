## Array.ValueType.ArrayValueTypeContains

### Source
[ArrayValueTypeContains.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeContains.cs)

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
|              ForLoop | .NET 5 | .NET 5.0 |  1000 | 4.820 μs | 0.0160 μs | 0.0134 μs |  1.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 | 4.736 μs | 0.0225 μs | 0.0199 μs |  0.98 |      - |     - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |  1000 | 1.741 μs | 0.0054 μs | 0.0048 μs |  0.36 |      - |     - |     - |         - |
|           LinqFaster | .NET 5 | .NET 5.0 |  1000 | 1.871 μs | 0.0121 μs | 0.0101 μs |  0.39 |      - |     - |     - |         - |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 | 1.751 μs | 0.0065 μs | 0.0058 μs |  0.36 |      - |     - |     - |         - |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 | 3.710 μs | 0.0176 μs | 0.0156 μs |  0.77 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 | 4.019 μs | 0.0286 μs | 0.0239 μs |  0.83 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 | 1.748 μs | 0.0028 μs | 0.0024 μs |  0.36 |      - |     - |     - |         - |
|                      |        |          |       |          |           |           |       |        |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 | 5.356 μs | 0.0117 μs | 0.0103 μs |  1.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 | 5.022 μs | 0.0100 μs | 0.0088 μs |  0.94 |      - |     - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |  1000 | 1.869 μs | 0.0060 μs | 0.0056 μs |  0.35 |      - |     - |     - |         - |
|           LinqFaster | .NET 6 | .NET 6.0 |  1000 | 1.861 μs | 0.0078 μs | 0.0065 μs |  0.35 |      - |     - |     - |         - |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 | 1.870 μs | 0.0081 μs | 0.0068 μs |  0.35 |      - |     - |     - |         - |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 | 5.578 μs | 0.0246 μs | 0.0218 μs |  1.04 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 | 5.023 μs | 0.0113 μs | 0.0095 μs |  0.94 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 | 1.865 μs | 0.0084 μs | 0.0075 μs |  0.35 |      - |     - |     - |         - |
