## ElementAtBenchmarks

### Source
[ElementAtBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ElementAtBenchmarks.cs)

### References:
- Linq: 6.0.0-preview.2.21154.6
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.25.3](https://www.nuget.org/packages/StructLinq/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1521-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.2.21155.3
  [Host]     : .NET 6.0.0 (6.0.21.15406), X64 RyuJIT
  Job-KXCEYC : .NET 6.0.0 (6.0.21.15406), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |         Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |    16.827 ns | 0.0864 ns | 0.0809 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |    13.462 ns | 0.0422 ns | 0.0374 ns |  0.80 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |              |           |           |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   344.429 ns | 1.3959 ns | 1.2375 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   144.601 ns | 0.3814 ns | 0.3381 ns |  0.42 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |              |           |           |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |   344.272 ns | 0.8262 ns | 0.7324 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   149.374 ns | 0.2419 ns | 0.2144 ns |  0.43 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |              |           |           |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |    10.101 ns | 0.1818 ns | 0.1611 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |    14.733 ns | 0.1009 ns | 0.0843 ns |  1.46 |    0.02 |      - |     - |     - |         - |
|                                     |                           |       |              |           |           |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,794.986 ns | 5.2256 ns | 4.8880 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 |   966.367 ns | 3.3670 ns | 2.8116 ns |  0.54 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |              |           |           |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   342.764 ns | 1.0983 ns | 0.8575 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   366.209 ns | 2.0936 ns | 1.8559 ns |  1.07 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |              |           |           |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   345.252 ns | 0.9672 ns | 0.8574 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   368.954 ns | 1.2762 ns | 1.0657 ns |  1.07 |    0.00 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |              |           |           |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |     9.997 ns | 0.1035 ns | 0.1151 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq_List_Reference |            List_Reference |   100 |    14.667 ns | 0.0498 ns | 0.0416 ns |  1.47 |    0.02 |      - |     - |     - |         - |
|                                     |                           |       |              |           |           |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,791.748 ns | 3.0825 ns | 2.7325 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,609.644 ns | 3.2502 ns | 2.8812 ns |  0.90 |    0.00 | 0.0153 |     - |     - |      32 B |
