## Array.Int32.ArrayInt32WhereCount

### Source
[ArrayInt32WhereCount.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereCount.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta26](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta26)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |  79.54 ns | 0.732 ns | 0.649 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  79.81 ns | 0.490 ns | 0.459 ns |  1.00 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 634.76 ns | 3.096 ns | 2.896 ns |  7.98 |    0.08 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |   100 | 236.00 ns | 1.054 ns | 0.986 ns |  2.97 |    0.03 |      - |     - |     - |         - |
|               LinqAF |   100 | 231.80 ns | 0.978 ns | 0.816 ns |  2.91 |    0.03 |      - |     - |     - |         - |
|           StructLinq |   100 | 376.34 ns | 2.949 ns | 2.758 ns |  4.73 |    0.06 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 | 165.77 ns | 1.334 ns | 1.248 ns |  2.08 |    0.03 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 171.52 ns | 0.808 ns | 0.756 ns |  2.16 |    0.02 |      - |     - |     - |         - |
