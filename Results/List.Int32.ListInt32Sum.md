## List.Int32.ListInt32Sum

### Source
[ListInt32Sum.cs](../LinqBenchmarks/List/Int32/ListInt32Sum.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta36](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta36)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.21079.7
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 | 106.95 ns |  0.427 ns |  0.356 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 326.28 ns |  2.355 ns |  2.203 ns |  3.05 |    0.02 |      - |     - |     - |         - |
|                 Linq |   100 | 960.22 ns |  8.935 ns |  7.461 ns |  8.98 |    0.08 | 0.0191 |     - |     - |      40 B |
|           LinqFaster |   100 | 959.73 ns | 14.866 ns | 11.606 ns |  8.97 |    0.12 | 0.0191 |     - |     - |      40 B |
|               LinqAF |   100 | 703.70 ns |  5.291 ns |  4.690 ns |  6.58 |    0.04 |      - |     - |     - |         - |
|           StructLinq |   100 |  88.78 ns |  0.282 ns |  0.220 ns |  0.83 |    0.00 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |   100 |  66.42 ns |  0.267 ns |  0.250 ns |  0.62 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 |  21.58 ns |  0.203 ns |  0.180 ns |  0.20 |    0.00 |      - |     - |     - |         - |
