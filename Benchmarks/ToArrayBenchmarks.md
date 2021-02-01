## ToArrayBenchmarks

### Source
[ToArrayBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ToArrayBenchmarks.cs)

### References:
- Linq: 4.8.4300.0
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.25.3](https://www.nuget.org/packages/StructLinq/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta29](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta29)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
  [Host]        : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                              Method |                Categories | Count |        Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |    49.33 ns | 0.233 ns | 0.206 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|                    StructLinq_Array |                     Array |   100 |    79.71 ns | 0.426 ns | 0.398 ns |  1.62 |    0.01 | 0.2027 |     - |     - |     424 B |
|                     Hyperlinq_Array |                     Array |   100 |    30.57 ns | 0.090 ns | 0.075 ns |  0.62 |    0.00 | 0.2027 |     - |     - |     424 B |
|                      Hyperlinq_Span |                     Array |   100 |    28.22 ns | 0.294 ns | 0.275 ns |  0.57 |    0.01 | 0.2027 |     - |     - |     424 B |
|                    Hyperlinq_Memory |                     Array |   100 |    30.64 ns | 0.181 ns | 0.160 ns |  0.62 |    0.00 | 0.2027 |     - |     - |     424 B |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   887.10 ns | 2.480 ns | 2.071 ns |  1.00 |    0.00 | 0.5655 |     - |     - |    1184 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   900.66 ns | 1.904 ns | 1.687 ns |  1.02 |    0.00 | 0.2174 |     - |     - |     456 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   517.63 ns | 1.854 ns | 1.644 ns |  0.58 |    0.00 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |    43.34 ns | 0.245 ns | 0.204 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   893.50 ns | 2.616 ns | 2.184 ns | 20.62 |    0.10 | 0.2174 |     - |     - |     456 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |    59.69 ns | 0.736 ns | 0.652 ns |  1.38 |    0.02 | 0.2180 |     - |     - |     456 B |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |    45.11 ns | 0.201 ns | 0.168 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|               StructLinq_List_Value |                List_Value |   100 |   243.02 ns | 0.931 ns | 0.871 ns |  5.39 |    0.03 | 0.2027 |     - |     - |     424 B |
|                Hyperlinq_List_Value |                List_Value |   100 |    42.65 ns | 0.234 ns | 0.196 ns |  0.95 |    0.01 | 0.2027 |     - |     - |     424 B |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   702.23 ns | 2.098 ns | 1.860 ns |  1.00 |    0.00 | 0.5655 |     - |     - |    1184 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   724.75 ns | 2.218 ns | 1.852 ns |  1.03 |    0.00 | 0.2174 |     - |     - |     456 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   789.74 ns | 2.514 ns | 2.099 ns |  1.12 |    0.00 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |    43.89 ns | 0.609 ns | 0.569 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   725.74 ns | 2.660 ns | 2.488 ns | 16.54 |    0.22 | 0.2174 |     - |     - |     456 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |    49.80 ns | 0.642 ns | 0.570 ns |  1.13 |    0.02 | 0.2142 |     - |     - |     448 B |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |    44.96 ns | 0.119 ns | 0.100 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   719.31 ns | 2.610 ns | 2.442 ns | 16.00 |    0.07 | 0.2174 |     - |     - |     456 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |    45.09 ns | 0.962 ns | 0.853 ns |  1.00 |    0.02 | 0.2027 |     - |     - |     424 B |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,661.99 ns | 3.493 ns | 3.268 ns |     ? |       ? | 0.5646 |     - |     - |    1184 B |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,308.43 ns | 6.064 ns | 5.375 ns |     ? |       ? | 0.5836 |     - |     - |    1224 B |
