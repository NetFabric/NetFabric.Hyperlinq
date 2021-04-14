## Enumerable.Int32.EnumerableInt32WhereSelect

### Source
[EnumerableInt32WhereSelect.cs](../LinqBenchmarks/Enumerable/Int32/EnumerableInt32WhereSelect.cs)

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
|               Method |    Job |  Runtime | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |----------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 |  4.671 μs | 0.0245 μs | 0.0229 μs |  1.00 |    0.00 |  0.0153 |     - |     - |      40 B |
|                 Linq | .NET 5 | .NET 5.0 |  1000 |  9.021 μs | 0.0623 μs | 0.0552 μs |  1.93 |    0.01 |  0.0763 |     - |     - |     160 B |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 |  8.074 μs | 0.0586 μs | 0.0489 μs |  1.73 |    0.02 |  0.0153 |     - |     - |      40 B |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 61.272 μs | 0.5395 μs | 0.4782 μs | 13.11 |    0.12 | 15.7471 |     - |     - |  33,159 B |
|              Streams | .NET 5 | .NET 5.0 |  1000 | 15.235 μs | 0.1027 μs | 0.0858 μs |  3.26 |    0.03 |  0.3357 |     - |     - |     744 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 |  7.403 μs | 0.0393 μs | 0.0348 μs |  1.58 |    0.01 |  0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  5.509 μs | 0.0267 μs | 0.0223 μs |  1.18 |    0.01 |  0.0153 |     - |     - |      40 B |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 |  6.890 μs | 0.0279 μs | 0.0247 μs |  1.47 |    0.01 |  0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  5.607 μs | 0.0337 μs | 0.0315 μs |  1.20 |    0.01 |  0.0153 |     - |     - |      40 B |
|                      |        |          |       |           |           |           |       |         |         |       |       |           |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 |  2.914 μs | 0.0170 μs | 0.0151 μs |  1.00 |    0.00 |  0.0191 |     - |     - |      40 B |
|                 Linq | .NET 6 | .NET 6.0 |  1000 |  5.858 μs | 0.0431 μs | 0.0336 μs |  2.01 |    0.01 |  0.0763 |     - |     - |     160 B |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 |  5.339 μs | 0.0334 μs | 0.0312 μs |  1.83 |    0.02 |  0.0153 |     - |     - |      40 B |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 54.677 μs | 0.4512 μs | 0.4000 μs | 18.76 |    0.16 | 15.6250 |     - |     - |  32,708 B |
|              Streams | .NET 6 | .NET 6.0 |  1000 | 11.587 μs | 0.0699 μs | 0.0584 μs |  3.98 |    0.02 |  0.3510 |     - |     - |     744 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |  4.684 μs | 0.0205 μs | 0.0182 μs |  1.61 |    0.01 |  0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  3.321 μs | 0.0175 μs | 0.0164 μs |  1.14 |    0.01 |  0.0191 |     - |     - |      40 B |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 |  4.499 μs | 0.0184 μs | 0.0163 μs |  1.54 |    0.01 |  0.0153 |     - |     - |      40 B |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  3.212 μs | 0.0114 μs | 0.0107 μs |  1.10 |    0.01 |  0.0191 |     - |     - |      40 B |
