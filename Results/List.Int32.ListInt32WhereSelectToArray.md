## List.Int32.ListInt32WhereSelectToArray

### Source
[ListInt32WhereSelectToArray.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToArray.cs)

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
|              ForLoop | .NET 5 | .NET 5.0 |  1000 |  5.003 μs | 0.0988 μs | 0.1997 μs |  4.894 μs |  1.00 |    0.00 |  3.0289 |     - |     - |      6 KB |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 |  4.935 μs | 0.0296 μs | 0.0277 μs |  4.936 μs |  0.94 |    0.03 |  3.0289 |     - |     - |      6 KB |
|                 Linq | .NET 5 | .NET 5.0 |  1000 |  6.997 μs | 0.1198 μs | 0.1000 μs |  7.012 μs |  1.32 |    0.02 |  2.1896 |     - |     - |      4 KB |
|           LinqFaster | .NET 5 | .NET 5.0 |  1000 |  5.653 μs | 0.0881 μs | 0.0781 μs |  5.618 μs |  1.07 |    0.04 |  3.0289 |     - |     - |      6 KB |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 | 12.682 μs | 0.2383 μs | 0.2229 μs | 12.746 μs |  2.41 |    0.11 |  3.0060 |     - |     - |      6 KB |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 67.566 μs | 0.3899 μs | 0.3456 μs | 67.522 μs | 12.79 |    0.41 | 16.1133 |     - |     - |     33 KB |
|              Streams | .NET 5 | .NET 5.0 |  1000 |  9.075 μs | 0.0574 μs | 0.0509 μs |  9.078 μs |  1.72 |    0.06 |  3.2654 |     - |     - |      7 KB |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 |  5.764 μs | 0.0247 μs | 0.0219 μs |  5.770 μs |  1.09 |    0.04 |  1.0147 |     - |     - |      2 KB |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  2.963 μs | 0.0186 μs | 0.0145 μs |  2.968 μs |  0.55 |    0.01 |  0.9727 |     - |     - |      2 KB |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 |  5.127 μs | 0.0271 μs | 0.0226 μs |  5.134 μs |  0.96 |    0.02 |  0.9689 |     - |     - |      2 KB |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  4.183 μs | 0.0201 μs | 0.0188 μs |  4.177 μs |  0.80 |    0.03 |  0.9689 |     - |     - |      2 KB |
|                      |        |          |       |           |           |           |           |       |         |         |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 |  2.097 μs | 0.0172 μs | 0.0134 μs |  2.094 μs |  1.00 |    0.00 |  3.0289 |     - |     - |      6 KB |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 |  2.189 μs | 0.0240 μs | 0.0224 μs |  2.181 μs |  1.04 |    0.01 |  3.0289 |     - |     - |      6 KB |
|                 Linq | .NET 6 | .NET 6.0 |  1000 |  5.734 μs | 0.0320 μs | 0.0250 μs |  5.738 μs |  2.73 |    0.02 |  2.1896 |     - |     - |      4 KB |
|           LinqFaster | .NET 6 | .NET 6.0 |  1000 |  5.429 μs | 0.0631 μs | 0.0560 μs |  5.415 μs |  2.59 |    0.04 |  3.0289 |     - |     - |      6 KB |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 | 12.338 μs | 0.0516 μs | 0.0483 μs | 12.328 μs |  5.88 |    0.04 |  3.0060 |     - |     - |      6 KB |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 67.433 μs | 1.9606 μs | 5.7808 μs | 63.275 μs | 34.47 |    1.63 | 15.9912 |     - |     - |     33 KB |
|              Streams | .NET 6 | .NET 6.0 |  1000 |  9.207 μs | 0.1818 μs | 0.3183 μs |  9.042 μs |  4.61 |    0.05 |  3.2654 |     - |     - |      7 KB |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |  5.665 μs | 0.0260 μs | 0.0230 μs |  5.663 μs |  2.70 |    0.01 |  1.0147 |     - |     - |      2 KB |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  3.287 μs | 0.0655 μs | 0.0581 μs |  3.270 μs |  1.56 |    0.03 |  0.9727 |     - |     - |      2 KB |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 |  5.164 μs | 0.0579 μs | 0.0513 μs |  5.170 μs |  2.47 |    0.02 |  0.9689 |     - |     - |      2 KB |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  1.346 μs | 0.0091 μs | 0.0081 μs |  1.345 μs |  0.64 |    0.01 |  0.9747 |     - |     - |      2 KB |
