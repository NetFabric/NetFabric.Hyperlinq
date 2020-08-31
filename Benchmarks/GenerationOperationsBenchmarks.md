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
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.40711, CoreFX 5.0.20.40711), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                Method |  Categories | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------- |------------ |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|            Linq_Empty |       Empty |   100 |     6.777 ns |  0.0902 ns |  0.0799 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|       Hyperlinq_Empty |       Empty |   100 |     1.755 ns |  0.0596 ns |  0.0529 ns |  0.26 |    0.01 |      - |     - |     - |         - |
|                       |             |       |              |            |            |       |         |        |       |       |           |
|      Linq_Empty_Async | Empty_Async |   100 |    41.994 ns |  0.2933 ns |  0.2600 ns |  1.00 |    0.00 |      - |     - |     - |         - |
| Hyperlinq_Empty_Async | Empty_Async |   100 |    22.386 ns |  0.1602 ns |  0.1337 ns |  0.53 |    0.00 |      - |     - |     - |         - |
|                       |             |       |              |            |            |       |         |        |       |       |           |
|            Linq_Range |       Range |   100 |   470.164 ns |  8.4433 ns |  7.4847 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|            StructLinq |       Range |   100 |    35.508 ns |  0.4060 ns |  0.3797 ns |  0.08 |    0.00 |      - |     - |     - |         - |
|       Hyperlinq_Range |       Range |   100 |    46.098 ns |  0.4970 ns |  0.4649 ns |  0.10 |    0.00 |      - |     - |     - |         - |
|                       |             |       |              |            |            |       |         |        |       |       |           |
|      Linq_Range_Async | Range_Async |   100 | 4,443.638 ns | 40.6357 ns | 38.0106 ns |  1.00 |    0.00 | 0.0229 |     - |     - |      48 B |
| Hyperlinq_Range_Async | Range_Async |   100 | 1,323.315 ns |  6.9926 ns |  5.8391 ns |  0.30 |    0.00 | 0.0153 |     - |     - |      32 B |
|                       |             |       |              |            |            |       |         |        |       |       |           |
|           Linq_Repeat |      Repeat |   100 |   496.513 ns |  9.7889 ns | 15.2402 ns |  1.20 |    0.04 | 0.0191 |     - |     - |      40 B |
|     Linq_Repeat_Count |      Repeat |   100 |   414.849 ns |  3.9838 ns |  3.3266 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Repeat |      Repeat |   100 |   151.060 ns |  0.9105 ns |  0.8517 ns |  0.36 |    0.00 |      - |     - |     - |         - |
|                       |             |       |              |            |            |       |         |        |       |       |           |
|           Linq_Return |      Return |   100 |    25.615 ns |  0.1603 ns |  0.1421 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|      Hyperlinq_Return |      Return |   100 |     5.595 ns |  0.0316 ns |  0.0247 ns |  0.22 |    0.00 |      - |     - |     - |         - |
|                       |             |       |              |            |            |       |         |        |       |       |           |
|           Linq_Create |      Create |   100 |   632.530 ns |  3.6992 ns |  2.8881 ns |  1.00 |    0.00 | 0.0534 |     - |     - |     112 B |
|      Hyperlinq_Create |      Create |   100 |   167.992 ns |  1.2234 ns |  1.0216 ns |  0.27 |    0.00 | 0.0305 |     - |     - |      64 B |
