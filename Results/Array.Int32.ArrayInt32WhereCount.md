## Array.Int32.ArrayInt32WhereCount

### Source
[ArrayInt32WhereCount.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereCount.cs)

### References:
- Cistern.ValueLinq: [0.1.14](https://www.nuget.org/packages/Cistern.ValueLinq/0.1.14)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.25.3](https://www.nuget.org/packages/StructLinq.BCL/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta31](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta31)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |    77.93 ns |  0.151 ns |  0.134 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |    78.00 ns |  0.113 ns |  0.105 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 Linq |   100 | 1,021.75 ns |  3.192 ns |  2.665 ns | 13.11 |    0.04 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |   100 |   494.09 ns | 10.942 ns | 32.092 ns |  6.17 |    0.37 |      - |     - |     - |         - |
|               LinqAF |   100 |   482.22 ns |  9.622 ns | 25.848 ns |  6.11 |    0.30 |      - |     - |     - |         - |
|           StructLinq |   100 |   468.04 ns |  9.169 ns | 16.058 ns |  5.91 |    0.18 | 0.0305 |     - |     - |      64 B |
| StructLinq_IFunction |   100 |    81.27 ns |  0.246 ns |  0.218 ns |  1.04 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq |   100 |   169.03 ns |  0.188 ns |  0.176 ns |  2.17 |    0.00 |      - |     - |     - |         - |
|  Hyperlinq_IFunction |   100 |    78.29 ns |  0.228 ns |  0.202 ns |  1.00 |    0.00 |      - |     - |     - |         - |
