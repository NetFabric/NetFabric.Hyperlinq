## ListDistinct

### Source
[ListDistinct.cs](../LinqBenchmarks/ListDistinct.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.1.9](https://www.nuget.org/packages/StructLinq.BCL/0.1.9)
- NetFabric.Hyperlinq: [3.0.0-beta19](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta19)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|      Method | Count |       Mean |    Error |   StdDev |     Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |------ |-----------:|---------:|---------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|     ForLoop |   100 | 1,456.2 ns |  7.84 ns |  6.95 ns | 1,455.3 ns |  1.00 |    0.00 | 2.8706 |     - |     - |    6008 B |
| ForeachLoop |   100 | 1,640.4 ns | 32.43 ns | 80.15 ns | 1,593.0 ns |  1.15 |    0.06 | 2.8706 |     - |     - |    6008 B |
|        Linq |   100 | 2,785.0 ns | 10.53 ns |  9.85 ns | 2,785.8 ns |  1.91 |    0.01 | 2.0638 |     - |     - |    4320 B |
|  LinqFaster |   100 |   671.6 ns |  3.45 ns |  3.22 ns |   671.9 ns |  0.46 |    0.00 |      - |     - |     - |         - |
|  StructLinq |   100 | 1,955.4 ns |  9.50 ns |  7.41 ns | 1,955.6 ns |  1.34 |    0.01 |      - |     - |     - |         - |
|   Hyperlinq |   100 | 1,910.4 ns |  7.30 ns |  6.47 ns | 1,908.4 ns |  1.31 |    0.01 |      - |     - |     - |         - |
