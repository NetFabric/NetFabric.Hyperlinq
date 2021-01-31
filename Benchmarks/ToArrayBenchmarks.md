## ToArrayBenchmarks

### Source
[ToArrayBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ToArrayBenchmarks.cs)

### References:
- Linq: 4.8.4300.0
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.19.3](https://www.nuget.org/packages/StructLinq/0.19.3)
- NetFabric.Hyperlinq: [3.0.0-beta27](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta27)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
  [Host]        : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                              Method |                Categories | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |    65.93 ns |  0.649 ns |  0.607 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|                    StructLinq_Array |                     Array |   100 |   114.66 ns |  1.653 ns |  1.381 ns |  1.74 |    0.03 | 0.2027 |     - |     - |     424 B |
|                     Hyperlinq_Array |                     Array |   100 |    43.04 ns |  0.713 ns |  0.667 ns |  0.65 |    0.01 | 0.2027 |     - |     - |     424 B |
|                      Hyperlinq_Span |                     Array |   100 |    41.27 ns |  0.557 ns |  0.521 ns |  0.63 |    0.01 | 0.2027 |     - |     - |     424 B |
|                    Hyperlinq_Memory |                     Array |   100 |    44.07 ns |  0.638 ns |  0.498 ns |  0.67 |    0.01 | 0.2027 |     - |     - |     424 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,016.08 ns | 13.883 ns | 12.307 ns |  1.00 |    0.00 | 0.5646 |     - |     - |    1184 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   984.43 ns | 16.383 ns | 14.523 ns |  0.97 |    0.02 | 0.2174 |     - |     - |     456 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   596.65 ns |  6.485 ns |  6.067 ns |  0.59 |    0.01 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |    57.40 ns |  0.821 ns |  0.728 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   995.02 ns | 14.373 ns | 12.741 ns | 17.34 |    0.37 | 0.2174 |     - |     - |     456 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |    79.92 ns |  1.572 ns |  1.471 ns |  1.39 |    0.03 | 0.2180 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |    58.72 ns |  0.606 ns |  0.506 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|               StructLinq_List_Value |                List_Value |   100 | 1,003.06 ns | 16.945 ns | 15.850 ns | 17.07 |    0.27 | 0.2174 |     - |     - |     456 B |
|                Hyperlinq_List_Value |                List_Value |   100 |    58.28 ns |  1.070 ns |  1.001 ns |  0.99 |    0.02 | 0.2027 |     - |     - |     424 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   796.02 ns | 15.733 ns | 17.488 ns |  1.00 |    0.00 | 0.5655 |     - |     - |    1184 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   795.61 ns | 11.073 ns | 10.358 ns |  1.00 |    0.03 | 0.2174 |     - |     - |     456 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   905.51 ns |  9.048 ns |  8.463 ns |  1.14 |    0.03 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |    57.73 ns |  0.820 ns |  0.767 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   795.71 ns | 11.991 ns | 11.216 ns | 13.79 |    0.25 | 0.2174 |     - |     - |     456 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |    67.19 ns |  1.323 ns |  1.104 ns |  1.16 |    0.02 | 0.2142 |     - |     - |     448 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |    60.01 ns |  1.253 ns |  1.172 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   808.16 ns | 13.028 ns | 13.940 ns | 13.48 |    0.33 | 0.2174 |     - |     - |     456 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |    58.31 ns |  1.199 ns |  1.283 ns |  0.97 |    0.03 | 0.2027 |     - |     - |     424 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,825.65 ns | 12.856 ns | 12.025 ns |     ? |       ? | 0.5646 |     - |     - |    1184 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,530.36 ns | 20.108 ns | 18.809 ns |     ? |       ? | 0.5836 |     - |     - |    1224 B |
