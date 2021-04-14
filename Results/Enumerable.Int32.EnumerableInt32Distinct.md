## Enumerable.Int32.EnumerableInt32Distinct

### Source
[EnumerableInt32Distinct.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32Distinct.cs)

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
|               Method |    Job |  Runtime | Count |     Mean |    Error |   StdDev |   Median | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |---------:|---------:|---------:|---------:|------:|--------:|--------:|------:|------:|----------:|
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 | 19.79 μs | 0.396 μs | 1.141 μs | 19.12 μs |  1.00 |    0.00 | 27.7710 |     - |     - |  58,712 B |
|                 Linq | .NET 5 | .NET 5.0 |  1000 | 26.83 μs | 0.359 μs | 0.319 μs | 26.74 μs |  1.29 |    0.07 | 15.7776 |     - |     - |  33,112 B |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 | 30.62 μs | 0.229 μs | 0.203 μs | 30.66 μs |  1.48 |    0.08 | 19.5923 |     - |     - |  41,224 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 | 19.08 μs | 0.122 μs | 0.102 μs | 19.08 μs |  0.92 |    0.05 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 | 19.32 μs | 0.085 μs | 0.066 μs | 19.32 μs |  0.94 |    0.05 |       - |     - |     - |      40 B |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 | 16.67 μs | 0.098 μs | 0.086 μs | 16.68 μs |  0.80 |    0.04 |       - |     - |     - |      40 B |
|                      |        |          |       |          |          |          |          |       |         |         |       |       |           |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 | 17.42 μs | 0.206 μs | 0.182 μs | 17.37 μs |  1.00 |    0.00 | 27.7710 |     - |     - |  58,704 B |
|                 Linq | .NET 6 | .NET 6.0 |  1000 | 20.00 μs | 0.171 μs | 0.160 μs | 20.01 μs |  1.15 |    0.01 | 27.7710 |     - |     - |  58,664 B |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 | 29.48 μs | 0.211 μs | 0.187 μs | 29.41 μs |  1.69 |    0.02 | 19.5923 |     - |     - |  41,224 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 | 16.63 μs | 0.138 μs | 0.129 μs | 16.60 μs |  0.96 |    0.01 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 | 16.53 μs | 0.254 μs | 0.225 μs | 16.40 μs |  0.95 |    0.02 |       - |     - |     - |      40 B |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 | 13.81 μs | 0.049 μs | 0.043 μs | 13.80 μs |  0.79 |    0.01 |  0.0153 |     - |     - |      40 B |
