## List.Int32.ListInt32WhereSelectToList

### Source
[ListInt32WhereSelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelectToList.cs)

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
|              ForLoop | .NET 5 | .NET 5.0 |  1000 |  3.180 μs | 0.0207 μs | 0.0184 μs |  1.00 |    0.00 |  2.0561 |     - |     - |      4 KB |
|          ForeachLoop | .NET 5 | .NET 5.0 |  1000 |  5.220 μs | 0.0285 μs | 0.0267 μs |  1.64 |    0.01 |  2.0523 |     - |     - |      4 KB |
|                 Linq | .NET 5 | .NET 5.0 |  1000 |  6.123 μs | 0.0273 μs | 0.0242 μs |  1.93 |    0.01 |  2.1286 |     - |     - |      4 KB |
|           LinqFaster | .NET 5 | .NET 5.0 |  1000 |  5.826 μs | 0.1166 μs | 0.1745 μs |  1.81 |    0.07 |  3.0441 |     - |     - |      6 KB |
|               LinqAF | .NET 5 | .NET 5.0 |  1000 | 12.981 μs | 0.0568 μs | 0.0504 μs |  4.08 |    0.03 |  2.0447 |     - |     - |      4 KB |
|        LinqOptimizer | .NET 5 | .NET 5.0 |  1000 | 67.979 μs | 0.4157 μs | 0.3685 μs | 21.38 |    0.21 | 17.2119 |     - |     - |     35 KB |
|              Streams | .NET 5 | .NET 5.0 |  1000 | 12.842 μs | 0.0410 μs | 0.0320 μs |  4.04 |    0.02 |  2.3041 |     - |     - |      5 KB |
|           StructLinq | .NET 5 | .NET 5.0 |  1000 |  5.837 μs | 0.0238 μs | 0.0199 μs |  1.83 |    0.01 |  1.0300 |     - |     - |      2 KB |
| StructLinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  3.081 μs | 0.0258 μs | 0.0202 μs |  0.97 |    0.01 |  0.9880 |     - |     - |      2 KB |
|            Hyperlinq | .NET 5 | .NET 5.0 |  1000 |  5.577 μs | 0.0674 μs | 0.0597 μs |  1.75 |    0.02 |  0.9842 |     - |     - |      2 KB |
|  Hyperlinq_IFunction | .NET 5 | .NET 5.0 |  1000 |  4.004 μs | 0.0218 μs | 0.0182 μs |  1.26 |    0.01 |  0.9842 |     - |     - |      2 KB |
|                      |        |          |       |           |           |           |       |         |         |       |       |           |
|              ForLoop | .NET 6 | .NET 6.0 |  1000 |  2.260 μs | 0.0125 μs | 0.0110 μs |  1.00 |    0.00 |  2.0561 |     - |     - |      4 KB |
|          ForeachLoop | .NET 6 | .NET 6.0 |  1000 |  2.085 μs | 0.0133 μs | 0.0118 μs |  0.92 |    0.01 |  2.0561 |     - |     - |      4 KB |
|                 Linq | .NET 6 | .NET 6.0 |  1000 |  5.332 μs | 0.0176 μs | 0.0165 μs |  2.36 |    0.01 |  2.1286 |     - |     - |      4 KB |
|           LinqFaster | .NET 6 | .NET 6.0 |  1000 |  5.647 μs | 0.0360 μs | 0.0337 μs |  2.50 |    0.01 |  3.0441 |     - |     - |      6 KB |
|               LinqAF | .NET 6 | .NET 6.0 |  1000 | 12.487 μs | 0.0885 μs | 0.0828 μs |  5.52 |    0.05 |  2.0447 |     - |     - |      4 KB |
|        LinqOptimizer | .NET 6 | .NET 6.0 |  1000 | 64.052 μs | 0.7009 μs | 0.6557 μs | 28.35 |    0.35 | 16.9678 |     - |     - |     35 KB |
|              Streams | .NET 6 | .NET 6.0 |  1000 | 11.765 μs | 0.0616 μs | 0.0546 μs |  5.20 |    0.04 |  2.3041 |     - |     - |      5 KB |
|           StructLinq | .NET 6 | .NET 6.0 |  1000 |  5.571 μs | 0.1008 μs | 0.0894 μs |  2.46 |    0.04 |  1.0300 |     - |     - |      2 KB |
| StructLinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  3.004 μs | 0.0120 μs | 0.0094 μs |  1.33 |    0.01 |  0.9880 |     - |     - |      2 KB |
|            Hyperlinq | .NET 6 | .NET 6.0 |  1000 |  4.698 μs | 0.0168 μs | 0.0149 μs |  2.08 |    0.01 |  0.9842 |     - |     - |      2 KB |
|  Hyperlinq_IFunction | .NET 6 | .NET 6.0 |  1000 |  1.467 μs | 0.0293 μs | 0.0612 μs |  0.63 |    0.02 |  0.9899 |     - |     - |      2 KB |
