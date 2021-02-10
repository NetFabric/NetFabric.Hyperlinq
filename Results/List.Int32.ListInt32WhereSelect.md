## List.Int32.ListInt32WhereSelect

### Source
[ListInt32WhereSelect.cs](../LinqBenchmarks/List/Int32/ListInt32WhereSelect.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta35](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta35)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |---------:|--------:|--------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 | 128.7 ns | 0.41 ns | 0.34 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 210.7 ns | 0.64 ns | 0.54 ns |  1.64 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 987.6 ns | 6.50 ns | 6.08 ns |  7.68 |    0.06 | 0.0725 |     - |     - |     152 B |
|           LinqFaster |   100 | 565.4 ns | 1.12 ns | 1.05 ns |  4.39 |    0.01 | 0.3090 |     - |     - |     648 B |
|               LinqAF |   100 | 999.4 ns | 4.34 ns | 3.85 ns |  7.77 |    0.03 |      - |     - |     - |         - |
|           StructLinq |   100 | 401.2 ns | 1.97 ns | 1.84 ns |  3.12 |    0.02 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 | 183.5 ns | 1.11 ns | 0.92 ns |  1.43 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 370.0 ns | 1.52 ns | 1.35 ns |  2.88 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 | 189.9 ns | 0.51 ns | 0.45 ns |  1.48 |    0.00 |      - |     - |     - |         - |
