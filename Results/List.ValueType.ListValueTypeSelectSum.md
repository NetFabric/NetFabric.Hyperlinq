## List.ValueType.ListValueTypeSelectSum

### Source
[ListValueTypeSelectSum.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelectSum.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta34](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta34)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 | 189.79 ns |  0.476 ns |  0.445 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 374.67 ns |  1.560 ns |  1.303 ns |  1.97 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 952.10 ns |  2.718 ns |  2.542 ns |  5.02 |    0.02 | 0.0343 |     - |     - |      72 B |
|           LinqFaster |   100 | 297.10 ns |  0.760 ns |  0.673 ns |  1.57 |    0.00 |      - |     - |     - |         - |
|               LinqAF |   100 | 869.47 ns | 17.262 ns | 24.756 ns |  4.62 |    0.13 |      - |     - |     - |         - |
|           StructLinq |   100 | 230.47 ns |  0.572 ns |  0.477 ns |  1.21 |    0.00 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |   100 |  83.10 ns |  0.121 ns |  0.107 ns |  0.44 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 195.04 ns |  0.599 ns |  0.531 ns |  1.03 |    0.00 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |  76.59 ns |  0.206 ns |  0.183 ns |  0.40 |    0.00 |      - |     - |     - |         - |
