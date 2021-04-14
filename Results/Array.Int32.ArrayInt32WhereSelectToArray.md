## Array.Int32.ArrayInt32WhereSelectToArray

### Source
[ArrayInt32WhereSelectToArray.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelectToArray.cs)

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
|              ForLoop | .NET 5 | .NET 5.0 |  1000 |  3.117 μs | 0.0187 μs | 0.0166 μs |  3.114 μs |  1.00 |    0.00 |  3.0289 |     - |     - |      6 KB |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 |  4.136 μs | 0.0823 μs | 0.1258 μs |  4.194 μs |  1.30 |    0.05 |  3.0289 |     - |     - |      6 KB |
|                 Linq | .NET 5 | .NET 5.0 |  1000 |  5.256 μs | 0.0234 μs | 0.0219 μs |  5.259 μs |  1.69 |    0.01 |  2.1667 |     - |     - |      4 KB |
|           LinqFaster | .NET 5 | .NET 5.0 |  1000 |  4.424 μs | 0.0203 μs | 0.0169 μs |  4.423 μs |  1.42 |    0.01 |  2.8915 |     - |     - |      6 KB |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 |  7.596 μs | 0.0385 μs | 0.0341 μs |  7.593 μs |  2.44 |    0.02 |  3.0060 |     - |     - |      6 KB |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 52.947 μs | 1.0125 μs | 0.8455 μs | 52.687 μs | 16.99 |    0.31 | 15.5029 |     - |     - |     32 KB |
|              Streams | .NET 5 | .NET 5.0 |  1000 |  8.808 μs | 0.0443 μs | 0.0393 μs |  8.808 μs |  2.83 |    0.02 |  3.2654 |     - |     - |      7 KB |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 |  5.532 μs | 0.0263 μs | 0.0246 μs |  5.524 μs |  1.78 |    0.02 |  1.0147 |     - |     - |      2 KB |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  2.897 μs | 0.0138 μs | 0.0115 μs |  2.891 μs |  0.93 |    0.01 |  0.9727 |     - |     - |      2 KB |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 |  5.481 μs | 0.0337 μs | 0.0299 μs |  5.483 μs |  1.76 |    0.02 |  0.9689 |     - |     - |      2 KB |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  3.902 μs | 0.0122 μs | 0.0102 μs |  3.902 μs |  1.25 |    0.01 |  0.9689 |     - |     - |      2 KB |
|                      |        |          |       |           |           |           |           |       |         |         |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 |  1.479 μs | 0.0287 μs | 0.0814 μs |  1.446 μs |  1.00 |    0.00 |  3.0308 |     - |     - |      6 KB |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 |  1.532 μs | 0.0322 μs | 0.0943 μs |  1.484 μs |  1.03 |    0.05 |  3.0308 |     - |     - |      6 KB |
|                 Linq | .NET 6 | .NET 6.0 |  1000 |  5.123 μs | 0.0269 μs | 0.0251 μs |  5.126 μs |  3.34 |    0.18 |  2.1667 |     - |     - |      4 KB |
|           LinqFaster | .NET 6 | .NET 6.0 |  1000 |  4.787 μs | 0.0501 μs | 0.0391 μs |  4.777 μs |  3.16 |    0.14 |  2.8915 |     - |     - |      6 KB |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 |  8.441 μs | 0.0592 μs | 0.0525 μs |  8.423 μs |  5.52 |    0.27 |  3.0060 |     - |     - |      6 KB |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 49.426 μs | 0.4694 μs | 0.4161 μs | 49.352 μs | 32.34 |    1.57 | 15.4419 |     - |     - |     32 KB |
|              Streams | .NET 6 | .NET 6.0 |  1000 |  8.670 μs | 0.0618 μs | 0.0548 μs |  8.675 μs |  5.67 |    0.30 |  3.2654 |     - |     - |      7 KB |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |  5.508 μs | 0.0255 μs | 0.0226 μs |  5.509 μs |  3.61 |    0.19 |  1.0147 |     - |     - |      2 KB |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  4.697 μs | 0.0235 μs | 0.0220 μs |  4.696 μs |  3.06 |    0.16 |  0.9689 |     - |     - |      2 KB |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 |  5.223 μs | 0.0247 μs | 0.0219 μs |  5.221 μs |  3.42 |    0.17 |  0.9689 |     - |     - |      2 KB |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  1.376 μs | 0.0163 μs | 0.0145 μs |  1.372 μs |  0.90 |    0.05 |  0.9747 |     - |     - |      2 KB |
