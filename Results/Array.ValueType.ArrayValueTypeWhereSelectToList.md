## Array.ValueType.ArrayValueTypeWhereSelectToList

### Source
[ArrayValueTypeWhereSelectToList.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeWhereSelectToList.cs)

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
|               Method |    Job |  Runtime | Count |     Mean |    Error |   StdDev |   Median | Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |---------:|---------:|---------:|---------:|------:|--------:|--------:|--------:|------:|----------:|
|              ForLoop | .NET 5 | .NET 5.0 |  1000 | 11.03 μs | 0.216 μs | 0.529 μs | 10.87 μs |  1.00 |    0.00 | 31.2347 |       - |     - |     64 KB |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 | 16.41 μs | 0.138 μs | 0.129 μs | 16.39 μs |  1.41 |    0.09 | 10.4065 |  5.1880 |     - |     64 KB |
|                 Linq | .NET 5 | .NET 5.0 |  1000 | 17.20 μs | 0.180 μs | 0.168 μs | 17.17 μs |  1.47 |    0.09 | 10.4065 |  5.1880 |     - |     64 KB |
|           LinqFaster | .NET 5 | .NET 5.0 |  1000 | 19.49 μs | 0.133 μs | 0.124 μs | 19.53 μs |  1.67 |    0.11 | 20.4163 | 10.1929 |     - |    125 KB |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 | 26.99 μs | 0.529 μs | 1.376 μs | 26.61 μs |  2.46 |    0.19 | 31.2195 |       - |     - |     64 KB |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 77.30 μs | 1.127 μs | 0.941 μs | 77.16 μs |  6.55 |    0.46 | 78.3691 | 19.6533 |     - |    213 KB |
|              Streams | .NET 5 | .NET 5.0 |  1000 | 73.80 μs | 0.775 μs | 0.687 μs | 73.43 μs |  6.29 |    0.43 | 10.4980 |  5.2490 |     - |     64 KB |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 | 16.96 μs | 0.090 μs | 0.080 μs | 16.96 μs |  1.44 |    0.09 | 15.3809 |       - |     - |     32 KB |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 | 11.43 μs | 0.104 μs | 0.097 μs | 11.39 μs |  0.98 |    0.06 | 15.3503 |       - |     - |     31 KB |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 | 16.59 μs | 0.221 μs | 0.196 μs | 16.56 μs |  1.41 |    0.09 |  5.1270 |  2.5635 |     - |     31 KB |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 | 11.87 μs | 0.188 μs | 0.460 μs | 11.71 μs |  1.08 |    0.03 | 15.3809 |       - |     - |     31 KB |
|                      |        |          |       |          |          |          |          |       |         |         |         |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 | 11.03 μs | 0.186 μs | 0.452 μs | 10.94 μs |  1.00 |    0.00 | 31.2347 |       - |     - |     64 KB |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 | 13.14 μs | 0.306 μs | 0.838 μs | 12.71 μs |  1.21 |    0.07 | 31.2347 |       - |     - |     64 KB |
|                 Linq | .NET 6 | .NET 6.0 |  1000 | 16.95 μs | 0.210 μs | 0.187 μs | 16.92 μs |  1.48 |    0.10 | 10.4065 |  5.1880 |     - |     64 KB |
|           LinqFaster | .NET 6 | .NET 6.0 |  1000 | 18.29 μs | 0.698 μs | 2.046 μs | 17.15 μs |  1.71 |    0.20 | 58.3801 | 14.5874 |     - |    125 KB |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 | 26.95 μs | 0.538 μs | 1.427 μs | 26.52 μs |  2.45 |    0.14 | 31.2195 |       - |     - |     64 KB |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 90.79 μs | 1.002 μs | 0.937 μs | 90.91 μs |  7.94 |    0.50 | 74.0967 | 18.4326 |     - |    213 KB |
|              Streams | .NET 6 | .NET 6.0 |  1000 | 63.97 μs | 0.254 μs | 0.225 μs | 64.01 μs |  5.58 |    0.35 | 10.4980 |  5.2490 |     - |     64 KB |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 | 15.24 μs | 0.171 μs | 0.160 μs | 15.22 μs |  1.33 |    0.08 |  5.1270 |  2.5635 |     - |     32 KB |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 | 15.26 μs | 0.085 μs | 0.080 μs | 15.24 μs |  1.33 |    0.08 |  5.1270 |  2.5635 |     - |     31 KB |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 | 17.50 μs | 0.277 μs | 0.246 μs | 17.47 μs |  1.53 |    0.11 |  5.1270 |  2.5635 |     - |     31 KB |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 | 15.31 μs | 0.176 μs | 0.165 μs | 15.23 μs |  1.34 |    0.09 |  5.1270 |  2.5635 |     - |     31 KB |
