## List.Int32.ListInt32SelectToList

### Source
[ListInt32SelectToList.cs](../LinqBenchmarks/List/Int32/ListInt32SelectToList.cs)

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
|                   Method | Count |      Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 | 342.85 ns | 2.190 ns | 2.049 ns |  1.00 | 0.5660 |     - |     - |    1184 B |
|              ForeachLoop |   100 | 453.51 ns | 1.577 ns | 1.475 ns |  1.32 | 0.5660 |     - |     - |    1184 B |
|                     Linq |   100 | 298.50 ns | 1.655 ns | 1.467 ns |  0.87 | 0.2522 |     - |     - |     528 B |
|               LinqFaster |   100 | 351.11 ns | 1.620 ns | 1.516 ns |  1.02 | 0.4358 |     - |     - |     912 B |
|               StructLinq |   100 | 252.07 ns | 1.833 ns | 1.625 ns |  0.74 | 0.2484 |     - |     - |     520 B |
|     StructLinq_IFunction |   100 | 135.14 ns | 0.701 ns | 0.621 ns |  0.39 | 0.2370 |     - |     - |     496 B |
|                Hyperlinq |   100 | 240.21 ns | 1.296 ns | 1.149 ns |  0.70 | 0.2179 |     - |     - |     456 B |
|      Hyperlinq_IFunction |   100 | 109.99 ns | 0.679 ns | 0.635 ns |  0.32 | 0.2180 |     - |     - |     456 B |
|           Hyperlinq_SIMD |   100 |  89.95 ns | 0.609 ns | 0.570 ns |  0.26 | 0.2180 |     - |     - |     456 B |
| Hyperlinq_IFunction_SIMD |   100 |  62.06 ns | 0.543 ns | 0.453 ns |  0.18 | 0.2180 |     - |     - |     456 B |
