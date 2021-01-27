## Array.Int32.ArrayInt32SkipTakeWhere

### Source
[ArrayInt32SkipTakeWhere.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeWhere.cs)

### References:
- Cistern.ValueLinq: [0.0.11](https://www.nuget.org/packages/Cistern.ValueLinq/0.0.11)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta27](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta27)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Skip | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |    93.80 ns |  0.310 ns |  0.290 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 2,569.22 ns |  8.910 ns |  8.335 ns | 27.39 |    0.12 | 0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |   100 | 1,334.91 ns | 19.049 ns | 17.818 ns | 14.23 |    0.19 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |   100 |   333.06 ns |  1.622 ns |  1.438 ns |  3.55 |    0.02 | 0.7153 |     - |     - |    1496 B |
|               LinqAF | 1000 |   100 | 2,693.42 ns | 11.398 ns |  8.899 ns | 28.72 |    0.12 |      - |     - |     - |         - |
|           StructLinq | 1000 |   100 |   289.51 ns |  0.725 ns |  0.566 ns |  3.09 |    0.01 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |   100 |   161.87 ns |  0.429 ns |  0.380 ns |  1.73 |    0.01 |      - |     - |     - |         - |
|            Hyperlinq | 1000 |   100 |   266.80 ns |  0.686 ns |  0.641 ns |  2.84 |    0.01 |      - |     - |     - |         - |
|  Hyperlinq_IFunction | 1000 |   100 |   183.69 ns |  0.402 ns |  0.376 ns |  1.96 |    0.01 |      - |     - |     - |         - |
