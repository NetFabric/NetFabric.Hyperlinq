## ToArrayBenchmarks

### References:
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta25](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta25)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                              Method |                Categories | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |    52.11 ns |  0.608 ns |  0.539 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|                         System_Span |                     Array |   100 |    30.02 ns |  0.287 ns |  0.269 ns |  0.58 |    0.01 | 0.2027 |     - |     - |     424 B |
|                     Hyperlinq_Array |                     Array |   100 |    31.21 ns |  0.550 ns |  0.565 ns |  0.60 |    0.02 | 0.2027 |     - |     - |     424 B |
|                      Hyperlinq_Span |                     Array |   100 |    29.58 ns |  0.309 ns |  0.274 ns |  0.57 |    0.01 | 0.2027 |     - |     - |     424 B |
|                    Hyperlinq_Memory |                     Array |   100 |    32.14 ns |  0.402 ns |  0.356 ns |  0.62 |    0.01 | 0.2027 |     - |     - |     424 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   905.95 ns |  3.762 ns |  3.335 ns |  1.00 |    0.00 | 0.5617 |     - |     - |    1176 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   482.86 ns |  3.077 ns |  2.878 ns |  0.53 |    0.00 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |    91.41 ns |  0.522 ns |  0.436 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   102.90 ns |  0.752 ns |  0.704 ns |  1.13 |    0.01 | 0.2180 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |    92.25 ns |  0.668 ns |  0.592 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|                Hyperlinq_List_Value |                List_Value |   100 |    91.56 ns |  0.987 ns |  0.770 ns |  0.99 |    0.01 | 0.2027 |     - |     - |     424 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,423.47 ns | 10.612 ns |  9.926 ns |  1.00 |    0.00 | 0.7668 |     - |     - |    1608 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,221.42 ns | 18.389 ns | 16.301 ns |  0.92 |    0.01 | 0.5798 |     - |     - |    1216 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   795.37 ns |  4.930 ns |  4.612 ns |  1.00 |    0.00 | 0.5693 |     - |     - |    1192 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   839.20 ns |  5.213 ns |  4.353 ns |  1.06 |    0.00 | 0.2213 |     - |     - |     464 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |    88.91 ns |  0.471 ns |  0.440 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |    97.14 ns |  0.824 ns |  0.771 ns |  1.09 |    0.01 | 0.2142 |     - |     - |     448 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |    90.25 ns |  0.807 ns |  0.715 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |    89.55 ns |  0.402 ns |  0.376 ns |  0.99 |    0.01 | 0.2027 |     - |     - |     424 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 4,517.70 ns | 28.010 ns | 23.390 ns |  1.00 |    0.00 | 0.7477 |     - |     - |    1576 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 4,587.06 ns | 29.682 ns | 26.312 ns |  1.02 |    0.01 | 0.5722 |     - |     - |    1208 B |
