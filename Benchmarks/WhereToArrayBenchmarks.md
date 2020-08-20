## WhereToArrayBenchmarks

### Source
[WhereToArrayBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/WhereToArrayBenchmarks.cs)

### References:
- Linq: 5.0.0-preview.7.20364.11
- System.Linq.Async: [4.1.1](https://www.nuget.org/packages/System.Linq.Async/4.1.1)
- System.Interactive: [4.1.1](https://www.nuget.org/packages/System.Interactive/4.1.1)
- System.Interactive.Async: [4.1.1](https://www.nuget.org/packages/System.Interactive.Async/4.1.1)
- StructLinq: [0.19.2](https://www.nuget.org/packages/StructLinq/0.19.2)
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
|                              Method |                Categories | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   430.1 ns |  1.65 ns |  1.47 ns |  1.00 |    0.00 | 0.3519 |     - |     - |     736 B |
|                    StructLinq_Array |                     Array |   100 |   484.4 ns |  4.01 ns |  3.56 ns |  1.13 |    0.01 | 0.1144 |     - |     - |     240 B |
|                     Hyperlinq_Array |                     Array |   100 |   493.9 ns |  2.48 ns |  2.20 ns |  1.15 |    0.01 | 0.1144 |     - |     - |     240 B |
|                      Hyperlinq_Span |                     Array |   100 |   464.0 ns |  2.34 ns |  2.08 ns |  1.08 |    0.01 | 0.1144 |     - |     - |     240 B |
|                    Hyperlinq_Memory |                     Array |   100 |   490.6 ns |  2.04 ns |  1.91 ns |  1.14 |    0.00 | 0.1144 |     - |     - |     240 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,208.4 ns |  7.27 ns |  6.80 ns |  1.00 |    0.00 | 0.3700 |     - |     - |     776 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,591.3 ns | 15.97 ns | 14.94 ns |  1.32 |    0.02 | 0.1297 |     - |     - |     272 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   571.5 ns |  1.97 ns |  1.65 ns |  0.47 |    0.00 | 0.1144 |     - |     - |     240 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,222.3 ns |  5.82 ns |  5.16 ns |  1.00 |    0.00 | 0.3700 |     - |     - |     776 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,592.7 ns | 10.34 ns |  9.16 ns |  1.30 |    0.01 | 0.1297 |     - |     - |     272 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   570.5 ns |  5.88 ns |  5.21 ns |  0.47 |    0.00 | 0.1144 |     - |     - |     240 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,206.1 ns |  6.07 ns |  9.81 ns |  1.00 |    0.00 | 0.3700 |     - |     - |     776 B |
|               StructLinq_List_Value |                List_Value |   100 | 1,552.5 ns | 12.57 ns | 11.76 ns |  1.29 |    0.01 | 0.1297 |     - |     - |     272 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   838.5 ns |  9.04 ns |  8.02 ns |  0.70 |    0.01 | 0.1144 |     - |     - |     240 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 6,192.9 ns | 45.12 ns | 40.00 ns |  1.00 |    0.00 | 0.4578 |     - |     - |     960 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 6,268.5 ns | 59.47 ns | 49.66 ns |  1.01 |    0.01 | 0.4730 |     - |     - |     992 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   850.3 ns |  3.18 ns |  2.98 ns |  1.00 |    0.00 | 0.3710 |     - |     - |     776 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1,120.0 ns |  7.14 ns |  6.33 ns |  1.32 |    0.01 | 0.1297 |     - |     - |     272 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   932.6 ns |  6.23 ns |  4.86 ns |  1.10 |    0.01 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   847.9 ns |  4.05 ns |  3.38 ns |  1.00 |    0.00 | 0.3710 |     - |     - |     776 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 | 1,168.6 ns |  5.79 ns |  5.13 ns |  1.38 |    0.01 | 0.1297 |     - |     - |     272 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   939.7 ns |  8.94 ns |  8.37 ns |  1.11 |    0.01 | 0.1297 |     - |     - |     272 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   887.4 ns |  7.13 ns |  6.32 ns |  1.00 |    0.00 | 0.3710 |     - |     - |     776 B |
|           StructLinq_List_Reference |            List_Reference |   100 | 1,135.2 ns |  9.12 ns |  8.08 ns |  1.28 |    0.01 | 0.1297 |     - |     - |     272 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   871.7 ns |  5.20 ns |  4.34 ns |  0.98 |    0.01 | 0.1144 |     - |     - |     240 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 6,194.5 ns | 26.15 ns | 24.46 ns |  1.00 |    0.00 | 0.4578 |     - |     - |     960 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 6,485.6 ns | 45.18 ns | 42.26 ns |  1.05 |    0.01 | 0.4807 |     - |     - |    1008 B |
