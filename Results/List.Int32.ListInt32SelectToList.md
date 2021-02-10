## Array.Int32.ListInt32SelectToList

### Source
[ListInt32SelectToList.cs](../LinqBenchmarks/Array/Int32/ListInt32SelectToList.cs)

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
|                   Method | Count |      Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 | 328.74 ns | 1.741 ns | 1.544 ns |  1.00 | 0.5660 |     - |     - |    1184 B |
|              ForeachLoop |   100 | 437.22 ns | 1.324 ns | 1.174 ns |  1.33 | 0.5660 |     - |     - |    1184 B |
|                     Linq |   100 | 289.16 ns | 0.921 ns | 0.816 ns |  0.88 | 0.2522 |     - |     - |     528 B |
|               LinqFaster |   100 | 340.00 ns | 2.112 ns | 1.872 ns |  1.03 | 0.4358 |     - |     - |     912 B |
|               StructLinq |   100 | 275.85 ns | 1.421 ns | 1.329 ns |  0.84 | 0.2484 |     - |     - |     520 B |
|     StructLinq_IFunction |   100 | 131.08 ns | 0.611 ns | 0.510 ns |  0.40 | 0.2370 |     - |     - |     496 B |
|                Hyperlinq |   100 | 236.03 ns | 0.693 ns | 0.579 ns |  0.72 | 0.2179 |     - |     - |     456 B |
|      Hyperlinq_IFunction |   100 | 107.02 ns | 0.450 ns | 0.399 ns |  0.33 | 0.2180 |     - |     - |     456 B |
|           Hyperlinq_SIMD |   100 | 103.00 ns | 0.368 ns | 0.326 ns |  0.31 | 0.2180 |     - |     - |     456 B |
| Hyperlinq_IFunction_SIMD |   100 |  70.98 ns | 0.497 ns | 0.440 ns |  0.22 | 0.2180 |     - |     - |     456 B |
