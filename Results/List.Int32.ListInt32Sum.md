## List.Int32.ListInt32Sum

### Source
[ListInt32Sum.cs](../LinqBenchmarks/List/Int32/ListInt32Sum.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta33](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta33)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 | 103.71 ns | 0.257 ns | 0.214 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 | 194.95 ns | 0.516 ns | 0.483 ns |  1.88 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 649.47 ns | 1.684 ns | 1.406 ns |  6.26 |    0.02 | 0.0191 |     - |     - |      40 B |
|           LinqFaster |   100 | 668.10 ns | 1.415 ns | 1.324 ns |  6.44 |    0.02 | 0.0191 |     - |     - |      40 B |
|               LinqAF |   100 | 479.86 ns | 1.406 ns | 1.246 ns |  4.63 |    0.02 |      - |     - |     - |         - |
|           StructLinq |   100 |  81.47 ns | 0.296 ns | 0.231 ns |  0.79 |    0.00 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |   100 |  61.84 ns | 0.111 ns | 0.093 ns |  0.60 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 |  24.55 ns | 0.052 ns | 0.043 ns |  0.24 |    0.00 |      - |     - |     - |         - |
