## Array.Int32.ArrayInt32SelectToList

### Source
[ArrayInt32SelectToList.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SelectToList.cs)

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
|                   Method | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 | 301.94 ns | 1.807 ns | 1.690 ns |  1.00 |    0.00 | 0.5660 |     - |     - |    1184 B |
|              ForeachLoop |   100 | 307.28 ns | 5.847 ns | 5.469 ns |  1.02 |    0.02 | 0.5660 |     - |     - |    1184 B |
|                     Linq |   100 | 316.38 ns | 0.992 ns | 0.879 ns |  1.05 |    0.00 | 0.2408 |     - |     - |     504 B |
|               LinqFaster |   100 | 231.12 ns | 0.875 ns | 0.775 ns |  0.77 |    0.01 | 0.4206 |     - |     - |     880 B |
|          LinqFaster_SIMD |   100 | 110.79 ns | 1.029 ns | 0.962 ns |  0.37 |    0.00 | 0.4207 |     - |     - |     880 B |
|                   LinqAF |   100 | 884.02 ns | 7.367 ns | 6.531 ns |  2.93 |    0.02 | 0.5655 |     - |     - |    1184 B |
|               StructLinq |   100 | 240.64 ns | 2.225 ns | 2.081 ns |  0.80 |    0.01 | 0.2484 |     - |     - |     520 B |
|     StructLinq_IFunction |   100 | 129.48 ns | 0.476 ns | 0.397 ns |  0.43 |    0.00 | 0.2370 |     - |     - |     496 B |
|                Hyperlinq |   100 | 227.91 ns | 0.669 ns | 0.593 ns |  0.76 |    0.00 | 0.2179 |     - |     - |     456 B |
|      Hyperlinq_IFunction |   100 | 142.20 ns | 0.544 ns | 0.482 ns |  0.47 |    0.00 | 0.2179 |     - |     - |     456 B |
|           Hyperlinq_SIMD |   100 |  86.75 ns | 0.456 ns | 0.356 ns |  0.29 |    0.00 | 0.2180 |     - |     - |     456 B |
| Hyperlinq_IFunction_SIMD |   100 |  59.26 ns | 0.214 ns | 0.200 ns |  0.20 |    0.00 | 0.2180 |     - |     - |     456 B |
