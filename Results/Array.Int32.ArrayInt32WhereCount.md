## Array.Int32.ArrayInt32WhereCount

### Source
[ArrayInt32WhereCount.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereCount.cs)

### References:
- Cistern.ValueLinq: [0.0.11](https://www.nuget.org/packages/Cistern.ValueLinq/0.0.11)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta28](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta28)

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
|              ForLoop |   100 |  82.47 ns | 0.919 ns | 0.859 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  82.47 ns | 0.969 ns | 0.906 ns |  1.00 |    0.02 |      - |     - |     - |         - |
|                 Linq |   100 | 672.54 ns | 9.411 ns | 8.803 ns |  8.16 |    0.13 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |   100 | 229.01 ns | 1.798 ns | 1.682 ns |  2.78 |    0.03 |      - |     - |     - |         - |
|               LinqAF |   100 | 287.74 ns | 3.656 ns | 3.241 ns |  3.49 |    0.05 |      - |     - |     - |         - |
|           StructLinq |   100 | 290.89 ns | 3.694 ns | 3.455 ns |  3.53 |    0.06 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 |  88.29 ns | 1.027 ns | 0.961 ns |  1.07 |    0.02 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 183.17 ns | 1.096 ns | 0.972 ns |  2.22 |    0.02 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |  78.26 ns | 1.085 ns | 1.015 ns |  0.95 |    0.02 |      - |     - |     - |         - |
