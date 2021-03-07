## ElementAtBenchmarks

### Source
[ElementAtBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ElementAtBenchmarks.cs)

### References:
- Linq: 5.0.3
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.25.3](https://www.nuget.org/packages/StructLinq/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=6.0.100-preview.1.21103.13
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                              Method |                Categories | Count |         Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |    18.083 ns | 0.0504 ns | 0.0447 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |    12.865 ns | 0.0180 ns | 0.0160 ns |  0.71 |    0.00 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 |    12.404 ns | 0.0161 ns | 0.0143 ns |  0.69 |    0.00 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 |    14.822 ns | 0.0284 ns | 0.0266 ns |  0.82 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |              |           |           |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   341.088 ns | 1.4908 ns | 1.3216 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   136.518 ns | 0.2666 ns | 0.2494 ns |  0.40 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |              |           |           |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |   336.015 ns | 1.9240 ns | 1.7056 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   141.912 ns | 0.3696 ns | 0.3457 ns |  0.42 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |              |           |           |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |     9.832 ns | 0.0304 ns | 0.0269 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |   414.004 ns | 0.5393 ns | 0.4781 ns | 42.11 |    0.13 |      - |     - |     - |         - |
|                                     |                           |       |              |           |           |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,089.367 ns | 5.8311 ns | 5.1691 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,196.219 ns | 2.5077 ns | 2.2230 ns |  0.57 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |              |           |           |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   233.966 ns | 0.9228 ns | 0.8181 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   253.980 ns | 0.7701 ns | 0.6431 ns |  1.09 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |              |           |           |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   234.677 ns | 0.6609 ns | 0.5858 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   259.818 ns | 1.3146 ns | 1.1654 ns |  1.11 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |              |           |           |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |     9.835 ns | 0.0428 ns | 0.0379 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   414.119 ns | 0.6968 ns | 0.5819 ns | 42.10 |    0.19 |      - |     - |     - |         - |
|                                     |                           |       |              |           |           |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,964.533 ns | 3.9702 ns | 3.7137 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,810.745 ns | 1.9774 ns | 1.7529 ns |  0.92 |    0.00 | 0.0191 |     - |     - |      40 B |
