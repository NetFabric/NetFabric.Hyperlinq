## Array.Int32.ArrayInt32WhereCount

### Source
[ArrayInt32WhereCount.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereCount.cs)

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
|               Method | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|              ForLoop |   100 |  75.31 ns | 0.553 ns | 0.517 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          ForeachLoop |   100 |  78.66 ns | 0.440 ns | 0.390 ns |  1.04 |    0.01 |      - |     - |     - |         - |
|                 Linq |   100 | 639.40 ns | 4.053 ns | 3.791 ns |  8.49 |    0.08 | 0.0153 |     - |     - |      32 B |
|           LinqFaster |   100 | 245.93 ns | 1.143 ns | 1.069 ns |  3.27 |    0.03 |      - |     - |     - |         - |
|           StructLinq |   100 | 375.10 ns | 4.101 ns | 3.636 ns |  4.98 |    0.07 | 0.0191 |     - |     - |      40 B |
| StructLinq_IFunction |   100 | 163.79 ns | 1.232 ns | 1.028 ns |  2.17 |    0.02 | 0.0191 |     - |     - |      40 B |
|            Hyperlinq |   100 | 197.28 ns | 0.579 ns | 0.484 ns |  2.62 |    0.02 |      - |     - |     - |         - |
