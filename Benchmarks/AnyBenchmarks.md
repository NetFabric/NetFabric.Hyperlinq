## AnyBenchmarks

### Source
[AnyBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/AnyBenchmarks.cs)

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
|                              Method |                Categories | Count |      Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |----------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |  9.570 ns | 0.0403 ns | 0.0377 ns |  1.00 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |  7.398 ns | 0.0239 ns | 0.0212 ns |  0.77 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 |  7.059 ns | 0.0153 ns | 0.0136 ns |  0.74 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 |  9.320 ns | 0.0184 ns | 0.0154 ns |  0.97 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 20.919 ns | 0.1901 ns | 0.1778 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 | 12.951 ns | 0.0592 ns | 0.0554 ns |  0.62 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |           |           |           |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |  4.785 ns | 0.0294 ns | 0.0261 ns |  1.00 |      - |     - |     - |         - |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |  1.814 ns | 0.0140 ns | 0.0109 ns |  0.38 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |  5.508 ns | 0.0308 ns | 0.0257 ns |  1.00 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |  1.557 ns | 0.0115 ns | 0.0102 ns |  0.28 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 66.405 ns | 0.2603 ns | 0.2308 ns |  1.00 | 0.0191 |     - |     - |      40 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 64.644 ns | 0.7299 ns | 0.6470 ns |  0.97 | 0.0191 |     - |     - |      40 B |
|                                     |                           |       |           |           |           |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 18.561 ns | 0.0726 ns | 0.0679 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 10.427 ns | 0.0500 ns | 0.0468 ns |  0.56 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |           |           |           |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |  4.753 ns | 0.0252 ns | 0.0236 ns |  1.00 |      - |     - |     - |         - |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |  1.815 ns | 0.0141 ns | 0.0125 ns |  0.38 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |  5.475 ns | 0.0320 ns | 0.0300 ns |  1.00 |      - |     - |     - |         - |
|            Hyperlinq_List_Reference |            List_Reference |   100 |  3.331 ns | 0.0124 ns | 0.0116 ns |  0.61 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 63.852 ns | 0.7519 ns | 0.5870 ns |  1.00 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 62.577 ns | 0.2383 ns | 0.2229 ns |  0.98 | 0.0191 |     - |     - |      40 B |
