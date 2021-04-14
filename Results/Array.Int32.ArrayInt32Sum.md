## Array.Int32.ArrayInt32Sum

### Source
[ArrayInt32Sum.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Sum.cs)

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
|               Method |    Job |  Runtime | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | .NET 5 | .NET 5.0 |  1000 |    526.84 ns |   1.724 ns |   1.612 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 |    529.24 ns |   2.358 ns |   2.206 ns |  1.00 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |  1000 |  4,523.19 ns |  36.466 ns |  32.326 ns |  8.58 |    0.07 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET 5 | .NET 5.0 |  1000 |    526.37 ns |   1.921 ns |   1.703 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|      LinqFaster_SIMD | .NET 5 | .NET 5.0 |  1000 |     56.62 ns |   0.358 ns |   0.317 ns |  0.11 |    0.00 |      - |     - |     - |         - |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 |  1,917.01 ns |   5.215 ns |   4.623 ns |  3.64 |    0.02 |      - |     - |     - |         - |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 21,324.38 ns | 232.796 ns | 258.753 ns | 40.56 |    0.49 | 7.7209 |     - |     - |  16,147 B |
|              Streams | .NET 5 | .NET 5.0 |  1000 |  1,504.85 ns |   5.538 ns |   4.625 ns |  2.86 |    0.01 | 0.0992 |     - |     - |     208 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 |    687.76 ns |   5.179 ns |   4.325 ns |  1.31 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |    601.10 ns |   2.141 ns |   1.898 ns |  1.14 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 |     85.63 ns |   0.367 ns |   0.734 ns |  0.16 |    0.00 |      - |     - |     - |         - |
|                      |        |          |       |              |            |            |       |         |        |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 |    407.34 ns |   3.078 ns |   2.570 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 |    403.87 ns |   1.849 ns |   1.730 ns |  0.99 |    0.01 |      - |     - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |  1000 |  1,581.01 ns |  15.479 ns |  13.722 ns |  3.88 |    0.03 | 0.0153 |     - |     - |      32 B |
|           LinqFaster | .NET 6 | .NET 6.0 |  1000 |    451.67 ns |   2.026 ns |   1.796 ns |  1.11 |    0.01 |      - |     - |     - |         - |
|      LinqFaster_SIMD | .NET 6 | .NET 6.0 |  1000 |     53.93 ns |   0.411 ns |   0.364 ns |  0.13 |    0.00 |      - |     - |     - |         - |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 |  1,908.78 ns |   8.795 ns |   7.344 ns |  4.69 |    0.04 |      - |     - |     - |         - |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 21,160.51 ns | 193.686 ns | 181.174 ns | 51.91 |    0.55 | 7.6904 |     - |     - |  16,103 B |
|              Streams | .NET 6 | .NET 6.0 |  1000 |  1,440.59 ns |   3.043 ns |   2.846 ns |  3.54 |    0.03 | 0.0992 |     - |     - |     208 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |    690.91 ns |   3.462 ns |   3.239 ns |  1.70 |    0.02 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |    594.36 ns |   1.976 ns |   1.752 ns |  1.46 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 |     82.02 ns |   0.309 ns |   0.258 ns |  0.20 |    0.00 |      - |     - |     - |         - |
