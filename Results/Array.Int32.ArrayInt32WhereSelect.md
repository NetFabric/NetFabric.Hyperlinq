## Array.Int32.ArrayInt32WhereSelect

### Source
[ArrayInt32WhereSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelect.cs)

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
|               Method |    Job |  Runtime | Count |        Mean |     Error |      StdDev |  Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |------------:|----------:|------------:|-------:|--------:|--------:|------:|------:|----------:|
|              ForLoop | .NET 5 | .NET 5.0 |  1000 |    608.9 ns |   3.17 ns |     2.65 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 |    863.7 ns |   6.32 ns |     5.28 ns |   1.42 |    0.01 |       - |     - |     - |         - |
|                 Linq | .NET 5 | .NET 5.0 |  1000 |  8,174.2 ns |  39.15 ns |    34.70 ns |  13.43 |    0.08 |  0.0458 |     - |     - |     104 B |
|           LinqFaster | .NET 5 | .NET 5.0 |  1000 |  4,698.0 ns |  24.42 ns |    20.39 ns |   7.72 |    0.05 |  2.8915 |     - |     - |   6,064 B |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 |  6,452.9 ns |  26.85 ns |    23.80 ns |  10.60 |    0.06 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 64,053.2 ns | 307.51 ns |   272.60 ns | 105.17 |    0.48 | 15.1978 |     - |     - |  31,867 B |
|              Streams | .NET 5 | .NET 5.0 |  1000 | 15,725.8 ns |  68.21 ns |    60.46 ns |  25.84 |    0.13 |  0.3357 |     - |     - |     736 B |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 |  5,249.2 ns |  48.02 ns |    42.57 ns |   8.62 |    0.09 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  2,463.4 ns |  14.21 ns |    12.60 ns |   4.05 |    0.03 |       - |     - |     - |         - |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 |  5,550.2 ns |  28.20 ns |    26.38 ns |   9.11 |    0.05 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  2,122.2 ns |  14.86 ns |    13.90 ns |   3.49 |    0.03 |       - |     - |     - |         - |
|                      |        |          |       |             |           |             |        |         |         |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 |    824.0 ns |   6.30 ns |     5.89 ns |   1.00 |    0.00 |       - |     - |     - |         - |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 |    819.5 ns |   5.40 ns |     5.05 ns |   0.99 |    0.01 |       - |     - |     - |         - |
|                 Linq | .NET 6 | .NET 6.0 |  1000 |  6,705.9 ns |  32.05 ns |    26.76 ns |   8.14 |    0.06 |  0.0458 |     - |     - |     104 B |
|           LinqFaster | .NET 6 | .NET 6.0 |  1000 |  5,225.7 ns |  21.69 ns |    20.29 ns |   6.34 |    0.04 |  2.8915 |     - |     - |   6,064 B |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 |  6,514.5 ns |  29.05 ns |    24.26 ns |   7.91 |    0.07 |       - |     - |     - |         - |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 48,355.8 ns | 711.38 ns | 1,690.66 ns |  60.38 |    4.04 | 15.0757 |     - |     - |  31,608 B |
|              Streams | .NET 6 | .NET 6.0 |  1000 | 14,454.6 ns |  69.73 ns |    58.23 ns |  17.54 |    0.15 |  0.3510 |     - |     - |     736 B |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |  6,932.5 ns |  23.72 ns |    19.80 ns |   8.41 |    0.05 |  0.0305 |     - |     - |      64 B |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  3,426.3 ns |  11.33 ns |    10.60 ns |   4.16 |    0.04 |       - |     - |     - |         - |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 |  5,204.9 ns |  28.59 ns |    26.75 ns |   6.32 |    0.06 |       - |     - |     - |         - |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  4,263.2 ns |  14.14 ns |    13.22 ns |   5.17 |    0.04 |       - |     - |     - |         - |
