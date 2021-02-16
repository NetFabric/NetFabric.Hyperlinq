## List.Int32.ListInt32Sum

### Source
[ListInt32Sum.cs](../LinqBenchmarks/List/Int32/ListInt32Sum.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta37](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta37)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.21079.7
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 | 137.26 ns | 0.471 ns | 0.393 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 218.36 ns | 0.821 ns | 0.686 ns |  1.59 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 671.39 ns | 3.025 ns | 2.829 ns |  4.89 |    0.03 | 0.0191 |     - |     - |      40 B |
|           LinqFaster |   100 | 670.67 ns | 2.050 ns | 1.712 ns |  4.89 |    0.02 | 0.0191 |     - |     - |      40 B |
|               LinqAF |   100 | 450.15 ns | 1.326 ns | 1.175 ns |  3.28 |    0.01 |      - |     - |     - |         - |
|           StructLinq |   100 |  81.79 ns | 0.204 ns | 0.170 ns |  0.60 |    0.00 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |   100 |  64.18 ns | 0.437 ns | 0.387 ns |  0.47 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 |  16.53 ns | 0.066 ns | 0.058 ns |  0.12 |    0.00 |      - |     - |     - |         - |
