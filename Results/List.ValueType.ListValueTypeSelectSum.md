## List.ValueType.ListValueTypeSelectSum

### Source
[ListValueTypeSelectSum.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelectSum.cs)

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
|               Method | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 | 189.78 ns |  0.559 ns |  0.467 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 375.59 ns |  0.999 ns |  0.885 ns |  1.98 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 953.73 ns |  3.447 ns |  3.224 ns |  5.03 |    0.02 | 0.0343 |     - |     - |      72 B |
|           LinqFaster |   100 | 296.57 ns |  0.539 ns |  0.421 ns |  1.56 |    0.00 |      - |     - |     - |         - |
|               LinqAF |   100 | 892.50 ns | 17.128 ns | 22.271 ns |  4.68 |    0.11 |      - |     - |     - |         - |
|           StructLinq |   100 | 230.31 ns |  0.457 ns |  0.381 ns |  1.21 |    0.00 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |   100 |  83.16 ns |  0.206 ns |  0.182 ns |  0.44 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 195.59 ns |  0.433 ns |  0.362 ns |  1.03 |    0.00 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |  68.22 ns |  0.223 ns |  0.197 ns |  0.36 |    0.00 |      - |     - |     - |         - |
