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
|                          Linq_Array |                     Array |   100 |    18.303 ns | 0.0905 ns | 0.0847 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |    12.914 ns | 0.0221 ns | 0.0196 ns |  0.71 |    0.00 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 |    11.972 ns | 0.0386 ns | 0.0361 ns |  0.65 |    0.00 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 |    14.886 ns | 0.0352 ns | 0.0312 ns |  0.81 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |              |           |           |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   344.107 ns | 1.7931 ns | 1.5895 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   327.619 ns | 3.0460 ns | 2.8492 ns |  0.95 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |              |           |           |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |   346.598 ns | 3.0301 ns | 2.8344 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   369.066 ns | 1.6787 ns | 1.4018 ns |  1.06 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |              |           |           |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |     9.935 ns | 0.0425 ns | 0.0377 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |   343.461 ns | 1.2599 ns | 1.1169 ns | 34.57 |    0.18 |      - |     - |     - |         - |
|                                     |                           |       |              |           |           |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,100.044 ns | 6.1183 ns | 5.1090 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,908.694 ns | 6.0890 ns | 5.6957 ns |  0.91 |    0.00 | 0.0191 |     - |     - |      40 B |
|                                     |                           |       |              |           |           |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   236.653 ns | 1.1131 ns | 0.9867 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   249.168 ns | 1.5335 ns | 1.2806 ns |  1.05 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |              |           |           |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   239.494 ns | 2.1650 ns | 1.9192 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   265.782 ns | 1.7675 ns | 1.6533 ns |  1.11 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |              |           |           |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |     9.991 ns | 0.0681 ns | 0.0637 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   320.237 ns | 1.8057 ns | 1.6007 ns | 32.07 |    0.26 |      - |     - |     - |         - |
|                                     |                           |       |              |           |           |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,952.611 ns | 7.3231 ns | 6.8500 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,831.791 ns | 5.7827 ns | 5.4091 ns |  0.94 |    0.00 | 0.0191 |     - |     - |      40 B |
