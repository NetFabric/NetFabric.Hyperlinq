## List.ValueType.ListValueTypeSelectSum

### Source
[ListValueTypeSelectSum.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSelectSum.cs)

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
|               Method | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 | 168.18 ns |  0.642 ns |  0.569 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 401.34 ns |  1.144 ns |  1.014 ns |  2.39 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 893.97 ns |  4.258 ns |  3.555 ns |  5.32 |    0.03 | 0.0343 |     - |     - |      72 B |
|           LinqFaster |   100 | 321.40 ns |  2.028 ns |  1.693 ns |  1.91 |    0.01 |      - |     - |     - |         - |
|               LinqAF |   100 | 899.90 ns | 17.997 ns | 38.741 ns |  5.15 |    0.16 |      - |     - |     - |         - |
|           StructLinq |   100 | 229.39 ns |  0.758 ns |  0.672 ns |  1.36 |    0.01 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |   100 |  83.53 ns |  0.250 ns |  0.222 ns |  0.50 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 196.76 ns |  0.274 ns |  0.229 ns |  1.17 |    0.00 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |  68.24 ns |  0.225 ns |  0.211 ns |  0.41 |    0.00 |      - |     - |     - |         - |
