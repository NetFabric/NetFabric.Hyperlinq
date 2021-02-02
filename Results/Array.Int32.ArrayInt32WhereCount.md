## Array.Int32.ArrayInt32WhereCount

### Source
[ArrayInt32WhereCount.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereCount.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta30](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta30)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |      Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |  77.06 ns | 0.150 ns | 0.140 ns |  1.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  77.09 ns | 0.172 ns | 0.152 ns |  1.00 |      - |     - |     - |         - |
|                 Linq |   100 | 619.58 ns | 1.750 ns | 1.462 ns |  8.04 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |   100 | 211.71 ns | 0.491 ns | 0.460 ns |  2.75 |      - |     - |     - |         - |
|               LinqAF |   100 | 265.60 ns | 0.784 ns | 0.733 ns |  3.45 |      - |     - |     - |         - |
|           StructLinq |   100 | 265.62 ns | 0.952 ns | 0.795 ns |  3.45 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 |  81.00 ns | 0.156 ns | 0.146 ns |  1.05 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 190.73 ns | 0.755 ns | 0.706 ns |  2.48 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |  74.76 ns | 0.365 ns | 0.324 ns |  0.97 |      - |     - |     - |         - |
