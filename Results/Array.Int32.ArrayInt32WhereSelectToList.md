## Array.Int32.ArrayInt32WhereSelectToList

### Source
[ArrayInt32WhereSelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToList.cs)

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
|               Method |    Job |  Runtime | Count |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |----------:|----------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|              ForLoop | .NET 5 | .NET 5.0 |  1000 |  2.846 μs | 0.0567 μs | 0.1325 μs |  2.756 μs |  1.00 |    0.00 |  2.0561 |     - |     - |      4 KB |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 |  2.905 μs | 0.0183 μs | 0.0171 μs |  2.908 μs |  1.02 |    0.04 |  2.0561 |     - |     - |      4 KB |
|                 Linq | .NET 5 | .NET 5.0 |  1000 |  5.414 μs | 0.0318 μs | 0.0265 μs |  5.410 μs |  1.91 |    0.07 |  2.1057 |     - |     - |      4 KB |
|           LinqFaster | .NET 5 | .NET 5.0 |  1000 |  5.408 μs | 0.1031 μs | 0.1059 μs |  5.431 μs |  1.88 |    0.07 |  3.8834 |     - |     - |      8 KB |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 |  7.900 μs | 0.0359 μs | 0.0300 μs |  7.895 μs |  2.78 |    0.10 |  2.0447 |     - |     - |      4 KB |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 52.923 μs | 0.4123 μs | 0.3443 μs | 52.846 μs | 18.64 |    0.64 | 16.5405 |     - |     - |     34 KB |
|              Streams | .NET 5 | .NET 5.0 |  1000 | 11.681 μs | 0.2311 μs | 0.2838 μs | 11.764 μs |  4.02 |    0.08 |  2.3041 |     - |     - |      5 KB |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 |  5.840 μs | 0.0284 μs | 0.0252 μs |  5.847 μs |  2.05 |    0.08 |  1.0300 |     - |     - |      2 KB |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  2.800 μs | 0.0155 μs | 0.0137 μs |  2.800 μs |  0.98 |    0.04 |  0.9880 |     - |     - |      2 KB |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 |  5.500 μs | 0.0293 μs | 0.0260 μs |  5.493 μs |  1.93 |    0.08 |  0.9842 |     - |     - |      2 KB |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  4.165 μs | 0.0811 μs | 0.0759 μs |  4.190 μs |  1.46 |    0.06 |  0.9842 |     - |     - |      2 KB |
|                      |        |          |       |           |           |           |           |       |         |         |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 |  1.373 μs | 0.0266 μs | 0.0261 μs |  1.366 μs |  1.00 |    0.00 |  2.0561 |     - |     - |      4 KB |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 |  1.350 μs | 0.0159 μs | 0.0148 μs |  1.351 μs |  0.98 |    0.02 |  2.0561 |     - |     - |      4 KB |
|                 Linq | .NET 6 | .NET 6.0 |  1000 |  5.247 μs | 0.1025 μs | 0.1654 μs |  5.338 μs |  3.73 |    0.14 |  2.1057 |     - |     - |      4 KB |
|           LinqFaster | .NET 6 | .NET 6.0 |  1000 |  4.535 μs | 0.0261 μs | 0.0232 μs |  4.541 μs |  3.30 |    0.06 |  3.8834 |     - |     - |      8 KB |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 |  6.894 μs | 0.0371 μs | 0.0329 μs |  6.893 μs |  5.02 |    0.10 |  2.0523 |     - |     - |      4 KB |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 49.039 μs | 0.6080 μs | 0.5077 μs | 48.969 μs | 35.77 |    0.69 | 16.4185 |     - |     - |     34 KB |
|              Streams | .NET 6 | .NET 6.0 |  1000 | 11.285 μs | 0.2218 μs | 0.3109 μs | 11.081 μs |  8.37 |    0.25 |  2.3041 |     - |     - |      5 KB |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |  5.774 μs | 0.0235 μs | 0.0196 μs |  5.779 μs |  4.21 |    0.07 |  1.0300 |     - |     - |      2 KB |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  2.082 μs | 0.0203 μs | 0.0159 μs |  2.080 μs |  1.52 |    0.03 |  0.9880 |     - |     - |      2 KB |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 |  5.310 μs | 0.0319 μs | 0.0298 μs |  5.311 μs |  3.87 |    0.08 |  0.9842 |     - |     - |      2 KB |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  1.366 μs | 0.0102 μs | 0.0090 μs |  1.365 μs |  0.99 |    0.02 |  0.9899 |     - |     - |      2 KB |
