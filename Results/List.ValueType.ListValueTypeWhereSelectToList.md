## List.ValueType.ListValueTypeWhereSelectToList

### Source
[ListValueTypeWhereSelectToList.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelectToList.cs)

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
|               Method |    Job |  Runtime | Count |      Mean |    Error |   StdDev |    Median | Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|--------------------- |------- |--------- |------ |----------:|---------:|---------:|----------:|------:|--------:|--------:|--------:|------:|----------:|
|              ForLoop | .NET 5 | .NET 5.0 |  1000 |  13.03 μs | 0.142 μs | 0.133 μs |  12.97 μs |  1.00 |    0.00 | 10.4218 |  5.2032 |     - |     64 KB |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 |  16.59 μs | 0.134 μs | 0.125 μs |  16.56 μs |  1.27 |    0.02 | 10.4065 |  5.1880 |     - |     64 KB |
|                 Linq | .NET 5 | .NET 5.0 |  1000 |  21.68 μs | 0.195 μs | 0.183 μs |  21.72 μs |  1.66 |    0.02 | 10.4675 |  5.2185 |     - |     64 KB |
|           LinqFaster | .NET 5 | .NET 5.0 |  1000 |  22.19 μs | 0.413 μs | 0.366 μs |  22.11 μs |  1.70 |    0.03 | 15.5640 |  7.7820 |     - |     95 KB |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 |  32.07 μs | 0.636 μs | 0.732 μs |  32.09 μs |  2.45 |    0.06 | 31.1890 |       - |     - |     64 KB |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 |  90.53 μs | 0.704 μs | 1.136 μs |  90.24 μs |  6.93 |    0.10 | 73.1201 | 24.2920 |     - |    215 KB |
|              Streams | .NET 5 | .NET 5.0 |  1000 |  66.19 μs | 0.305 μs | 0.271 μs |  66.11 μs |  5.08 |    0.06 | 31.2500 |       - |     - |     64 KB |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 |  20.68 μs | 0.149 μs | 0.132 μs |  20.67 μs |  1.59 |    0.02 |  5.1270 |  2.5635 |     - |     32 KB |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  11.33 μs | 0.068 μs | 0.064 μs |  11.33 μs |  0.87 |    0.01 |  5.1270 |  2.5635 |     - |     31 KB |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 |  16.61 μs | 0.279 μs | 0.247 μs |  16.59 μs |  1.27 |    0.02 |  5.1270 |  2.5635 |     - |     31 KB |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  14.18 μs | 0.107 μs | 0.089 μs |  14.17 μs |  1.09 |    0.01 |  5.1270 |  2.5635 |     - |     31 KB |
|                      |        |          |       |           |          |          |           |       |         |         |         |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 |  13.07 μs | 0.151 μs | 0.134 μs |  13.04 μs |  1.00 |    0.00 | 10.4218 |  5.2032 |     - |     64 KB |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 |  17.06 μs | 0.504 μs | 1.486 μs |  16.24 μs |  1.48 |    0.08 | 31.2195 |       - |     - |     64 KB |
|                 Linq | .NET 6 | .NET 6.0 |  1000 |  17.00 μs | 0.336 μs | 0.513 μs |  16.89 μs |  1.32 |    0.05 | 31.2195 |       - |     - |     64 KB |
|           LinqFaster | .NET 6 | .NET 6.0 |  1000 |  24.21 μs | 0.359 μs | 0.319 μs |  24.26 μs |  1.85 |    0.03 | 15.5640 |  7.7820 |     - |     95 KB |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 |  31.51 μs | 0.593 μs | 0.609 μs |  31.40 μs |  2.42 |    0.04 | 31.1890 |       - |     - |     64 KB |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 102.64 μs | 1.032 μs | 0.965 μs | 102.59 μs |  7.86 |    0.13 | 73.8525 | 19.8975 |     - |    214 KB |
|              Streams | .NET 6 | .NET 6.0 |  1000 |  65.32 μs | 0.551 μs | 0.516 μs |  65.31 μs |  5.00 |    0.06 | 31.1279 |       - |     - |     64 KB |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |  15.66 μs | 0.383 μs | 1.123 μs |  15.02 μs |  1.22 |    0.09 | 15.3809 |       - |     - |     32 KB |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  10.91 μs | 0.077 μs | 0.064 μs |  10.91 μs |  0.83 |    0.01 |  5.1270 |  2.5635 |     - |     31 KB |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 |  21.07 μs | 0.410 μs | 0.403 μs |  21.09 μs |  1.61 |    0.04 |  5.1270 |  2.5635 |     - |     31 KB |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  13.02 μs | 0.232 μs | 0.309 μs |  13.12 μs |  1.01 |    0.02 | 15.3809 |       - |     - |     31 KB |
