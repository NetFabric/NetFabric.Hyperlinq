## Array.Int32.ArrayInt32Where

### Source
[ArrayInt32Where.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Where.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta29](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta29)

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
|              ForLoop |   100 |  74.04 ns |  0.212 ns |  0.188 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  74.00 ns |  0.221 ns |  0.206 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 706.65 ns | 14.117 ns | 38.646 ns |  9.53 |    0.45 | 0.0229 |     - |     - |      48 B |
|           LinqFaster |   100 | 280.57 ns |  1.420 ns |  1.259 ns |  3.79 |    0.02 | 0.3095 |     - |     - |     648 B |
|               LinqAF |   100 | 608.07 ns | 12.160 ns | 32.876 ns |  8.12 |    0.44 |      - |     - |     - |         - |
|           StructLinq |   100 | 530.06 ns | 16.058 ns | 47.095 ns |  7.26 |    0.79 | 0.0153 |     - |     - |      32 B |
| StructLinq_IFunction |   100 | 166.72 ns |  0.395 ns |  0.369 ns |  2.25 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq |   100 | 489.28 ns |  9.798 ns | 22.512 ns |  6.61 |    0.28 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 | 187.57 ns |  0.587 ns |  0.549 ns |  2.53 |    0.01 |      - |     - |     - |         - |
