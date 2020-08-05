## Array.Int32.ArrayInt32SkipTakeWhere

### Source
[ArrayInt32SkipTakeWhere.cs](../LinqBenchmarks/Array/Int32/ArrayInt32SkipTakeWhere.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta23](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta23)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|               Method | Skip | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop | 1000 |   100 |   124.3 ns |  1.29 ns |  1.20 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop | 1000 |   100 | 2,359.2 ns | 19.81 ns | 18.53 ns | 18.98 |    0.25 | 0.0153 |     - |     - |      32 B |
|                 Linq | 1000 |   100 | 1,309.8 ns | 11.79 ns | 11.03 ns | 10.53 |    0.12 | 0.0725 |     - |     - |     152 B |
|           LinqFaster | 1000 |   100 |   357.7 ns |  5.82 ns |  5.16 ns |  2.87 |    0.05 | 0.7153 |     - |     - |    1496 B |
|           StructLinq | 1000 |   100 | 1,196.7 ns |  8.04 ns |  7.52 ns |  9.62 |    0.10 | 0.0458 |     - |     - |      96 B |
| StructLinq_IFunction | 1000 |   100 |   913.6 ns |  8.13 ns |  7.21 ns |  7.34 |    0.08 | 0.0458 |     - |     - |      96 B |
|            Hyperlinq | 1000 |   100 |   357.6 ns |  2.65 ns |  2.47 ns |  2.88 |    0.03 |      - |     - |     - |         - |
