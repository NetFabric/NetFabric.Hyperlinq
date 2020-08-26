## GenerationOperationsBenchmarks

### Source
[GenerationOperationsBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/GenerationOperationsBenchmarks.cs)

### References:
- Linq: 4.8.4180.0
- System.Linq.Async: [4.1.1](https://www.nuget.org/packages/System.Linq.Async/4.1.1)
- System.Interactive: [4.1.1](https://www.nuget.org/packages/System.Interactive/4.1.1)
- System.Interactive.Async: [4.1.1](https://www.nuget.org/packages/System.Interactive.Async/4.1.1)
- StructLinq: [0.19.2](https://www.nuget.org/packages/StructLinq/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta26](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta26)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
  [Host]        : .NET Framework 4.8 (4.8.4180.0), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                Method |  Categories | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------- |------------ |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|            Linq_Range |       Range |   100 |   468.402 ns |  4.0114 ns |  3.5560 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|            StructLinq |       Range |   100 |    41.631 ns |  0.2548 ns |  0.2259 ns |  0.09 |    0.00 |      - |     - |     - |         - |
|       Hyperlinq_Range |       Range |   100 |    48.050 ns |  0.2837 ns |  0.2654 ns |  0.10 |    0.00 |      - |     - |     - |         - |
|                       |             |       |              |            |            |       |         |        |       |       |           |
|      Linq_Range_Async | Range_Async |   100 | 4,465.616 ns | 31.9504 ns | 29.8864 ns |  1.00 |    0.00 | 0.0229 |     - |     - |      48 B |
| Hyperlinq_Range_Async | Range_Async |   100 | 1,333.197 ns | 13.7090 ns | 12.1526 ns |  0.30 |    0.00 | 0.0153 |     - |     - |      32 B |
|                       |             |       |              |            |            |       |         |        |       |       |           |
|           Linq_Repeat |      Repeat |   100 |   497.942 ns |  8.6412 ns | 12.3930 ns |  1.23 |    0.03 | 0.0191 |     - |     - |      40 B |
|     Linq_Repeat_Count |      Repeat |   100 |   410.968 ns |  1.9838 ns |  1.6565 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Repeat |      Repeat |   100 |   152.580 ns |  0.6167 ns |  0.5769 ns |  0.37 |    0.00 |      - |     - |     - |         - |
|                       |             |       |              |            |            |       |         |        |       |       |           |
|           Linq_Return |      Return |   100 |    25.324 ns |  0.2027 ns |  0.1896 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|      Hyperlinq_Return |      Return |   100 |     5.576 ns |  0.0311 ns |  0.0290 ns |  0.22 |    0.00 |      - |     - |     - |         - |
|                       |             |       |              |            |            |       |         |        |       |       |           |
|           Linq_Create |      Create |   100 |   634.506 ns |  7.1289 ns |  6.3195 ns |  1.00 |    0.00 | 0.0534 |     - |     - |     112 B |
|      Hyperlinq_Create |      Create |   100 |   168.888 ns |  1.3941 ns |  1.3040 ns |  0.27 |    0.00 | 0.0305 |     - |     - |      64 B |
